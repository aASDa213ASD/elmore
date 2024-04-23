using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetUI : MonoBehaviour
{
    public GameObject target_window;
    public TextMeshProUGUI target_name;
    public Slider healthbar_slider;

    private Player local_player;
    private Creature target;

    void Start()
    {
        //local_player = Player.Instance;
        local_player = FindFirstObjectByType<Player>();
        local_player.OnTargetChanged += UpdateTargetUI;
        target_window.SetActive(false);
    }

    void UpdateTargetUI(Creature target)
    {
        if (target != null)
        {
            target_name.text = target.creature_name;
            if (target is Monster)
            {
                Monster monster = target as Monster;

                healthbar_slider.value = monster.health_current;
                healthbar_slider.maxValue = monster.health_max;
                healthbar_slider.transform.parent.gameObject.SetActive(true);
            }
            else
                healthbar_slider.transform.parent.gameObject.SetActive(false);

            target_window.SetActive(true);
        }
        else
        {
            target_window.SetActive(false);
        }
    }

    void Update()
    {  
        /*
        if (local_player.GetTarget())
            target = local_player.GetTarget().GetComponent<Creature>();

        if (local_player.GetTarget() && target)
        {   
            target_name.text = target.creature_name;

            if (target is Monster)
            {
                Monster monster = target as Monster;

                healthbar_slider.value = monster.health_current;
                healthbar_slider.maxValue = monster.health_max;
                healthbar_slider.transform.parent.gameObject.SetActive(true);
            }
            else
                healthbar_slider.transform.parent.gameObject.SetActive(false);

            target_window.SetActive(true);
        }
        else
        {
            target_window.SetActive(false);
        }
        
        //healthbar_slider.value = Player.Instance.health_current;
        //healthbar_slider.maxValue = Player.Instance.health_max;
        //healthbar_text.text = Player.Instance.health_current.ToString() + '/' + Player.Instance.health_max.ToString();
        */
    }
}