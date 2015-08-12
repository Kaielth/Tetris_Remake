using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	// Properties
	public int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Increase the player score according to the lines deleted by the user play
	// Lines	-	Points
	// 1		-	1
	// 2		-	4
	// 3		-	9
	// 4		-	16
	public void setScore(int lines)
	{
		switch (lines)
		{
		case 1:
			score += 1;
			break;
		case 2:
			score += 4;
			break;
		case 3:
			score += 9;
			break;
		case 4:
			score += 16;
			break;
		}
		scoreText.text = "Score: " + score;
	}
}
