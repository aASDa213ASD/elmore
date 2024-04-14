using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDeath : StateGrounded
{
    public StateDeath(Player player, Statectl statectl, CreatureData data, string animation_flag):
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
    }
}
