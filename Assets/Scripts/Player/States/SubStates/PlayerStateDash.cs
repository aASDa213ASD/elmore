using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateDash : PlayerStateAbility
{   
    private Vector2 dash_direction;

    public float dash_time_last;

    public PlayerStateDash(Player player, PlayerStateMachine state_machine, PlayerData data, string animation_flag):
    base(player, state_machine, data, animation_flag)
    {}

    public override void Enter()
    {
        base.Enter();

        dash_time_last = data.dash_time;
        dash_direction = player.input_handler.mouse_direction.normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (dash_time_last > 0)
        {
            player.anim.SetFloat("move_x", dash_direction.x);
            player.anim.SetFloat("move_y", dash_direction.y);
            player.TryFlip(dash_direction);

            player.Move(data.dash_speed * dash_direction.x, data.dash_speed * dash_direction.y);
            dash_time_last -= Time.deltaTime;
        }

        else
            is_cast_finished = true;

        if (is_cast_finished)
            state_machine.ChangeState(player.state_idle);
    }
}
