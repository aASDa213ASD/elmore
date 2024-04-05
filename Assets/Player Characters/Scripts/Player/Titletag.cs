using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Titletag : MonoBehaviour
{
    public TextMeshProUGUI title_tag;
    public Player target;
    public Vector3 offset;

    void Start()
    {
        title_tag.text = target.character_title;
        title_tag.color = target.title_color;
    }

    void Update()
    {
        title_tag.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + offset);
    }
}
