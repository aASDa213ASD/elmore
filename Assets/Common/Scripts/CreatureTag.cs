using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Data.Common;

public class CreatureTag : MonoBehaviour
{
    public TextMeshProUGUI name_tag;
    public Vector3 name_offset;

    public TextMeshProUGUI title_tag;
    public Vector3 title_offset;

    private Creature creature;

    void Awake()
    {
        GameObject player_object = this.transform.parent.gameObject;
        creature = player_object.GetComponent<Creature>();
    }

    void Start()
    {   
        name_tag.text   = creature.creature_name;
        name_tag.color  = creature.name_color;

        title_tag.text  = creature.creature_title;
        title_tag.color = creature.title_color;
    }

    void FixedUpdate()
    {
        name_tag.transform.position = Camera.main.WorldToScreenPoint(creature.transform.position + name_offset);
        title_tag.transform.position = Camera.main.WorldToScreenPoint(creature.transform.position + title_offset);
    }
}
