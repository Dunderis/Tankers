using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public static int damage = 10;
    public float speed = 15f;
    public float lifeTime = 2f;

    void Start()
    {
        Invoke("SelfDestruct", lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) 
    {
        SelfDestruct();
    }

    void SelfDestruct()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
