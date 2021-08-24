using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    public void TakeDamage()
    {
        Health.currentHealth -= damage;
    }
}
