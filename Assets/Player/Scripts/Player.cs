using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, ICreature
{
    private Vector2           velocity;

    public Animator           anim          { get; private set; }
    public Rigidbody2D        rigid_body    { get; private set; }
    public PlayerStatectl     statectl      { get; private set; }
    public PlayerStateIdle    state_idle    { get; private set; }
    public PlayerStateMove    state_move    { get; private set; }
    public PlayerStateSit     state_sit     { get; private set; }
    public PlayerInputHandler input_handler { get; private set; }

    public Transform move_point_indicator { get; private set; }
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
        statectl = new PlayerStatectl();

        state_idle = new PlayerStateIdle(this, statectl, data, "idle");
        state_move = new PlayerStateMove(this, statectl, data, "move");
        state_sit  = new PlayerStateSit(this, statectl, data, "sit");

        creature_name  = data.creature_name;
        creature_title = data.creature_title;
        name_color  = data.name_color;
        title_color = data.title_color;
    }

    private void Start()
    {
        input_handler = GetComponent<PlayerInputHandler>();
        rigid_body    = GetComponent<Rigidbody2D>();
        anim          = GetComponent<Animator>();

        move_point_indicator = transform.Find("Movepoint");
        // false -> left, true -> right
        facing_direction = true;

        statectl.Initialize(state_idle);
    }

    private void Update()
    {
        Debug.Log("Target: " + target);
        statectl.current_state.FrameUpdate();
    }

    private void FixedUpdate()
    {
        statectl.current_state.PhysicsUpdate();
    }

    private void LateUpdate()
    {
        statectl.current_state.LastUpdate();
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (statectl.current_state == state_move)
        {
            // Reset destination to make player stumble upon objects
            input_handler.movement_location = transform.position;
        }
    }

    public void SetTarget(MonoBehaviour creature)
    {
        target = creature;
    }

    public void ResetTarget()
    {
        target = null;
    }

    public MonoBehaviour GetTarget()
    {
        return target;
    }
}
