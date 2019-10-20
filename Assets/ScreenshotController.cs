using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ScreenshotController : MonoBehaviour {

	private bool isDoubleTapStart;
	private float doubleTapTime; //タップ開始からの累積時間
	public static string imagePath;

	void Start () {

	
	}

	// Update is called once per frame
	void Update () {


		if (isDoubleTapStart){

			doubleTapTime += Time.deltaTime;

			if (doubleTapTime < 0.2f) {

				if (Input.GetMouseButtonDown (0)) {
					//ダブルクリックしたとき
					isDoubleTapStart = false;
					doubleTapTime = 0.0f;
					Capture ();
					KeepPhoto();

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


	public void Capture()
	{
		ScreenCapture.CaptureScreenshot ("Assets/name.png");

	}

	public static void KeepPhoto(){

		string  imageName = "name.png";
		//スクショを保存するパスを作成
		imagePath = "gotouayumi/HennamonHunter/Assets/" + imageName;

		//imagePath = Path.Combine(Application.persistentDataPath, imageName);



}


}
