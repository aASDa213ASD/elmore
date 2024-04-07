using UnityEngine;

[CreateAssetMenu(fileName = "CreatureData", menuName = "Data/Creature Data/Base Data")]
public class CreatureData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] public string creature_name  = "Unnamed";
    [SerializeField] public string creature_title = "";
    [SerializeField] public Color name_color  = new Color(255, 255, 255);
    [SerializeField] public Color title_color = new Color(119, 255, 255);

    [Header("Stats")]
    public float speed = 100f;
}