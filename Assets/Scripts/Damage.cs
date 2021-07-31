using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.anyKey) {
            TakeDamage();
        }*/
    }

    public void TakeDamage()
    {
        Health.currentHealth -= damage;
    }
}
