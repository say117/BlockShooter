using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			// ボールプレハブのインスタンス化
			GameObject ballInstance = Instantiate(ball, gameObject.transform.position, gameObject.transform.rotation) as GameObject;

			// クリックした点をワールド座標系に変換
			Vector3 screenPoint = Input.mousePosition;
			screenPoint.z = 10.0f;
			Vector3 worldPoint = camera.ScreenToWorldPoint(screenPoint);

			// クリックした点へ向かうベクトルを速度ベクトルとして設定
			Vector3 direction = (worldPoint - transform.position).normalized;
			ballInstance.rigidbody.velocity = direction * 30;
		}
	}
}
