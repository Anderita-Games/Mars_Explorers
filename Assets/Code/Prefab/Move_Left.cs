using UnityEngine;

public class Move_Left : MonoBehaviour {
	void Update () {
		if (GameObject.Find("Canvas").GetComponent<GameMaster>().Game_Active == true) {
			transform.Translate(Vector2.left * Time.deltaTime * GameObject.Find("Canvas").GetComponent<GameMaster>().Speed);
		}
	}
}