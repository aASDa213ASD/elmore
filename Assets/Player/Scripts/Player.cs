using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : Creature, IDamagable
{
    //public static Player Instance { get; private set; }

    public Statectl     statectl      { get; private set; }
    public StateIdle    state_idle    { get; private set; }
    public StateMove    state_move    { get; private set; }
    public StateSit     state_sit     { get; private set; }
    public StateDeath   state_death   { get; private set; }

    public PlayerInputHandler input_handler { get; private set; }
    public Transform move_point_indicator { get; private set; }

    public float health_max { get; set;  }
    public float health_current { get; set; }

    public override void Awake()
    {
        base.Awake();

        //if (Instance == null) Instance = this;
        //else Destroy(gameObject);

        navigation_agent = GetComponent<NavMeshAgent>();
        navigation_agent.updateRotation = false;
        navigation_agent.updateUpAxis = false;

        health_max = data.health_max;
        health_current = data.health_current;

        statectl = new Statectl();
        state_idle = new StateIdle(this, statectl, data, "idle");
        state_move = new StateMove(this, statectl, data, "move");
        state_sit  = new StateSit(this, statectl, data, "sit");
        state_death = new StateDeath(this, statectl, data, "death");
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

    public void Damage(float amount)
    {
        if (health_current - amount <= 0)
        {
            health_current = 0;
            Die();
        }
        else
        {
            health_current -= amount;
        }
    }

    public void Die()
    {
        statectl.ChangeState(state_death);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage(100);

        /*
        if (statectl.current_state == state_move)
        {
            // Reset destination to make player stumble upon objects
            //navigation_agent.ResetPath();
            //input_handler.movement_location = transform.position;
            //Move(input_handler.movement_location);
        }
        */
    }
}
