using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public Image bar;
    public UnityEvent onDeath;

    private int health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(0, health);

        bar.transform.localScale = new Vector3((float)health / maxHealth, 1, 1);

        if(health <= 0)
        {
            print("Dead");
            //die
            onDeath.Invoke();
        }
    }
}