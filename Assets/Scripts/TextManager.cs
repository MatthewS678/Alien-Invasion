using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameWin) //game win screen
        {
            winText.gameObject.SetActive(true);
            loseText.gameObject.SetActive(false);
        }

        if (gameManager.gameOver) //game lose screen
        {
            winText.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
        }
    }
}