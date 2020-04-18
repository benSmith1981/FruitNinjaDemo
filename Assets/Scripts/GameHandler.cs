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

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;
    public float minDelay = 2f;
    public float maxDelay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            //spawnSprites();

        }
    }

    IEnumerator SpawnFruits(){
        while (true)
        {

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnFruit, 3f);
            //updateScore(1);
            //updateGameMessage();

        }
    }

    void spawnSprites()
    {
        foreach (Sprite currentSprite in foodSprites)
        {
            //GameObject food = new GameObject("item", typeof(SpriteRenderer));
            //food.GetComponent<SpriteRenderer>().sprite = currentSprite;
            //food.transform.localScale = new Vector3(0.2F, 0.2F);
            //food.transform.position = new Vector3(0, 2);

            //food.AddComponent<Rigidbody2D>();
            //food.layer = 8;

            //food.AddComponent<BoxCollider2D>();


        }
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