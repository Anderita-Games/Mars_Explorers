using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {
	public Sprite Explosion;
	public GameObject Laser;
	bool Jumping = false;

	void Update () {
		if (GameObject.Find("Canvas").GetComponent<GameMaster>().Game_Active == true) {
			if (Input.GetMouseButtonDown(0)) {
				if (Input.mousePosition.x < Screen.width / 2f && Jumping == false) { //Jump
					Jumping = true;
					this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 350);
				}else if (Input.mousePosition.x > Screen.width / 2f) { //Laser
					GameObject Clone = Instantiate(Laser, new Vector2(this.transform.position.x - .163f, this.transform.position.y + .68f), new Quaternion(0, 0, 0, 0));
					Clone.transform.eulerAngles = new Vector3(0, 0, 90);
					Instantiate(Laser, new Vector2(this.transform.position.x + 1.176f, this.transform.position.y + .095039f), new Quaternion(0, 0, 0, 0));
				}
			}
			if (this.transform.position.x > -7 && this.transform.position.x < 7) {
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * Input.acceleration.x);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log(collision.gameObject.name);
		if (collision.gameObject.name == "Ground") {
			Jumping = false;
		}else if (collision.gameObject.name == "Explosion") {
			StartCoroutine(Death());
		}
	}

	IEnumerator Death () {
		GameObject.Find("Canvas").GetComponent<GameMaster>().Lives--;
		this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = Explosion;
		yield return new WaitForSeconds(.2f);
		Destroy(this.gameObject.GetComponent<Collider2D>());
		GameObject.Find("Canvas").GetComponent<GameMaster>().Respawn();
		Destroy(this.gameObject);
	}
}
