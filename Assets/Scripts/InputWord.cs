using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputWord : MonoBehaviour {

	private InputField _inputField;
	private string accept_char = "アイウエオカキクケコサシスセソタチツテト"
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

		}
		else{
			
		}
	}

	private bool AssertInput(InputField input){
		foreach(char c in input.text)
		{
			if(accept_char.IndexOf(c) == -1){
				return false;
			}
		}
		return true;
	}
}
