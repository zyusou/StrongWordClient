using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputWord : MonoBehaviour
{

    private InputField _inputField;
    private string _acceptChar = "アイウエオカキクケコサシスセソタチツテト"
    + "ナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン"
    + "ーガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポァィゥェォッュャョ";

    private ScrollController _scrollController = null;
	private GameController _gameController;

    // Use this for initialization
    void Start()
    {
        _inputField = GetComponent<InputField>();
        _scrollController = GameObject.Find("Content").GetComponent<ScrollController>();
		_gameController = GameObject.Find("GameMaster").GetComponent<GameController>();
;    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
	ToDo:
	入力　→　出力（丸々が出力されました）
	ScrollViewのぬる解決．GetComponentがうまくできていない． Done
	http://tsubakit1.hateblo.jp/entry/2014/12/18/040252 Done
	ゲーム起動時に適当な文言を出力	Done
	敵の配置（画像を入れ込む）　Done
	出力一番下　→　毎フレームではなく更新時にのみ動作するように変更（時間があったらやります．マウスオンしているかどうかで判断すればよいかと．）
	UIの位置変更 done
	入力　→　サーバに投げる　→　サーバからの受取　→　出力　Done
	ゲームコントローラーから最初の文字列出力を実装 Done
	スコアの受取，パースの実装 
	攻撃力の計算式作成
	敵のHPの設定（スクリプト書いて，シリアライズで敵ごとに設定できるようにする）
	敵のHPの表示
	敵の消滅判定の設定
	クリアの表示
	*/

    public void EndEdit()
    {
        //Debug.Log(_inputField.text);
        //Debug.Log(_inputField.textComponent.text);

        if (AssertInput(_inputField))
        {
            var text = _inputField.textComponent.text;
            _scrollController.addLogForQueue("あなたは\"" + text + "\"と唱えた！");
			_gameController.addInputKatakanaToList(text);
            StartCoroutine(PostInputText(text));
        }
        else
        {
            // カタカナ以外弱いので駄目ですって表示しましょう．
            _scrollController.addLogForQueue("***駄目です***");
            _scrollController.addLogForQueue("ひらがな・漢字・記号は\"弱い\"ので受け付けません！！！");
            _scrollController.addLogForQueue("打ち込んでEnterを押せば変換無しで入力できます．");
        }
    }

    private bool AssertInput(InputField input)
    {
        foreach (char c in input.textComponent.text)
        {
            if (_acceptChar.IndexOf(c) == -1)
            {
                return false;
            }
        }
        if (input.textComponent.text.Length == 0)
        {
            return false;
        }

        return true;
    }

    private IEnumerator PostInputText(string inputText)
    {
        var form = new WWWForm();
        form.AddField("input_word", inputText);
        var www = new WWW("http://localhost:5000/strong_word_api", form);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
			_gameController.SetLabelAndScoreFromString(www.text);
		}

    }
}
