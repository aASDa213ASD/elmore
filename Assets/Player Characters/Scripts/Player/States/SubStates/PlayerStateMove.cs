using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : PlayerStateGrounded
{
    public PlayerStateMove(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
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

        if (Vector3.Distance(movement_location, player.transform.position) > 0.01f)
        {
            movement_direction = movement_direction.normalized;

            player.anim.SetFloat("direction_x", movement_direction.x);
            player.anim.SetFloat("direction_y", movement_direction.y);
            player.TryFlip(movement_direction);
            
            player.Move(
                movement_direction.x * (data.speed / 100),
                movement_direction.y * (data.speed / 100)
            );
        }
        else
        {
            statectl.ChangeState(player.state_idle);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
