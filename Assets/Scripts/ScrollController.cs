using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

	[SerializeField]
	private RectTransform _logPrefab = null;

	private Queue<string> _logQueue = new Queue<string>();

	private bool _isRunning = false;

	private string _startText = "敵が現れた！";

	// Use this for initialization
	void Start () {
		makeLogInstance(_startText);
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(outputBattleLog());
	}

	private IEnumerator outputBattleLog(){
		if(_isRunning){
			yield break;
		}

		_isRunning = true;

		if(_logQueue.Count != 0){
			makeLogInstance(_logQueue.Dequeue());
			yield return new WaitForSeconds(0.75f);	
		}

		_isRunning = false;
		yield break;
	}

	//リスト（キュー）に
	public void addLogForQueue(string outputText){
		if(outputText.Length != 0){
			_logQueue.Enqueue(outputText);
		}
	}

	private void makeLogInstance(string logText){
		var item = GameObject.Instantiate(_logPrefab) as RectTransform;
		item.SetParent(transform, false);
		var text = item.GetComponentInChildren<Text>();
		text.text = logText;
	}

}
