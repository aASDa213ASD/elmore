using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Info")]
    public string character_name = "Player";
    public Color name_color = new Color(255f, 255f, 255f);
    public string character_title = "";
    public Color title_color = new Color(119f, 255f, 255f);

    [Header("Stats")]
    public float speed = 2f;
}
