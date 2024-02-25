using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateDash : PlayerStateAbility
{   
    private Vector2 dash_direction;
    private float dash_time_window;
    private float dash_time_last;
    private float dash_duration;

    public PlayerStateDash(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
    base(player, statectl, data, animation_flag)
    {}

    public override void Enter()
    {
        dash_time_last   = Time.time;
        dash_duration    = data.dash_duration;
        
        // Mouse
        //dash_direction   = player.input_handler.mouse_direction.normalized;

        // Keyboard
        dash_direction   = player.input_handler.movement_input.normalized;

        if (dash_direction != Vector2.zero)
            base.Enter();
        else statectl.ChangeState(player.state_idle);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (dash_duration > 0)
        {
            player.anim.SetFloat("move_x", dash_direction.x);
            player.anim.SetFloat("move_y", dash_direction.y);
            player.TryFlip(dash_direction);

            player.Move(data.dash_speed * dash_direction.x, data.dash_speed * dash_direction.y);
            dash_duration -= Time.deltaTime;
        }
        else statectl.ChangeState(player.state_idle);
    }

    public bool IsAvailable()
    {
        return Time.time >= dash_time_last + data.dash_cooldown || dash_time_window > 0;
    }
}
