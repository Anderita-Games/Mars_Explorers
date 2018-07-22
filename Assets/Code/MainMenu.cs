using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public Sprite[] Sound_Button;

	void Start () {
		if (PlayerPrefs.GetInt("Volume") == null) {
			PlayerPrefs.SetInt("Volume", 1);
		}else if (PlayerPrefs.GetInt("Volume") == 0) {
			GameObject.Find("Sound Toggle").GetComponent<UnityEngine.UI.Image>().sprite = Sound_Button[1];
		}
	}

	void Update () {
		AudioListener.volume = PlayerPrefs.GetInt("Volume");
	}

	public void Level_Load (UnityEngine.UI.Button button) { //Loads scene from name of button clicked
		SceneManager.LoadScene(button.name);
	}

	public void Sound_Toggle () { //Toggle sound on or off
		if (AudioListener.volume == 1) {
			GameObject.Find("Sound Toggle").GetComponent<UnityEngine.UI.Image>().sprite = Sound_Button[1];
			PlayerPrefs.SetInt("Volume", 0);
		}else {
			GameObject.Find("Sound Toggle").GetComponent<UnityEngine.UI.Image>().sprite = Sound_Button[0];
			PlayerPrefs.SetInt("Volume", 1);
		}
	}
}
