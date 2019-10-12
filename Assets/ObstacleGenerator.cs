using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	public GameObject Block1Prefab;
	public GameObject Block2Prefab;
	public GameObject Block3Prefab;



	// Use this for initialization
	void Start () {


		for (int i = -2; i <= 2; i++) {
			//ブロックの種類を決める
			int block = Random.Range (1, 11);

	
			//float offsetY = Random.Range (-1f, 1f);

			float x = Random.Range (-1f, 1f);
			//ブロックを置いていいy座標の範囲
			float y = YRange();

			float j = Random.Range (0f, 360f);

			if (1 <= block && block <= 5) {

				//Block3Prefabを生成
				GameObject Block3 = Instantiate (Block3Prefab) as GameObject;
				Block3.transform.position = new Vector2 (x, y);
				Block3.transform.rotation = Quaternion.AngleAxis(j, transform.forward );
			
			} else if (6 <= block && block <= 8) {
				//Block1Prefabを生成
				GameObject Block1 = Instantiate (Block1Prefab) as GameObject;
			    Block1.transform.position = new Vector2 (x, y);
				Block1.transform.rotation = Quaternion.AngleAxis(j, transform.forward );
			
			} else if (9 <= block && block <= 10) {
				//Block2Prefabを生成
				GameObject Block2 = Instantiate (Block2Prefab) as GameObject;
					Block2.transform.position = new Vector2 (x, y);
				Block2.transform.rotation = Quaternion.AngleAxis(j, transform.forward );
			
			}



		}


		}

	
	// Update is called once per frame
	void Update () {
		
	}


	float YRange(){

		float y1 = Random.Range (-3.5f, -1f);
		float y2 = Random.Range (1f, 3.5f);

		int rand = Random.Range (0, 2);

		return(rand == 0) ? y1 : y2 ;

	}
		

}
