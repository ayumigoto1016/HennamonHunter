using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class PictureOpen : MonoBehaviour {



	void Start(){

		string path = ScreenshotController.imagePath;

		//確認
		Debug.Log(path);

		// スクリーンショットの読み込み
		byte[] image = File.ReadAllBytes("Assets/name.png");


		// Texture2D を作成して読み込み
		Texture2D tex = new Texture2D(0, 0);
		tex.LoadImage(image);

		Sprite texture_sprite = Sprite.Create(tex, new Rect(0,0,tex.width,tex.height), Vector2.zero);
		this.GetComponent<Image> ().sprite = texture_sprite;

		//前に撮ったスクショを削除
		//File.Delete (ScreenshotController.imagePath);


	}

}