using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySpriteCutter;

public class Fruit : MonoBehaviour
{
    public float startForce = 10f;
    Vector2 oldPosition;
    public float minCuttingVel = 0.008f;
    Vector2 mouseStart;
    Rigidbody2D rb;
    public LayerMask layerMask;


    private void Start()
    {
        gameObject.layer = 8;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}

        //Vector2 mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float velocity = (mouseEnd - oldPosition).magnitude * Time.deltaTime;
        ////Debug.Log("velocity: " + velocity);
        //if ((velocity > minCuttingVel) && Input.GetMouseButton(0))
        //{
        //    LinecastCut(mouseStart, mouseEnd, layerMask.value);
        //}
        //oldPosition = mouseEnd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D: ");
        rb.velocity = new Vector2(0,0);
        //if (collision.collider.tag == "Blade")
        //{
        //    Vector2 mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    float velocity = (mouseEnd - oldPosition).magnitude * Time.deltaTime;
        //    Debug.Log("velocity: " + velocity);
        //    if (Input.GetMouseButton(0))
        //    {
        //        if (velocity > minCuttingVel)
        //        {
        //            LinecastCut(mouseStart, mouseEnd, layerMask.value);
        //        }

        //    }
        //    oldPosition = mouseEnd;

        //}
    }
    //just what overlaps you...OVERLAP...90% time you use rthis
    private void OnTriggerEnter2D(Collider2D col)
    {
        rb.velocity = new Vector2(0, 0);

        Debug.Log("OnTriggerEnter2D: ");
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        //if (col.tag == "Blade")
        //{
        //    Vector2 mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    float velocity = (mouseEnd - oldPosition).magnitude * Time.deltaTime;
        //    Debug.Log("velocity: " + velocity);
        //    if (Input.GetMouseButton(0))
        //    {

        //        if (velocity > minCuttingVel)
        //        {
        //            LinecastCut(mouseStart, mouseEnd, layerMask.value);

        //        }

        //    }
        //    oldPosition = mouseEnd;

        //}
    }

    void LinecastCut(Vector2 lineStart, Vector2 lineEnd, int layerMask = Physics2D.AllLayers)
    {
        List<GameObject> gameObjectsToCut = new List<GameObject>();
        RaycastHit2D[] hits = Physics2D.LinecastAll(lineStart, lineEnd, layerMask);
        foreach (RaycastHit2D hit in hits)
        {
            if (HitCounts(hit))
            {
                gameObjectsToCut.Add(hit.transform.gameObject);

            }
        }

        foreach (GameObject go in gameObjectsToCut)
        {
            SpriteCutterOutput output = SpriteCutter.Cut(new SpriteCutterInput()
            {
                lineStart = lineStart,
                lineEnd = lineEnd,
                gameObject = go,
                gameObjectCreationMode = SpriteCutterInput.GameObjectCreationMode.CUT_OFF_COPY,
            });
        }
    }

    bool HitCounts(RaycastHit2D hit)
    {
        return (hit.transform.GetComponent<SpriteRenderer>() != null ||
                 hit.transform.GetComponent<MeshRenderer>() != null);
    }
}
