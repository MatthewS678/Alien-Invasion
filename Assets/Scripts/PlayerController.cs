using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 12.0f;
    private Rigidbody playerRb;
    public GameObject projectilePrefab;
    float xRange = 25.75f;
    float zRange = 16.0f;
    public int playerHP = 3;
   


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //moves player
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);  //originally forward
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput); //orginally right

        //shoots bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
          Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        
        //constrains movement
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("danger"))
        {
            playerHP--;
            Destroy(other.gameObject);
            if (playerHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    //add an abort
}
