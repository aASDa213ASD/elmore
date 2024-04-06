using UnityEngine;

[CreateAssetMenu(fileName = "CreatureData", menuName = "Data/Creature Data/Base Data")]
public class CreatureData : ScriptableObject, ICreature
{
    [Header("Info")]
    [SerializeField] private string _character_name = "Unnamed";
    public string creature_name { get { return _character_name; } set { _character_name = value; } }

    [SerializeField] private Color _name_color = new Color(255, 255, 255);
    public Color name_color { get { return _name_color; } set { _name_color = value; } }

    [SerializeField] private string _character_title = "";
    public string creature_title { get { return _character_title; } set { _character_title = value; } }

    [SerializeField] private Color _title_color = new Color(119, 255, 255);
    public Color title_color { get { return _title_color; } set { _title_color = value; } }

    [Header("Stats")]
    public float speed = 100f;
}