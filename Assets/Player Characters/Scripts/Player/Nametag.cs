using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Nametag : MonoBehaviour
{
    public TextMeshProUGUI name_tag;
    public Player target;
    public Vector3 offset;

    void Start()
    {
        name_tag.text = target.character_name;
        name_tag.color = target.name_color;
    }

    void Update()
    {
        name_tag.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + offset);
    }
}
