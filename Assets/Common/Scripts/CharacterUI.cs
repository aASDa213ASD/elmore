using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterUI : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI character_name;
    public Slider healthbar_slider;
    public TextMeshProUGUI healthbar_text;

    void Start()
    {
        character_name.text = Player.Instance.data.creature_name;
    }

    void Update()
    {
        healthbar_slider.value = Player.Instance.health_current;
        healthbar_slider.maxValue = Player.Instance.health_max;
        healthbar_text.text = Player.Instance.health_current.ToString() + '/' + Player.Instance.health_max.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Player.Instance.SetTarget(Player.Instance);
    }
}
