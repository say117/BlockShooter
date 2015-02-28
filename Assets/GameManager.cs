using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject redBox;
	public GameObject blueBox;
	public GameObject greenBox;
	public Text scoreText;
	public Text colorText;
	public Text timeText;
	
	private float timerForGenerating = 0;	// 箱生成のためのタイマー
	private float timerForChangingScoreColor = 0;	// 得点カラー変更のためのタイマー
	
	private static int score = 0;	// 得点
	private int scoreColor;	// スコアになる色
	public float startTime;	// 開始時間

	// Use this for initialization
	void Start () {
		scoreColor = Random.Range(0, 3);	// スコアになる色の初期化
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		timerForGenerating += Time.deltaTime;	// 生成タイマー進行

		if (timerForGenerating > 1.5) {
			// 出現する箱の色を決める
			int color = Random.Range(0, 3);	// 0,1,2 のいずれかをランダムで選択

			// 出現位置をランダムで調整
			float randX = Random.Range(-4, 4);
			float randZ = Random.Range(-4, 4);
			Vector3 position = gameObject.transform.position + new Vector3(randX, 0, randZ);

			// 決定された色によってプレファブをインスタンス化
			GameObject box;
			if (color == 0) {
				box = Instantiate(redBox, position, Random.rotation) as GameObject;
			} else if (color == 1) {
				box = Instantiate(blueBox, position, Random.rotation) as GameObject;
			} else {
				box = Instantiate(greenBox, position, Random.rotation) as GameObject;
			}

			box.GetComponent<Box>().setColor(color);	// Boxスクリプトのメソッドを使って箱の色を設定

			timerForGenerating = 0;	// タイマーリセット
		}

		// スコアカラー変更処理
		timerForChangingScoreColor += Time.deltaTime;	// スコアカラー変更タイマー進行
		
		if (timerForChangingScoreColor > 5) {
			scoreColor = Random.Range(0, 3);	// スコアになる色の変更

			timerForChangingScoreColor = 0;	// タイマーリセット
		}

		// ゲーム終了判定
		if (30 - Time.time + startTime < 0) {
			Application.LoadLevel("End");
		}
	}

	// スコア加減の判定をするメソッド
	public void judgeColor(int colorType) {
		// スコアカラーとカラータイプが同じならスコア加算
		if (scoreColor == colorType) {
			score++;
		} else {
			score--;
		}
	}

	// GUI描写
	private void OnGUI() {
		// スコア表示
		scoreText.text = "Score : " + score;

		// スコアカラー表示
		if (scoreColor == 0) {
			colorText.text = "Color : Red";
		} else if (scoreColor == 1) {
			colorText.text = "Color : Blue";
		} else {
			colorText.text = "Color : Green";
		}

		// 残り時間表示
		timeText.text = "Time : " + (30 - Time.time + startTime);
	}

	// スコアゲッター
	public static int getScore() {
		return score;
	}
}
