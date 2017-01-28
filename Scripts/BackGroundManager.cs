using UnityEngine;
using System.Collections;

public class BackGroundManager : MonoBehaviour {
	
	public GameObject[] Background;

	public static bool backgroundChange;

	public static int backgroundNum;

	[SerializeField] private int maxBackground;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (backgroundChange == true) {
			FaceChange (backgroundNum - 1);
		}

	}

	public void FaceChange(int x) {

		for (int i = 0; i < maxBackground; i++) {
			Background [i].SetActive (false);
		}

		Background[x].SetActive (true);
		backgroundChange = false;
	}

}
