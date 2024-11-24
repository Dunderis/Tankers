using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //todo: explosion effect
        //todo: damage enemy
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
            health.LoadEnd();
        }
        
        SelfDestruct();
    }   

    void SelfDestruct()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
}
