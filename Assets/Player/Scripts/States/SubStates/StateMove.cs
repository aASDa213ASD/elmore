using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : StateGrounded
{
    public float stopping_distance = 0.1f;
    public float move_point_dissapear_distance = 0.35f;

    private Vector3 move_point_position;

    public StateMove(Player player, Statectl statectl, CreatureData data, string animation_flag):
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

        if (player.GetTarget() && movement_location == player.GetTarget().transform.position)
            stopping_distance = 0.5f;
        else
            stopping_distance = 0.1f;

        if (Vector3.Distance(movement_location, player.transform.position) > stopping_distance)
        {
            movement_direction = movement_direction.normalized;

            player.anim.speed = 1.0f * (data.speed / 100.0f);
            player.anim.SetFloat("direction_x", movement_direction.x);
            player.anim.SetFloat("direction_y", movement_direction.y);

            player.TryFlip(movement_direction);

            //player.navigation_agent.speed = data.speed / 100;
            //player.navigation_agent.SetDestination(movement_location);
            player.navigation_agent.stoppingDistance = stopping_distance;
            player.Move(movement_location);

            /*
            player.Move(
                movement_direction.x * (data.speed / 100),
                movement_direction.y * (data.speed / 100)
            );
            */
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

        if ((!player.GetTarget() || player.GetTarget() && movement_location != player.GetTarget().transform.position) && Vector3.Distance(movement_location, player.transform.position) > move_point_dissapear_distance)
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
