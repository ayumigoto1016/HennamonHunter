using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HennamonController : MonoBehaviour {

	public Rigidbody2D rigidbody;
	float speed = 2.0f;

	private bool isDoubleTapStart;
	private bool isStopped;
	private float doubleTapTime; //タップ開始からの累積時間

	SpriteRenderer spriteRenderer;



	void Start()
	{

		this.rigidbody = GetComponent<Rigidbody2D> ();
		this.spriteRenderer = GetComponent<SpriteRenderer>();

	}

	void Update(){
		


		if (isDoubleTapStart) {

			doubleTapTime += Time.deltaTime;
			if (doubleTapTime < 0.2f) {

				if (Input.GetMouseButtonDown (0)) {
					//ダブルクリックしたとき
					isDoubleTapStart = false;
					doubleTapTime = 0.0f;
					isStopped = true;

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


		if(isStopped){

			this.rigidbody.velocity = Vector2.zero;
			ChangeTransparency(1); // 表示する

		}else{

			int a = Random.Range (-10, 11);
			int b = Random.Range (-10, 11);
			rigidbody.velocity = new Vector2 (a * speed, b * speed);
			ChangeTransparency(0); // 完全に透明にする


		}
			
		
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Wall") {//壁にぶつかったら

				//パーティクルを再生
				GetComponent<ParticleSystem> ().Play ();


			Vector2 dir = (Vector2.zero - (Vector2)this.transform.position).normalized;
			rigidbody.velocity = dir * speed* 2 ;

		}
	}

	void ChangeTransparency (float alpha) 
	{
		this.spriteRenderer.color = new Color(1, 1, 1, alpha);


	}


	}

	
