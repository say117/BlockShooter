using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 物体との衝突時に呼び出される
	private void OnCollisionEnter(Collision collision) {
		// 衝突物したら消滅
		Destroy(gameObject);
	}
}
