using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    /*
    private bool is_facing_left;
    private bool is_running;
    private bool is_walking;
    private Animator animator;

    public Vector2 input;
    public LayerMask ground_layer;
    public LayerMask structures_layer;
    public float move_speed = 5.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        check_input();
        check_movement_direction();
        update_animations();
        // other checks
    }

    private void FixedUpdate()
    {
        move();
    }

    private void check_input()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;

        if (input != Vector2.zero)
        {
            if (Input.GetKey(KeyCode.LeftAlt)) // <-- Walk
            {
                is_running = false;
                is_walking = true;
            }
            else
            {
                is_running = true;
                is_walking = false;
            }

            move_speed = is_running ? 5.0f : 2.5f;
        }
        else
        {
            is_running = false;
            is_walking = false;
        }
    }

    private void flip()
    {
        Vector3 current_scale = gameObject.transform.localScale;
        current_scale.x *= -1;

        gameObject.transform.localScale = current_scale;
        is_facing_left = !is_facing_left;
    }

    private void check_movement_direction()
    {
        if (is_facing_left && input.x > 0)
            flip();
        else if (!is_facing_left && input.x < 0)
            flip();
    }

    private void update_animations()
    {
        if (input != Vector2.zero)
        {
            animator.SetFloat("move_x", input.x);
            animator.SetFloat("move_y", input.y);
        }

        animator.SetBool("is_running", is_running);
        animator.SetBool("is_walking", is_walking);
    }

    private void move()
    {   
        if (is_running || is_walking)
        {
            var position = transform.position;
            position.x += input.x * move_speed * Time.deltaTime;
            position.y += input.y * move_speed * Time.deltaTime;

            if (is_walkable(position))
                transform.position = position;
        }
    }

    private bool is_walkable(Vector3 target_position)
    {
        //if (Physics2D.Raycast(transform.position, target_position - transform.position, (target_position - transform.position).magnitude))
        //    return false;

        if (Physics2D.OverlapCircle(target_position, 0.5f, structures_layer) != null)
            return false;

        if (Physics2D.OverlapCircle(target_position, 0.5f, ground_layer) != null)
            return false;
        
        return true;
    }
    */
}
