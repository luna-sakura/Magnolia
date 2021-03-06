﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour 
{
	[Multiline] public string[] scenarios;
	public string[] names;

	[SerializeField] private int[] characterFace;
	[SerializeField] private int[] characterNum;
	[SerializeField] private int[] background;
	[SerializeField] private bool[] noCharacter;

	[SerializeField] Text uiText;
	[SerializeField] Text nameText;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	private int currentLine = 0;
	private int lastUpdateCharacter = -1;
	[SerializeField] private int nextGame;


	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start()
	{
		SetNextLine();
	}

	void Update () 
	{
		// 文字の表示が完了してるならクリック時に次の行を表示する
		if( IsCompleteDisplayText ){
			if(currentLine < scenarios.Length && Input.GetMouseButtonDown(0)){
				SetNextLine();
			} else if(currentLine >= scenarios.Length && Input.GetMouseButtonDown(0)){

				NumberReset ();

				switch(nextGame) {
				case 0:
					Application.LoadLevel( "Main" );
					break;
				case 1:
					Application.LoadLevel( "Title" );
					break;
				}
			}
		}else{
			// 完了してないなら文字をすべて表示する
			if(Input.GetMouseButtonDown(0)){
				timeUntilDisplay = 0;
			}
		}

		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}


	void SetNextLine()
	{

		currentText = scenarios[currentLine];
		nameText.text = names[currentLine];

		if (characterFace [currentLine] != 0 && characterFace [currentLine] != CharaManager.faceType) {
			CharaManager.faceType = characterFace [currentLine];
			CharaManager.changeFlag = true;
		}

		if (characterNum[currentLine] != 0 && characterNum[currentLine] != CharaCreate.CharacterNumber) {
			CharaCreate.CharacterNumber = characterNum[currentLine];
			CharaManager.destroyFlag = true;
			CharaCreate.createFlag = true;
		} else if ( noCharacter[currentLine] == true ) {
			CharaManager.destroyFlag = true;
			CharaCreate.CharacterNumber = 0;
		}

		if ( background[currentLine] != 0 && background[currentLine] != BackGroundManager.backgroundNum) {
			BackGroundManager.backgroundNum = background[currentLine];
			BackGroundManager.backgroundChange = true;
		}
			
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
		lastUpdateCharacter = -1;
	}

	void NumberReset() {
		CharaManager.faceType = 0;
		CharaCreate.CharacterNumber = 0;
		BackGroundManager.backgroundNum = 0;
	}

}