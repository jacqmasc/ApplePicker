using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;

	public float speed = 1f;

	public float leftAndRightEdge = 10f;

	public float chanceToChangeDirections = 0.1f;

	public float secondsBetweenAplleDrops = 1f;

	void Start()
	{
		//drop apples
		InvokeRepeating ("DropApple", 2f, secondsBetweenAplleDrops);
	}

	void DropApple()
	{
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}

	void Update()
	{
		//basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//change direction when edge is reached
		if (pos.x < -leftAndRightEdge) 
		{ speed = Mathf.Abs(speed); }
		else if( pos.x > leftAndRightEdge)
		{ speed = -Mathf.Abs(speed); }
	}

	void FixedUpdate()
	{
		//change direction randomly
		if (Random.value < chanceToChangeDirections)
		{ speed *= -1; }
	}
}
