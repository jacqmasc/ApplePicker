using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
		
	public static float botomY = -20f;

	void Update()
	{
		if (transform.position.y < botomY) 
		{
			Destroy (this.gameObject); 

			//Call game controller if apple is dropped
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker> ();
			apScript.AppleDestroyed();
		}
	}
}
