using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 20f;
    public float lifetime = 2f;

    void Start()
    {
        Invoke("SelfDestruct", lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(10);
        }
        SelfDestruct();
    }

    void SelfDestruct()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
