using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public Image bar;
    public UnityEvent onDeath;

    int currentHealth;

    private void Start() 
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(int damage)
    {
        if(damage < 0 && currentHealth == maxHealth)
        {
            return false; //didn't heal, because health is already full
        }

        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);
       //currentHealth = currentHealth < 0 ? 0 : currentHealth;

        bar.transform.localScale = new Vector3((float)currentHealth / maxHealth, 1, 1);

        if(currentHealth == 0)
        {
            onDeath.Invoke();
        }

        return true;
    }
}
