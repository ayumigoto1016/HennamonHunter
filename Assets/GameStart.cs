using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// ボタンをクリックするとBattleSceneに移動します
	public void ButtonClicked () {
		SceneManager.LoadScene("PlayScene");
	}
}