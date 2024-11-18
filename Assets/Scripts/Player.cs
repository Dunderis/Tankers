using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool player1 = true;

    [Header("Movement")]
    public float speed = 10f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;

    [Header("Health")]
    public Health health;


    void Start()
    {
        InvokeRepeating("Shoot", 0, fireRate);
    }

    void Shoot()
    {
        //todo:play sound
        //todo:play animation
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }

    void Update()
    {
        var input = new Vector3();

        if(player1)
        {
            input.x = Input.GetAxis("HorizontalKeys");
            //input.y = transform.position.y;
            input.z = Input.GetAxis("VerticalKeys");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrows");
            //input.y = transform.position.y;
            input.z = Input.GetAxis("VerticalArrows");
        }
        

        transform.position += input * speed * Time.deltaTime;

        if (input != Vector3.zero)
            transform.forward = input;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health.TakeDamage(Bullet.damage);
        }
        if(other.gameObject.CompareTag("Health"))
        {
            //negative damage = healing
            if(health.TakeDamage(-10))
                Destroy(other.gameObject);
        }
    }
}
