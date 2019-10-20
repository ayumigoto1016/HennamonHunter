using UnityEngine;  
using System.IO;  
using System.Collections;  
using SocialConnector; 

public class TwitterController : MonoBehaviour{ 

	string Path = ScreenshotController.imagePath;


	public void Share(){ 
		
		StartCoroutine(_Share());  

	}  

	public IEnumerator _Share()
	{

		// 撮影画像の保存が完了するまで待機
		while (true)
		{
			if (File.Exists(Path)) break;
			yield return null;
		}

		// 投稿
		string tweetText = "○○匹捕まえたよ！次は一匹残らず殲滅してやる";
		string tweetURL = " ";

		SocialConnector.SocialConnector.Share(tweetText, tweetURL, Path);


		// 前回のデータの削除
		File.Delete(Path);
	}
}