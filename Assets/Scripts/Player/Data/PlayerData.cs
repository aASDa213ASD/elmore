using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movement_speed = 5.0f;

    [Header("Dash State")]
    public float dash_cooldown  = 1.0f;
    public float dash_duration  = 0.2f;
    public float dash_speed     = 15.0f;
    public float ghosting       = 0.5f;
}
