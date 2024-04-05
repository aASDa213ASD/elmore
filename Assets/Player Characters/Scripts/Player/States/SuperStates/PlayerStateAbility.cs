using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAbility : PlayerState
{
    public PlayerStateAbility(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
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

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
