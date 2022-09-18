using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float shotInterval;
    [SerializeField] private float shotDelay = 1.5f;
    [SerializeField] private float speed;
    [SerializeField] private int HP = 3;
    public GameObject projectilePrefab;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", shotDelay, shotInterval);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Shoot() //shoots a spread of 3 bullets
    {
        Instantiate(projectilePrefab, transform.position , transform.rotation);
        var bullet2 = Instantiate(projectilePrefab, transform.position, transform.rotation);
        bullet2.transform.Rotate(0, 20, 0);
        var bullet3 = Instantiate(projectilePrefab, transform.position, transform.rotation);
        bullet3.transform.Rotate(0, -20, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            HP--;
            Destroy(other.gameObject);
            if (HP <= 0)
            {
                Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
