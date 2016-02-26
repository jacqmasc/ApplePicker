using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int score = 1000;

	void Awake()
	{
		//Check if the player has a high score in preferances
		if (PlayerPrefs.HasKey ("ApplePickerHighScore")) 
		{ score = PlayerPrefs.GetInt("ApplePickerHighScore"); }
		
		//set high score in preferances
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
	}

	void Update()
	{
		GUIText gt = this.GetComponent<GUIText> ();
		gt.text = "High Score: " + score;

		//Update high score in prefs if needed
		if (score > PlayerPrefs.GetInt ("ApplePickerHighScore")) 
		{ PlayerPrefs.SetInt("ApplePickerHighScore", score); }
	}
}
