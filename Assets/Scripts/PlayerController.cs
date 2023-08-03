using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 12.0f;
    private Rigidbody playerRb;
    public GameObject projectilePrefab;
   // public Renderer playerColor;
    float xRange = 28.75f;
    float zRange = 16.0f;
    public int playerHP = 3;
    public AudioSource damagedSound; //sound that plays when player takes damage
    public AudioSource shootSound; //sound that plays when bullet is fired


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
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);  
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput); 

        //shoots bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
          shootSound.Play(); //plays shooting audio clip
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

        if (Input.GetKeyDown(KeyCode.Escape)) //goes back to menu when press esc
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnTriggerEnter(Collider other) //damages player when touching a enemy bullet or ship, destroys the enemey ship/bullet that damaged the player
    {
        if (other.CompareTag("enemy") || other.CompareTag("danger"))
        {
 
            damagedSound.Play(); //plays damaged audio clip
            playerHP--;
            Destroy(other.gameObject);
            if (playerHP <= 0) //if player hp reaches 0 destroy the player
            {
                Destroy(gameObject);
            }

        }
     }
        
}




