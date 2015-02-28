using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	// GUI描写
	private void OnGUI() {
		// スコア表示
		scoreText.text = "Score : " + GameManager.getScore();
	}
}
