using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform bar;
    public int maxHealth = 100;

    private int health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        health = Mathf.Max(0, health);

        bar.localScale = new Vector3((float)health / maxHealth, 1, 1);

        if (health == 0)
        {
            print("I'm dead!");
        }
    }

}
