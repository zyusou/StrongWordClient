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

	/*
	ToDo:
	入力　→　出力（丸々が出力されました）
	ゲーム起動時に適当な文言を出力
	入力　→　サーバに投げる　→　サーバからの受取　→　出力
	敵の配置（画像を入れ込む）
	敵のHPの設定
	敵のHPの表示
	敵の消滅判定の設定
	敵の攻撃（してくるけど無効にしちゃえばいい．）
	攻撃力の計算式作成
	クリアの表示
	*/

	public void EndEdit(){
		//Debug.Log(_inputField.text);
		//Debug.Log(_inputField.textComponent.text);

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
