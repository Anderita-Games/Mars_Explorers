using UnityEngine;

public class Stars : MonoBehaviour {
	public GameObject Star; //Star prefab
	int Star_Count = 400; //Amount of stars to generate

	void Start () {
		for (int i = 0; i < Star_Count; i++) {
			GameObject Clone = Instantiate(Star);
			Clone.name = "Clone #" + i;
			Clone.transform.localPosition = new Vector2(Random.Range(-10.00f, 10.00f), Random.Range(-6.00f, 6.00f)); //TODO: Make screen size dynamic
			Clone.transform.SetParent(GameObject.Find("Stars").transform);
		}
	}
}
