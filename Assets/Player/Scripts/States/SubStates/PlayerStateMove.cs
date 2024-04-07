using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove : PlayerStateGrounded
{
    Vector3 move_point_position;

    public PlayerStateMove(Player player, PlayerStatectl statectl, CreatureData data, string animation_flag):
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

            player.anim.speed = 1.0f * (data.speed / 100.0f);
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
            player.move_point_indicator.gameObject.SetActive(false);
            statectl.ChangeState(player.state_idle);
        }
    }

    public override void LastUpdate()
    {
        base.LastUpdate();

        if (Vector3.Distance(movement_location, player.transform.position) > 0.2f)
        {
            move_point_position = movement_location;
            move_point_position.y -= 0.25f;

            player.move_point_indicator.position = move_point_position;
            player.move_point_indicator.gameObject.SetActive(true);
        }
        else
        {
            player.move_point_indicator.gameObject.SetActive(false);
        }
    }
}
