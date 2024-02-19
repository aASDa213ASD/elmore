using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public  bool    facing_left;
    //public  bool    is_walking;
    public  bool    is_running;
    public  float   move_speed;
    public  Vector2 input;

    private Animator animator;
    public LayerMask structures_layer;
    public LayerMask ground_layer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
        // if (input.x != 0) input.y = 0; // Removes the ability to move horizontally
        
        if (input != Vector2.zero)
        {   
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                //is_walking = true;
                is_running = false;
            }
            else
            {
                is_running = true;
                //is_walking = false;
            }

            if (is_running) move_speed = 5;
            else move_speed = 2; 

            animator.SetFloat("move_x", input.x);
            animator.SetFloat("move_y", input.y);

            if (input.x > 0 && facing_left)
                flip();

            if (input.x < 0 && !facing_left)
                flip();
            
            var target_position = transform.position;
            target_position.x += input.x * move_speed * Time.deltaTime;
            target_position.y += input.y * move_speed * Time.deltaTime;

            if (is_walkable(target_position))
                transform.position = target_position;
        }

        //animator.SetBool("is_walking", is_walking);
        animator.SetBool("is_running", is_running);

        //is_walking = false;
        is_running = false;
    }

    private void flip()
    {
        Vector3 current_scale = gameObject.transform.localScale;
        current_scale.x *= -1;
        gameObject.transform.localScale = current_scale;

        facing_left = !facing_left;
    }

    private bool is_walkable(Vector3 target_position)
    {
        //if (Physics2D.Raycast(transform.position, target_position - transform.position, (target_position - transform.position).magnitude))
        //    return false;

        if (Physics2D.OverlapCircle(target_position, 0.2f, structures_layer) != null)
            return false;

        if (Physics2D.OverlapCircle(target_position, 0.2f, ground_layer) != null)
            return false;
        
        return true;
    }
}
