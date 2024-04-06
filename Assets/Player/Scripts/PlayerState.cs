using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player             player;
    protected CreatureData       data;
    protected PlayerStatectl     statectl;
    protected float              start_time;
    private string               animation_flag;

    public PlayerState(Player player, PlayerStatectl statectl, CreatureData data, string animation_flag)
    {
        this.player   = player;
        this.statectl = statectl;
        this.data     = data;
        this.animation_flag = animation_flag;
    }

    public virtual void Enter()
    {
        //Debug.Log("Entered state: " + statectl.current_state);
        player.anim.SetBool(animation_flag, true);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animation_flag, false);
    }

    public virtual void FrameUpdate() {}

    public virtual void PhysicsUpdate() {}

    public virtual void LastUpdate() {}

    public virtual void AnimationTriggerEvent() {}
}
