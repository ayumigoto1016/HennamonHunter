using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {
	private float time = 30;

	void Start () {
		//初期値30を表示
		//float型からint型へCastし、String型に変換して表示
		GetComponent<Text>().text = ((int)time).ToString();
	}

	void Update (){
		//1秒に1ずつ減らしていく
		time -= Time.deltaTime;
		GetComponent<Text> ().text = ((int)time).ToString ();
		//マイナスは表示しない
		if (time < 0){

		SceneManager.LoadScene("ResultSceneLose");

	}
}
}