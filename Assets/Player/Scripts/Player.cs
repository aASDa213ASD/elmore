using UnityEngine;
using UnityEngine.AI;

public class Player : Creature
{
    public static Player Instance { get; private set; }

    public Statectl     statectl      { get; private set; }
    public StateIdle    state_idle    { get; private set; }
    public StateMove    state_move    { get; private set; }
    public StateSit     state_sit     { get; private set; }

    public PlayerInputHandler input_handler { get; private set; }
    public Transform move_point_indicator { get; private set; }

    public override void Awake()
    {
        base.Awake();

        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        navigation_agent = GetComponent<NavMeshAgent>();
        navigation_agent.updateRotation = false;
        navigation_agent.updateUpAxis = false;

        statectl = new Statectl();
        state_idle = new StateIdle(this, statectl, data, "idle");
        state_move = new StateMove(this, statectl, data, "move");
        state_sit  = new StateSit(this, statectl, data, "sit");
    }

    public override void Start()
    {
        base.Start();

        input_handler = GetComponent<PlayerInputHandler>();
        move_point_indicator = transform.Find("Movepoint");

        statectl.Initialize(state_idle);
    }

    public override void Update()
    {
        base.Update();

        //Debug.Log("Target: " + target);
        statectl.current_state.FrameUpdate();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        statectl.current_state.PhysicsUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        
        statectl.current_state.LastUpdate();
        Debug.Log("Target: " + target);
    }

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (statectl.current_state == state_move)
        {
            // Reset destination to make player stumble upon objects
            //navigation_agent.ResetPath();
            //input_handler.movement_location = transform.position;
            //Move(input_handler.movement_location);
        }
    }
    */
}
