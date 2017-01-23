using UnityEngine;
using System.Collections;

public class CharaManager : MonoBehaviour {

	public GameObject Face1;
	public GameObject Face2;
	public GameObject Face3;
	public GameObject Face4;
	public GameObject Face5;

	public int num;

	// Use this for initialization
	void Start () {
		Face1.SetActive (false);
		Face2.SetActive (false);
		Face3.SetActive (false);
		Face4.SetActive (false);
		Face5.SetActive (false);

		FaceChange (num);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FaceChange(int x) {
		switch (x) {
		case 1:
			Face1.SetActive (true);
			break;

		case 2:
			Face2.SetActive (true);
			break;

		case 3:
			Face3.SetActive (true);
			break;

		case 4:
			Face4.SetActive (true);
			break;

		case 5:
			Face5.SetActive (true);
			break;
		}
	}
}
