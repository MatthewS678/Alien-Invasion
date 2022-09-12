using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private float shotInterval;
    [SerializeField] private float shotDelay = 1.5f;
    [SerializeField] private float speed;
    public GameObject projectilePrefab;


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

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
