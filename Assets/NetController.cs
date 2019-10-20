using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NetController : MonoBehaviour {

	private Vector3 playerPos;
	private Vector3 mousePos;

	private bool isDoubleTapStart;
	private bool isCaught; //捕まってるかどうかのフラグ
	private float doubleTapTime; //タップ開始からの累積時間


	void Start() {
		


	}



	void Update()
	{
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -2, 2),Mathf.Clamp(this.transform.position.y, -5, 5), this.transform.position.z);
		//的の動ける範囲を制限
		playerControl ();
		//指で操作
	
		if (isDoubleTapStart){
			
			doubleTapTime += Time.deltaTime;
			if (doubleTapTime < 0.2f) {

				if (Input.GetMouseButtonDown (0)) {
					//ダブルクリックしたとき
					isDoubleTapStart = false;
					doubleTapTime = 0.0f;

				
					if (isCaught) {
						StartCoroutine ("WaitAndLoadWin");

						//Hennamonと的が接触してたとき

					} else {

						StartCoroutine ("WaitAndLoadLose");

					}   //Hennamonと的が接触してなかったとき




				}

			} else {
				//２回クリックしたけど、遅すぎてダブルクリックと判定されなかった
				isDoubleTapStart = false;
				doubleTapTime = 0.0f;
			}


		} else {
			if (Input.GetMouseButtonDown (0)) {
				//１回目のクリック
				isDoubleTapStart = true; 


			}
		}
	}

	void OnTriggerEnter2D(Collider2D ob){

		if (ob.gameObject.tag == "Hennamon") {
			isCaught = true;

		}

	}
	void OnTriggerExit2D(Collider2D ob){
		
		if (ob.gameObject.tag == "Hennamon") {
			isCaught = false;

		}

	}

	IEnumerator WaitAndLoadWin(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("ResultSceneWin");
	}
	IEnumerator WaitAndLoadLose(){
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("ResultSceneLose");
	}


	private void playerControl()
	{
		if (Input.GetMouseButtonDown(0))
		{
			playerPos = this.transform.position;
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 prePos = this.transform.position;
			Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;
			//タッチ対応デバイス使用時、1本目の指にのみ反応
			if (Input.touchSupported)
			{
				diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
			}
			diff.z = 0.0f;
			this.transform.position = playerPos + diff;
		}
		if (Input.GetMouseButtonUp(0))
		{
			playerPos = Vector3.zero;
			mousePos = Vector3.zero;
		}
	}
}
