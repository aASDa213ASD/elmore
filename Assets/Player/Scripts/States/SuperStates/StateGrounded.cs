using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGrounded : State
{
    //protected Vector2 input;
    protected Vector3 movement_location;
    protected Vector2 movement_direction;

    private bool sit_input;

    public StateGrounded(Player player, Statectl statectl, CreatureData data, string animation_flag):
    base(player, statectl, data, animation_flag) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        movement_location = player.input_handler.movement_location;
        movement_location.z = 0; // Any better place to nullify it?
        movement_direction = movement_location - player.transform.position;
        sit_input = player.input_handler.sit_input;

        if (sit_input)
            statectl.ChangeState(player.state_sit);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void LastUpdate()
    {
        base.LastUpdate();
    }
}
