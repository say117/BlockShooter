using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	public GameObject explosion;
	private int colorType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 物体との衝突時に呼び出される
	private void OnCollisionEnter(Collision collision) {
		// 衝突物のタグがballだったら爆発させて消滅
		if (collision.transform.tag == "Ball") {
			// 色の判定
			GameObject.Find("GameManager").GetComponent<GameManager>().judgeColor(colorType);	// GameManagerオブジェクトのスクリプト内メソッドを呼び出す
			//エフェクトを出しつつ消滅
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	// 色をセットするためのメソッド
	public void setColor(int colorType) {
		this.colorType = colorType;
	}	
}
