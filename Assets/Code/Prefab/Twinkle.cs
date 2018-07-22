using System.Collections;
using UnityEngine;

public class Twinkle : MonoBehaviour {
	void Update () {
		if (Random.Range(0, 7500) == 24) { //Chance of a star twinkling 
			StartCoroutine(Twinkler());
		}
	}

	//Twinkles and shit
	IEnumerator Twinkler () {
		if (Random.Range(0, 2) == 1) { //Tall Mode
			this.transform.localScale = new Vector2(.75f, .5f);
			yield return new WaitForSeconds(Random.Range(.5f, 2.000f));
			this.transform.localScale = new Vector2(.5f, .5f);
		}else { //Fat mode
			this.transform.localScale = new Vector2(.5f, .75f);
			yield return new WaitForSeconds(Random.Range(.5f, 2.000f));
			this.transform.localScale = new Vector2(.5f, .5f);
		}
	}
}
