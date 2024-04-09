using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statectl
{
    public State current_state { get; private set; }

    public void Initialize(State initial_state)
    {
        current_state = initial_state;
        current_state.Enter();
    }

    public void ChangeState(State new_state)
    {
        if (current_state == new_state)
            return;
        
        current_state.Exit();
        current_state = new_state;
        current_state.Enter();
    }
}
