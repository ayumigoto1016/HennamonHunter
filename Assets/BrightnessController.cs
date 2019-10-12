using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessController : MonoBehaviour {

	//最小サイズ
	private float minimum = 0.5f;
	//拡大縮小スピード
	private float magSpeed = 10.0f;
	//拡大率
	private float magnification = 0.07f;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Obstacle") {

			col.gameObject.transform.localScale = new Vector2 (this.minimum + Mathf.Sin (Time.time * this.magSpeed) * this.magnification, this.minimum + Mathf.Sin (Time.time * this.magSpeed) * this.magnification);
			Debug.Log ("hit");


		}
	}

	}