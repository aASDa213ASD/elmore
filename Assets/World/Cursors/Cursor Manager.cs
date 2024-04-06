using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursor_texture_default;
    [SerializeField] private Vector2 click_position = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursor_texture_default, click_position, CursorMode.Auto);
    }
}
