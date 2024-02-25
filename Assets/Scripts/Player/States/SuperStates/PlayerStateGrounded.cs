using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateGrounded : PlayerState
{
    private bool dash_input;
    private bool sit_input;

    protected Vector2 input;

    public PlayerStateGrounded(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
    base(player, statectl, data, animation_flag)
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
        sit_input = player.input_handler.sit_input;

        if (dash_input && player.state_dash.IsAvailable() && statectl.current_state != player.state_sit)
            statectl.ChangeState(player.state_dash);

        if (sit_input)
            statectl.ChangeState(player.state_sit);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
