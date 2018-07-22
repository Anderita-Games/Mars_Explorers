using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	void Start () {
		this.gameObject.name = "Laser";
	}

	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * 10);
		if (this.transform.position.y >= 8 || this.transform.position.x >= 13) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name != "Player" && collision.gameObject.name != "Laser") {
			Destroy(this.gameObject);
		}
	}
}
