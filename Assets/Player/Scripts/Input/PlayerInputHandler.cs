using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInputHandler : MonoBehaviour
{
    private Camera cam;

    public Vector3 movement_location { get; set; }
    public Vector2 mouse_position    { get; private set; }
    public bool    sit_input         { get; private set; }

    private void Start()
    {
        cam = Camera.main;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
            movement_location = cam.ScreenToWorldPoint(mouse_position);
    }

    public void OnMovePositionInput(InputAction.CallbackContext context)
    {
        mouse_position = context.ReadValue<Vector2>();
    }

    public void OnSitInput(InputAction.CallbackContext context)
    {
        if (context.started)
            sit_input = true;
        
        else if (context.canceled)
            sit_input = false;  
    }
}
