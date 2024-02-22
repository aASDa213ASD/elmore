using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : PlayerStateGrounded
{
    public PlayerStateMove(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
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

        if (input != Vector2.zero)
        {
            player.anim.SetFloat("move_x", input.x);
            player.anim.SetFloat("move_y", input.y);
            player.TryFlip(input);

            player.Move(data.movement_speed * input.x, data.movement_speed * input.y);
        }

        else statectl.ChangeState(player.state_idle);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
