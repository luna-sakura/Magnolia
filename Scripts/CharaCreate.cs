using UnityEngine;
using System.Collections;

public class CharaCreate : MonoBehaviour {

	[SerializeField] private GameObject[] Character; //キャラクターのプレハブを格納する配列
	public static int CharacterNumber;		//どのキャラクターが表示されているかを判断する変数
	public static bool createFlag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (createFlag == true) {
			CharacterChange (CharacterNumber - 1);
			createFlag = false;
		}
	}

	void CharacterChange(int x) {
	Instantiate (Character[x]);
	}

}
