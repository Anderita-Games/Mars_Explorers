using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	public UnityEngine.UI.Text Tanks;
	public UnityEngine.UI.Text Spaceship_Life;
	public UnityEngine.UI.Text Scores;
	public UnityEngine.UI.Text Announcement;

	public GameObject Tank;
	public GameObject Ground_Prefab;
	public GameObject Dip_Prefab; //TODO: Add this shit
	public GameObject Barrel; //TODO: Add this shit
	GameObject[] Clone = new GameObject[3];

	public int Lives = 3;
	public int Life = 600;
	public int Score = 0;
	public int Speed = 2;

	public bool Game_Active = true;

	void Start () {
		AudioListener.volume = PlayerPrefs.GetInt("Volume");
		Clone[0] = Instantiate(Ground_Prefab, new Vector2(-3, -4.75f), new Quaternion(0, 0,  0, 0));
		Clone[1] = Instantiate(Ground_Prefab, new Vector2(-3 + Ground_Prefab.GetComponent<SpriteRenderer>().bounds.size.x, -4.75f), new Quaternion(0, 0,  0, 0));
		Clone[2] = Instantiate(Ground_Prefab, new Vector2(-3 + Ground_Prefab.GetComponent<SpriteRenderer>().bounds.size.x * 2, -4.75f), new Quaternion(0, 0,  0, 0));
	}
		
	void Update () {
		Tanks.text = "Tanks: " + Lives;
		Spaceship_Life.text = "Spaceship's Life: " + Life;
		Scores.text = "Score: " + Score;

		if (6 - Mathf.CeilToInt(Life / 100) >= Speed) {
			Speed += 1;
			StartCoroutine(Level_Up());
		}

		if (Lives <= 0) {
			Game_Active = false;
			Announcement.text = "GAME OVER";
		}

		if (Clone[0].transform.localPosition.x  <= -25) { //Fix this shit later
			Destroy(Clone[0]);
			Clone[0] = Clone[1];
			Clone[1] = Clone[2];
			Clone[2] = Instantiate(Ground_Prefab, new Vector2(-25.2f + Ground_Prefab.GetComponent<SpriteRenderer>().bounds.size.x * 3f, -4.75f), new Quaternion(0, 0,  0, 0));;
		}
	}

	IEnumerator Level_Up () { //fin
		for (int i = 0; i < 4; i++) {
			Announcement.text = "LEVEL UP";
			yield return new WaitForSeconds(.2f);
			Announcement.text = "";
			yield return new WaitForSeconds(.2f);
		}
	}

	public void Respawn () {
		GameObject Clone = Instantiate(Tank);
		Clone.name = "Player";
	}
}
