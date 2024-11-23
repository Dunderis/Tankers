using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explossive : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject destroyedVersion;
    
    private List<GameObject> inRange = new List<GameObject>();

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) {
            inRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player")) {
            inRange.Remove(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Bullet")) 
        {
            Explode();
        }
    }

    private void Explode() 
    {
        var pos = transform.position;
        pos.y = -0.49f;
        Instantiate(explosionEffect, transform.position, transform.rotation);

        foreach (GameObject obj in inRange) 
        {
            obj.GetComponent<Health>().TakeDamage(1);
        }
        Instantiate(destroyedVersion, pos, destroyedVersion.transform.rotation);
        Destroy(gameObject);
    }
}
