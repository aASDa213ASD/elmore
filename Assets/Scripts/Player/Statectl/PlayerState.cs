using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player             player;
    protected PlayerData         data;
    protected PlayerStatectl     statectl;
    protected float              start_time;
    private string               animation_flag;

    public PlayerState(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag)
    {
        this.player         = player;
        this.statectl       = statectl;
        this.data           = data;
        this.animation_flag = animation_flag;
    }

    public virtual void Enter()
    {
        DoChecks();
        
        player.anim.SetBool(animation_flag, true);
        start_time = Time.time;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animation_flag, false);
    }

    public virtual void LogicUpdate() {}

    public virtual void PhysicsUpdate() {}

    public virtual void DoChecks() {}
}
