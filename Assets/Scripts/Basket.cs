using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText scoreGT;

	void Start()
	{
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreGT = scoreGO.GetComponent<GUIText> ();
		scoreGT.text = "0";
	}

	void Update()
	{
		//Get screen position from mouse inpu
		Vector3 mousePos2D = Input.mousePosition;

		//Set the z position
		mousePos2D.z = -Camera.main.transform.position.z;

		//Convert point from 2D screen space to 3D game space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		//Move x poistion of basket to mouse x position
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter( Collision coll)
	{
		//Find out what hit the basket
		GameObject collideWith = coll.gameObject;
		if (collideWith.tag == "Apple") 
		{ Destroy (collideWith); }

		//Score
		int score = int.Parse (scoreGT.text);
		score += 100;
		scoreGT.text = score.ToString();

		//Track high score
		if (score > HighScore.score) 
		{ HighScore.score = score; }
	}
}
