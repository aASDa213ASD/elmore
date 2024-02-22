using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateGrounded
{
    public PlayerStateIdle(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
    base(player, statectl, data, animation_flag)
    {}

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.Stop();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (input != Vector2.zero)
            statectl.ChangeState(player.state_move);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
