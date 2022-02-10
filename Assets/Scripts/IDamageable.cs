using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Health { get; }

    void SetHealth(float hp);
    void TakeDamage(float dmg);
    void HealDamage(float dmg);
}
