using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameWin = false;
    Vector3 playerSpawnPos = new Vector3(0, 0.5f, 0);
    public GameObject player;
    public PlayerController controller;
    public SpawnManager spawnManager;
    public Boundary boundary;
    public TextMeshProUGUI playerHPText;
    public Button playButton;
    public Button tutorialButton;
    public Button quitButton;
    public Button menuButton;
    public TextMeshProUGUI winText;    
    public TextMeshProUGUI loseText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "HP: " + controller.playerHP; //player HP text display

        if(controller.playerHP == 2)
        {
            playerHPText.color = Color.yellow;
        }

        if (controller.playerHP == 1)
        {
            playerHPText.color = Color.red;
        }

        if (controller.playerHP <= 0 || boundary.EarthDestroyed)
        {
            gameOver = true;
        }

        if(spawnManager.enemiesSpawned >= 50)
        {
            gameWin = true;
        }

        if (gameOver) //player hp <=0 or alien reaches Earth
        {
            SceneManager.LoadScene(2);  
        }

        if (gameWin) //player destroys certain # of ships  
        {
            SceneManager.LoadScene(3);
        }

    }

    public void StartGame() //start button, resets and instantiates spawnmanagers variables again
    {
        SceneManager.LoadScene(1);
        //Instantiate(player, playerSpawnPos, Quaternion.Euler(0f, 0f, 0f));
        spawnManager.enemiesSpawned = 0;
        spawnManager.enemyVariety = 2; //index 1 and 2 are fighters, index 3 is destroyer
        spawnManager.enemyCap = 5;
        spawnManager.spawnInterval = 3.0f;
        
    }

    public void BackToMenu() //menu button
    {
        SceneManager.LoadScene(0);
    }

    public void Quit() //quit button
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    public void Instructions() // instructions button
    {
        SceneManager.LoadScene(4);
    }
}
