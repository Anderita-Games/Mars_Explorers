using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour {
	public GameObject Spaceship;
	public GameObject Tank;
	public AudioSource Speaker;
	public AudioClip[] Narrations;

	// Use this for initialization
	void Start () {
		AudioListener.volume = PlayerPrefs.GetInt("Volume");
		StartCoroutine(Plot());
	}

	IEnumerator Plot () { //All animation in story
		Speaker.clip = Narrations[0];
		Speaker.Play();
		while (Spaceship.transform.localPosition.x >= 0) {
			Spaceship.transform.localPosition = new Vector2(Spaceship.transform.localPosition.x - 1, Spaceship.transform.localPosition.y);
			yield return new WaitForSeconds(.005f);
		}
		Speaker.clip = Narrations[1];
		Speaker.Play();
		Spaceship.transform.eulerAngles = new Vector3(0, 0, 0);
		yield return new WaitForSeconds(.75f);
		while (Spaceship.transform.localPosition.y >= -73) {
			Spaceship.transform.localPosition = new Vector2(Spaceship.transform.localPosition.x, Spaceship.transform.localPosition.y - .5f);
			yield return new WaitForSeconds(.005f);
		}
		Tank.SetActive(true);
		yield return new WaitForSeconds(.75f);
		Speaker.clip = Narrations[2];
		Speaker.Play();
		while (Spaceship.transform.localPosition.y <= 0) {
			Spaceship.transform.localPosition = new Vector2(Spaceship.transform.localPosition.x, Spaceship.transform.localPosition.y + 1);
			yield return new WaitForSeconds(.005f);
		}
		Spaceship.transform.eulerAngles = new Vector3(0, 0, 90);
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(0);
	}
}
