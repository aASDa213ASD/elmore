using UnityEngine;

public class Monster : Creature, IDamagable
{
    public float health_max { get; set;  }
    public float health_current { get; set; }

    public override void Awake()
    {
        base.Awake();

        health_max = data.health_max;
        health_current = data.health_current;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public void Damage(float amount)
    {
        health_current -= amount;

        if (health_current < 0)
            health_current = 0;
        
        if (health_current == 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
