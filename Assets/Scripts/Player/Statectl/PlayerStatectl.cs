using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatectl
{
    public PlayerState current_state { get; private set; }

    public void Initialize(PlayerState initial_state)
    {
        current_state = initial_state;
        current_state.Enter();
    }

    public void ChangeState(PlayerState new_state)
    {
        current_state.Exit();
        current_state = new_state;
        current_state.Enter();
    }
}
