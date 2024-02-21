using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player             player;
    protected PlayerData         data;
    protected PlayerStateMachine state_machine;
    protected float              start_time;
    private string               animation_flag;

    public PlayerState(Player player, PlayerStateMachine state_machine, PlayerData data, string animation_flag)
    {
        this.player         = player;
        this.state_machine  = state_machine;
        this.data           = data;
        this.animation_flag = animation_flag;
    }

    public virtual void Enter()
    {
        DoChecks();
        
        player.anim.SetBool(animation_flag, true);
        start_time = Time.time;

        Debug.Log(animation_flag);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animation_flag, false);
    }

    public virtual void LogicUpdate() {}

    public virtual void PhysicsUpdate() {}

    public virtual void DoChecks() {}
}
