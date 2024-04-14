using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void Damage(float amount);

    void Die();

    float health_max { get; set; }
    float health_current { get; set; }
}
