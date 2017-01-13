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

	private GameObject _enemyGroup;


	// Use this for initialization
	void Start () {
        _scrollController = GameObject.Find("Content").GetComponent<ScrollController>();
		_HPText = GameObject.Find("HitPointText").GetComponent<Text>();
		_enemyGroup = GameObject.Find("EnemyGroup");

		// 汚い
		_scrollController.addLogForQueue("敵のバハムートたちが現れた！");
		_scrollController.addLogForQueue("でも，あなたは最強の魔法使いなので");
		_scrollController.addLogForQueue("強いカタカナ語なら敵にダメージを与えられます！");
		_scrollController.addLogForQueue("逆に，弱いと敵が回復してしまいます！");
		_scrollController.addLogForQueue("頑張ってそれっぽいのを入力してください ↓↓↓");
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
		_enemyHitPoint = _enemyHitPoint + _damage;
		if(_enemyHitPoint < 0){
			_enemyGroup.SetActive(false);
			_enemyHitPoint = 0;

			_scrollController.addLogForQueue("おめでとうございます．敵を倒せました！");
			_scrollController.addLogForQueue("このまま続けてカタカナ語を入れて遊べます．");
			_scrollController.addLogForQueue("中身の実装については菊地本人にお聞きください");
		}
	}

	private void outputLabelAndDamage(int label){
		var outputDamage = _damage;
		// ダメージを出力するときにマイナスがついてると気持ちが悪いので取り除く
		if (outputDamage < 0){
			outputDamage = outputDamage * -1;
		}

		// 機械学習時，labelが1のときは強い，2のときは弱いと判断するように学習済み
		if(label == 1){
			_scrollController.addLogForQueue(_inputKatakana + "強いカタカナ語！");
			_scrollController.addLogForQueue("敵に" + outputDamage.ToString() +　"のダメージ！");
		}else{
			_scrollController.addLogForQueue(_inputKatakana + "は弱いカタカナ語!");
			_scrollController.addLogForQueue("敵は" + outputDamage.ToString() +　"だけ回復した！");
		}
	}


}
