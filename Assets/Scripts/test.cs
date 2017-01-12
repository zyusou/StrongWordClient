using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		Debug.Log("開始");
		var postWord = string.Format("日本語");
		var form = new WWWForm();
		form.AddField("input_word", "ほげほげ");
		var www = new WWW("http://localhost:5000/strong_word_api", form);
		yield return www;
		Debug.Log(www.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 	public void OnClick(){ 
	// 	this.PostWord2Server();
	// }

	// private IEnumerator PostWord2Server(){
	// 	var postWord = string.Format("日本語");
	// 	var postBytes = Encoding.UTF8.GetBytes(postWord);

	// 	var my_www = new WWW("http://120.0.0.1:5000/");

	// 	yield return my_www;
	// 	// if(!string.IsNullOrEmpty(my_www.error))
	// 	// {
	// 	// 	Debug.Log("www Error" + my_www.error);
	// 	// }

	// 	Debug.Log(my_www.text);
	// }

}
