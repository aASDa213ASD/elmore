using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerStateGrounded
{
    public PlayerStateIdle(Player player, PlayerStateMachine state_machine, PlayerData data, string animation_flag):
    base(player, state_machine, data, animation_flag)
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
            state_machine.ChangeState(player.state_move);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
