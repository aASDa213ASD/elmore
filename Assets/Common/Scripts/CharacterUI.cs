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

    private Player local_player;

    void Start()
    {
        local_player = FindFirstObjectByType<Player>();
        character_name.text = local_player.data.creature_name;
    }

    void Update()
    {
        healthbar_slider.value = local_player.health_current;
        healthbar_slider.maxValue = local_player.health_max;
        healthbar_text.text = local_player.health_current.ToString() + '/' + local_player.health_max.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        local_player.SetTarget(local_player);
    }
}
