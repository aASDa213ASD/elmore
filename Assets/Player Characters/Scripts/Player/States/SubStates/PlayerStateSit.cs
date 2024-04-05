using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateSit : PlayerStateGrounded
{   
    private float animation_delay = 2f;
    private float stand_up_time = 0f;
    private float sit_down_time = 0f;

    public PlayerStateSit(Player player, PlayerStatectl statectl, PlayerData data, string animation_flag):
    base(player, statectl, data, animation_flag) {}

    public override void Enter()
    {
        base.Enter();
        
        sit_down_time = Time.time + animation_delay;
        //player.anim.SetFloat("move_x", input.x);
        //player.anim.SetFloat("move_y", input.y);
        //player.TryFlip(input);
        player.Stop();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        if (player.rigid_body.velocity != Vector2.zero)
            player.Stop();
        
        if (player.input_handler.sit_input && Time.time > sit_down_time)
        {
            stand_up_time = Time.time + animation_delay;
            player.anim.SetBool("sit", false);
        }

        if (!player.anim.GetBool("sit") && Time.time > stand_up_time)
            statectl.ChangeState(player.state_idle);
    }
}