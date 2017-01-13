using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private ScrollController _scrollController;

	[SerializeField]
	private int _enemyHitPoint;

	private List<string> _inputKatakanaList = new List<string>();
	private int _damage = 0;
	private string _inputKatakana;

	private Text _HPText;


	// Use this for initialization
	void Start () {
        _scrollController = GameObject.Find("Content").GetComponent<ScrollController>();
		_HPText = GameObject.Find("HitPointText").GetComponent<Text>();

		// 汚い
		_scrollController.addLogForQueue("敵が現れた！");
		_scrollController.addLogForQueue("でも，あなたは最強の魔法使いなので");
		_scrollController.addLogForQueue("強いカタカナ語なら敵にダメージを与えられます");
		_scrollController.addLogForQueue("逆に，弱いと敵が回復してしまいます");
		_scrollController.addLogForQueue("頑張ってそれっぽい文字列を入力してください ↓↓↓");
	}
	
	// Update is called once per frame
	void Update () {
		_HPText.text =　"敵全体のHP：" + _enemyHitPoint.ToString();
	}

	// これまでの入力からの編集距離の総和を求めるために溜め込んでおく．
	public void addInputKatakanaToList(string Katakana){
		_inputKatakana = Katakana;
		_inputKatakanaList.Add(Katakana);
	}

	public void SetLabelAndScoreFromString(string getStringFromServer){
		var parsedString = getStringFromServer.Split(','); 
		var label = int.Parse(parsedString[0]);
		var score = float.Parse(parsedString[1]);
		culcDamage(score);
		outputLabelAndDamage(label);
	}
	
	private void culcDamage(float score){
		_damage = (int)(score * 1000);
		print(_damage);
		_enemyHitPoint = _enemyHitPoint + _damage;
	}

	private void outputLabelAndDamage(int label){
		var outputDamage = _damage.ToString();
		// ダメージを出力するときにマイナスがついてると気持ちが悪いので取り除く
		if (outputDamage.Contains("-")){
			outputDamage.Remove(outputDamage.IndexOf("-"));
		}

		// 機械学習時，labelが1のときは強い，2のときは弱いと判断するように学習済み
		if(label == 1){
			_scrollController.addLogForQueue(_inputKatakana + "強いカタカナ語！");
			_scrollController.addLogForQueue("敵に" + outputDamage +　"のダメージ！");
		}else{
			_scrollController.addLogForQueue(_inputKatakana + "は弱いカタカナ語!");
			_scrollController.addLogForQueue("敵は" + outputDamage +　"だけ回復した！");
		}
	}


}
