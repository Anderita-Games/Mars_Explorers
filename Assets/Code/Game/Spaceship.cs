using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
	public GameObject Bomb;
	public Sprite No_Work;

	void Update () {
		if (GameObject.Find("Canvas").GetComponent<GameMaster>().Life <= 0) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = No_Work;
			GameObject.Find("Canvas").GetComponent<GameMaster>().Game_Active = false;
			GameObject.Find("Canvas").GetComponent<GameMaster>().Announcement.text = "YOU WIN!";
		}else {
			if (this.gameObject.transform.position.x <= -6.5) {
				transform.eulerAngles = new Vector3(0, 0, -90);
			}else if (this.gameObject.transform.position.x >= 6.5) {
				transform.eulerAngles = new Vector3(0, 0, 90);
			}
			transform.Translate(Vector2.up * Time.deltaTime * 2);

			if (Random.Range(0, GameObject.Find("Canvas").GetComponent<GameMaster>().Life + 50) == 24) {
				Instantiate(Bomb, new Vector2(transform.position.x, transform.position.y - 1), new Quaternion(0, 0,  0, 0));
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Laser" && GameObject.Find("Canvas").GetComponent<GameMaster>().Life > 0) {
			GameObject.Find("Canvas").GetComponent<GameMaster>().Score += 15;
			GameObject.Find("Canvas").GetComponent<GameMaster>().Life -= 10;
		}
	}
}
