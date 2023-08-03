using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float zRange = -2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //bullets travel foward

        if (transform.position.z < zRange)  //if projectile goes out of bounds destroys it
        {
            Destroy(gameObject);
        }


        if (transform.position.y < 0) //keeps projectiles above background
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
