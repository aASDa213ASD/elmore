using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Data.Common;

public class CreatureTag : MonoBehaviour
{
    public MonoBehaviour creature;

    public TextMeshProUGUI name_tag;
    public Vector3 name_offset;

    public TextMeshProUGUI title_tag;
    public Vector3 title_offset;

    void Start()
    {   
        ICreature data = creature.GetComponent<ICreature>();

        name_tag.text   = data.creature_name;
        name_tag.color  = data.name_color;
        title_tag.text  = data.creature_title;
        title_tag.color = data.title_color;
    }

    void FixedUpdate()
    {
        name_tag.transform.position = Camera.main.WorldToScreenPoint(creature.transform.position + name_offset);
        title_tag.transform.position = Camera.main.WorldToScreenPoint(creature.transform.position + title_offset);
    }
}
