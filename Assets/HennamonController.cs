using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HennamonController : MonoBehaviour {

	public Rigidbody2D rigidbody;
	float speed = 2.0f;

	/*private float upForce = 1.0f;
	private float RightForce = 1.0f;
	private float HorizontalRange = 2.14f;
	private float VerticalRange = 4.88f;*/

	void Start()
	{

		this.rigidbody = GetComponent<Rigidbody2D> ();

	}

	void Update(){
		
		int a = Random.Range (-10, 11);
		int b = Random.Range (-10, 11);

		rigidbody.velocity = new Vector2 (a * speed, b * speed);

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Wall") {//壁にぶつかったら

				//パーティクルを再生（追加）
				GetComponent<ParticleSystem> ().Play ();

			Debug.Log ("Wall");//衝突判定が行われてるか確認

			Vector2 dir = (Vector2.zero - (Vector2)this.transform.position).normalized;
			rigidbody.velocity = dir * speed* 2 ;

		}
	}
}
	
