using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector2           velocity;
    private Vector2           velocity_current;

    public PlayerInputHandler input_handler     { get; private set; }
    public PlayerStateMachine state_machine     { get; private set; }
    public Animator           anim              { get; private set; }
    public Rigidbody2D        rigid_body        { get; private set; }
    public PlayerStateIdle    state_idle        { get; private set; }
    public PlayerStateMove    state_move        { get; private set; }
    public PlayerStateDash    state_dash        { get; private set; }
    public bool               facing_direction  { get; private set; }

    [SerializeField]
    private PlayerData data;

    private void Awake()
    {
        state_machine = new PlayerStateMachine();

        state_idle = new PlayerStateIdle(this, state_machine, data, "idle");
        state_move = new PlayerStateMove(this, state_machine, data, "move");
        state_dash = new PlayerStateDash(this, state_machine, data, "dash");
    }

    private void Start()
    {
        input_handler = GetComponent<PlayerInputHandler>();
        rigid_body    = GetComponent<Rigidbody2D>();
        anim          = GetComponent<Animator>();
        
        facing_direction = true; // 0 -> Left, 1 -> Right;

        state_machine.Initialize(state_idle);
    }

    private void Update()
    {
        state_machine.current_state.LogicUpdate();
    }

    private void FixedUpdate()
    {
        state_machine.current_state.PhysicsUpdate();
    }

    private void Flip()
    {
        facing_direction = !facing_direction;
        
        Vector3 current_scale = gameObject.transform.localScale;
        current_scale.x *= -1;
        gameObject.transform.localScale = current_scale;
    }

    public void Move(float x, float  y)
    {   
        velocity.Set(x, y);
        rigid_body.velocity = velocity;
        //location.x += movement_vector_x * Time.deltaTime;
        //location.y += movement_vector_y * Time.deltaTime;

        //transform.position = location;
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
