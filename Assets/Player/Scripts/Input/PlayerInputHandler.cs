using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerInputHandler : MonoBehaviour
{
    public Player player;
    public Vector3 movement_location { get; set; }
    public Vector2 mouse_position    { get; private set; }
    public bool    sit_input         { get; private set; }

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Ray ray = cam.ScreenPointToRay(mouse_position);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Creatures", "UI"));

            if (hit.collider != null)
            {
                Creature creature = hit.collider.GetComponent<Creature>();
                if (creature != null)
                {
                    if (player.GetTarget() != creature)
                    {
                        player.SetTarget(creature);
                    }
                    else
                    {
                        if (creature != player)
                            movement_location = creature.transform.position;
                    }
                }
            }
            else
            {
                movement_location = cam.ScreenToWorldPoint(mouse_position);
            }
        }
    }

    public void OnMovePositionInput(InputAction.CallbackContext context)
    {
        mouse_position = context.ReadValue<Vector2>();
    }

    public void OnCancelInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (player.statectl.current_state == player.state_move)
            {
                movement_location = player.transform.position;
                return;
            }

            if (player.GetTarget())
            {
                player.ResetTarget();
                return;
            }
        }
    }

    /*
    public void OnSitInput(InputAction.CallbackContext context)
    {
        if (context.started)
            sit_input = true;
        
        else if (context.canceled)
            sit_input = false;  
    }
    */
}
