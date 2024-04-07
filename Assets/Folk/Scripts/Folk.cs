using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Folk : MonoBehaviour, ICreature
{
    private Vector2           velocity;

    public Animator           anim          { get; private set; }
    public Rigidbody2D        rigid_body    { get; private set; }

    public bool facing_direction { get; private set; }

    public string creature_name  { get; set; }
    public string creature_title { get; set; }
    public Color name_color  { get; set; }
    public Color title_color { get; set; }
    public MonoBehaviour target { get; set; }

    [SerializeField]
    private CreatureData data;

    private void Awake()
    {
        creature_name  = data.creature_name;
        creature_title = data.creature_title;
        name_color  = data.name_color;
        title_color = data.title_color;
    }

    private void Start()
    {
        rigid_body    = GetComponent<Rigidbody2D>();
        anim          = GetComponent<Animator>();

        // false -> left, true -> right
        facing_direction = true;
    }

    private void Flip()
    {
        facing_direction = !facing_direction;
        
        Vector3 current_scale = gameObject.transform.localScale;
        current_scale.x *= -1;
        gameObject.transform.localScale = current_scale;
    }

    public void Move(float x, float y)
    {
        velocity.Set(x, y);
        rigid_body.velocity = velocity;
    }

    public void Stop()
    {
        velocity.Set(0f, 0f);
        rigid_body.velocity = velocity;
    }

    public void TryFlip(Vector2 input)
    {
        if (facing_direction && input.x < 0)
            Flip();
        
        else if (!facing_direction && input.x > 0)
            Flip();
    }
}
