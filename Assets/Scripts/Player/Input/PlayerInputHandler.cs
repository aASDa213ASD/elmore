using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInputHandler : MonoBehaviour
{
    private Camera cam;

    public Vector2 movement_input   { get; private set; }
    public Vector2 mouse_direction  { get; private set; }
    public bool    dash_input       { get; private set; }
    public bool    sit_input        { get; private set; }

    private void Start()
    {
        cam = Camera.main;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movement_input = context.ReadValue<Vector2>();
        movement_input = movement_input.normalized;
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
            dash_input = true;
        else if (context.canceled)
            dash_input = false;
    }

    public void OnSitInput(InputAction.CallbackContext context)
    {
        if (context.started)
            sit_input = true;
        else if (context.canceled)
            sit_input = false;  
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {   
        mouse_direction = context.ReadValue<Vector2>();
        mouse_direction = cam.ScreenToWorldPoint((Vector3)mouse_direction) - transform.position;
    }

    public void UseDashInput() => dash_input = false;
}
