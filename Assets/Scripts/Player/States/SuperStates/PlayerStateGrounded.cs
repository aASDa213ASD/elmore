using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateGrounded : PlayerState
{
    private bool dash_input;

    protected Vector2 input;

    public PlayerStateGrounded(Player player, PlayerStateMachine state_machine, PlayerData data, string animation_flag):
    base(player, state_machine, data, animation_flag)
    {
        
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        input = player.input_handler.movement_input;
        dash_input = player.input_handler.dash_input;

        if (dash_input)
            state_machine.ChangeState(player.state_dash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
