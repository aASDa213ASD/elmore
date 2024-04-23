using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms;
using System;

public class Creature : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Creature      target        { get; private set; }
    public Animator      anim          { get; private set; }
    public Rigidbody2D   rigid_body    { get; private set; }

    public string creature_name  { get; private set; }
    public string creature_title { get; private set; }
    public Color  name_color     { get; private set; }
    public Color  title_color    { get; private set; }

     public event Action<Creature> OnTargetChanged;
    public NavMeshAgent navigation_agent;

    [SerializeField]
    public CreatureData data;

    protected bool is_hovered;
    protected bool facing_direction;
    protected Vector2 velocity;
    protected OutlineFx.OutlineFx outline;
    
    private Player local_player;

    public virtual void Awake()
    {
        creature_name  = data.creature_name;
        creature_title = data.creature_title;

        name_color  = data.name_color;
        title_color = data.title_color;
    }

    public virtual void Start()
    {
        rigid_body    = GetComponent<Rigidbody2D>();
        anim          = GetComponent<Animator>();
        outline       = GetComponent<OutlineFx.OutlineFx>();

        local_player = FindFirstObjectByType<Player>();
        facing_direction = true; // false -> left, true -> right
    }

    public virtual void Update() {}

    public virtual void FixedUpdate() {}

    public virtual void LateUpdate()
    {
        if (local_player.GetTarget() == this || is_hovered)
        {
            outline.Color = local_player.GetTarget() == this ? data.outline_target_color : data.outline_hover_color;
            outline.Alpha = local_player.GetTarget() == this ? 1f : 0.9f;
        }
        else if (!is_hovered)
        {
            outline.Alpha = 0.1f;
        }
    }

    private void Flip()
    {
        facing_direction = !facing_direction;
        
        Vector3 current_scale = gameObject.transform.localScale;
        current_scale.x *= -1;
        gameObject.transform.localScale = current_scale;
    }

    public void Move(Vector3 location)
    {
        navigation_agent.speed = data.speed / 100;
        navigation_agent.SetDestination(location);
    }

    public void Move(float x, float y)
    {
        velocity.Set(x, y);
        rigid_body.velocity = velocity;
    }

    public void Stop()
    {
        velocity.Set(0f, 0f);
        rigid_body.velocity = velocity;
    }

    public void TryFlip(Vector2 input)
    {
        if (facing_direction && input.x < 0)
            Flip();
        
        else if (!facing_direction && input.x > 0)
            Flip();
    }

    public void SetTarget(Creature creature)
    {
        target = creature;
        OnTargetChanged?.Invoke(target);
    }

    public void ResetTarget()
    {
        target = null;
        OnTargetChanged?.Invoke(target);
    }

    public MonoBehaviour GetTarget()
    {
        return target;
    }

    public void OnPointerEnter(PointerEventData event_data)
    {
        is_hovered = true;
    }

    public void OnPointerExit(PointerEventData event_data)
    {
        is_hovered = false;
    }
}
