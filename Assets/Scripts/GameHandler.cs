using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    string helloMessage = "Hello";
    int score = 0;

    public Sprite[] foodSprites;
    //public Text currentScore;
    //public Text gameMessage;

    CanvasScript newCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //we get the script that is a component of GameHandler
        newCanvas = GetComponent<CanvasScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            spawnSprites();
        }
    }

    void spawnSprites()
    {
        foreach (Sprite currentSprite in foodSprites)
        {
            GameObject food = new GameObject("item", typeof(SpriteRenderer));
            food.GetComponent<SpriteRenderer>().sprite = currentSprite;
            food.transform.localScale = new Vector3(0.2F, 0.2F);
            food.transform.position = new Vector3(0, 2);

            food.AddComponent<Rigidbody2D>();
            food.AddComponent<BoxCollider2D>();

            updateScoreTextInGame();
        }
    }

    void updateScoreTextInGame()
    {
        if (score % 100 == 0)
        {
            newCanvas.showInGameMessage("WOW!", newCanvas.gameMessage);
        }
        newCanvas.currentScore.text = "Score: " + score++;
    } 

}