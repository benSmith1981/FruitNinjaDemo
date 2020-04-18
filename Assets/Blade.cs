using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    //CircleCollider2D cl;
    public GameObject bladeTrailPrefab;
    GameObject currentBladeTrail;

    bool isCutting;
    // Start is called before the first frame update
    void Start()
    {
        TrailRenderer tr = GetComponent<TrailRenderer>();
        //tr.sortingLayerName = "Foreground";
        //rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCutting = true;
            currentBladeTrail = Instantiate(bladeTrailPrefab, transform);

            //cl.enabled = isCutting;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isCutting = false;
            //cl.enabled = isCutting;
            currentBladeTrail.transform.SetParent(null);
            Destroy(currentBladeTrail, 0.5f);
        }

        if (isCutting)
        {
            updateCut();
        }
    }

    void updateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        //rb.transform.position = newPosition;
        transform.position = newPosition;
    }
}