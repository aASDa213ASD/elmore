using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAbility : PlayerState
{
    protected bool is_cast_finished;

    public PlayerStateAbility(Player player, PlayerStateMachine state_machine, PlayerData data, string animation_flag):
    base(player, state_machine, data, animation_flag)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        is_cast_finished = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
