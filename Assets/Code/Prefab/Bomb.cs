using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	public Sprite Explosion;
	bool Live = true;

	void Start () {
		this.gameObject.name = "Bomb";
	}

	void Update () {
		if (Live == true) {
			transform.Translate(Vector2.left * Time.deltaTime * 2);
		}
		if (this.transform.position.y <= -6) {
			StartCoroutine(Death());
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name != "Spaceship") {
			if (collision.gameObject.name == "Laser" && Live == true) {
				GameObject.Find("Canvas").GetComponent<GameMaster>().Score += 10;
			}
			if (Live == true) {
				StartCoroutine(Death());
			}
		}
	}

	IEnumerator Death () {
		this.gameObject.name = "Explosion";
		Live = false;
		this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = Explosion;
		yield return new WaitForSeconds(.2f);
		Destroy(this.gameObject);
	}
}
