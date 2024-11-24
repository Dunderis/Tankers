using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Transform healthBar;
    public int maxHealth = 100;

     int health;
    
    

    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        health = Mathf.Max(health, 0); // not less than 0
        health = Mathf.Min(health, maxHealth); // not more than maxHealth

        healthBar.localScale = new Vector3((float)health / maxHealth, 1, 1);
        
    }
    public void LoadEnd()
    {
        if (health == 0)
        {
            
            
            string name = gameObject.name;
            
                SceneManager.LoadScene("End1");
            
        }
    }
}
