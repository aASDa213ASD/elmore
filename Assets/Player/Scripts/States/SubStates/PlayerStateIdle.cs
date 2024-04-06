using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateGrounded
{
    public PlayerStateIdle(Player player, PlayerStatectl statectl, CreatureData data, string animation_flag):
    base(player, statectl, data, animation_flag) {}

    public override void Enter()
    {
        base.Enter();
        player.Stop();
        //player.move_point_indicator.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        if (Vector3.Distance(movement_location, player.transform.position) > 0.1f)
            statectl.ChangeState(player.state_move);
    }
}
