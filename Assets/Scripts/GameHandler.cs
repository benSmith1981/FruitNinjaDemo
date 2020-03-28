using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    string helloMessage = "";
    int score = 0;

    public Sprite[] foodSprites;
    public Text currentScore;
    public Text gameMessage;


    // Start is called before the first frame update
    void Start()
    {
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


        }
        updateScore(1);
        updateGameMessage();
    }

    void updateScore(int amountToAdd)
    {
        score = score + amountToAdd;
        Debug.Log("updateScore" + score);
        currentScore.text = "Score: " + score;
    }

    void updateGameMessage()
    {
        Debug.Log("updateGameMessage");

        if (shouldUpdateGameMessage())
        {
            Debug.Log("Show Score");

            gameMessage.text = determineGameMessage();
            gameMessage.enabled = true;
            Invoke("hideMessage", 1f);
        }
    }

    bool shouldUpdateGameMessage()
    {
        return (score % 100 == 0) || (score < 100);
    }

    void hideMessage()
    {
        gameMessage.enabled = false;
    }

    string determineGameMessage()
    {
        Debug.Log("determineGameMessage");

        if (score < 100)
        {
            return "Keep Going! " + score;
        } else if(score >= 100)
        {
            return "Well done! Great score " + score;
        }
        Debug.Log("DEFAULT");
        return "DEFAULT";
    }

}