using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text scoreText;

	void Awake(){
		scoreText = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = System.String.Format("{0:D6}", score);
	}
}
