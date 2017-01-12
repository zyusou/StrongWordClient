using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputWord : MonoBehaviour {

	private InputField _inputField;
	private string _acceptChar = "アイウエオカキクケコサシスセソタチツテト"
	+ "ナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン"
	+ "ーガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポァィゥェォッュャョ";
	
	// Use this for initialization
	void Start () {
		_inputField = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndEdit(){
		if(AssertInput(_inputField)){
			Debug.Log("OK");
		}
		else{
			Debug.Log("NG");
		}
	}

	private bool AssertInput(InputField input){
		foreach(char c in input.textComponent.text){
			if(_acceptChar.IndexOf(c) == -1){
				return false;
			}
		}

		return true;
	}
}
