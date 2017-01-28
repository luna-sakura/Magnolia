using UnityEngine;
using System.Collections;

public class CharaManager : MonoBehaviour {

	public GameObject[] Face;

	public static bool changeFlag;
	public static bool destroyFlag;

	public static int faceType;

	[SerializeField] private int maxFace;

	// Use this for initialization
	void Start () {
		destroyFlag = false;
		changeFlag = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (changeFlag == true) {
			FaceChange (faceType);
		}

		if (destroyFlag == true) {
			CharacterDestroy ();
		}

	}

	public void FaceChange(int x) {
		for (int i = 0; i < maxFace; i++) {
			Face [i].SetActive (false);
		}

		Face[x - 1].SetActive (true);
		changeFlag = false;
	}

	void CharacterDestroy() {
		Destroy (this.gameObject);
	}

}
