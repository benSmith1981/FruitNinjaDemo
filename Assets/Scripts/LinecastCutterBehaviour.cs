using UnityEngine;
using System.Collections.Generic;
using UnitySpriteCutter;
using System;
using UnityEngine.UI;

public class LinecastCutterBehaviour : MonoBehaviour {

	public LayerMask layerMask;
	Vector2 oldPosition;
	public float minCuttingVel = 0.008f;
	Vector2 mouseStart;

	public Text currentScore;
	public Text gameMessage;
	int score = 0;

	void Update() {

        if (Input.GetMouseButtonDown(0))
        {
			mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector2 mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float velocity = (mouseEnd - oldPosition).magnitude * Time.deltaTime;
		//Debug.Log("velocity: " + velocity);
        if ((velocity > minCuttingVel) && Input.GetMouseButton(0))
        {
			LinecastCut(mouseStart, mouseEnd, layerMask.value);
		}
		oldPosition = mouseEnd;

	}

	void LinecastCut( Vector2 lineStart, Vector2 lineEnd, int layerMask = Physics2D.AllLayers ) {
		List<GameObject> gameObjectsToCut = new List<GameObject>();
		RaycastHit2D[] hits = Physics2D.LinecastAll( lineStart, lineEnd, layerMask );
		foreach ( RaycastHit2D hit in hits ) {
			if ( HitCounts( hit ) ) {
				gameObjectsToCut.Add( hit.transform.gameObject );
				
			}
		}

		score += gameObjectsToCut.Count;
		currentScore.text = "Score: " + score;
		foreach ( GameObject go in gameObjectsToCut ) {
			SpriteCutterOutput output = SpriteCutter.Cut( new SpriteCutterInput() {
				lineStart = lineStart,
				lineEnd = lineEnd,
				gameObject = go,
				gameObjectCreationMode = SpriteCutterInput.GameObjectCreationMode.CUT_OFF_COPY,
			} );
			Destroy(output.firstSideGameObject, 5f);
			Destroy(output.secondSideGameObject, 5f);

		}
	}

    bool HitCounts( RaycastHit2D hit ) {
		return ( hit.transform.GetComponent<SpriteRenderer>() != null ||
		         hit.transform.GetComponent<MeshRenderer>() != null );
	}

}
