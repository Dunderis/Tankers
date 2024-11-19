using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        var health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            //negative damage = healing
            health.TakeDamage(-10);
            Destroy(gameObject);
        }
    }
}
