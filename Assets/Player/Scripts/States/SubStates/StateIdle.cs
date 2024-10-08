using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : StateGrounded
{
    public StateIdle(Player player, Statectl statectl, CreatureData data, string animation_flag):
    base(player, statectl, data, animation_flag) {}

    public override void Enter()
    {
        base.Enter();
        
        player.Stop();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        if (Vector3.Distance(movement_location, player.transform.position) > player.state_move.stopping_distance)
            statectl.ChangeState(player.state_move);
    }
}
