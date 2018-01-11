using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
    public int health = 1;

    
    private void OnTriggerEnter2D()
    {
        health--;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
