using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float lifetime = 2.0f;
    public float speed = 15f;

    void Start()
    {
        Invoke("SelfDestruct", lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(10);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
