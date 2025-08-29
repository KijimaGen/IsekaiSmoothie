/*
 * Date 2025年6月9日
 * programar Sum1r3
 * Cup.cs
 * コップクラス
 */
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using static GameConst;

public class Cup : MonoBehaviour{
    
    [SerializeField]
    Material juiceMaterial;
    Color juiceColor;
    
    private int sweet;  //甘
    private int spicy;  //辛
    private int bitter; //苦
    private int sour;   //酸

    //今最も多い味を代入するためのもの
    int max;
    
    //今の味
    Taste taste;

    //上に移動するときのいどうスピード
    const float speed = 0.75f;
    //入っているアイテムの個数(上限はつけないよ)
    public static int havingItem;
    [SerializeField]
    TextMeshProUGUI copText;

    //それぞれ、効能、味、全体のテキスト
    private string effectText = null;
    private string tasteText = null;
    private string juiceText = null;

    private Vector3 originPos = Vector3.zero;

    //移動するかどうかのbool
    public bool isHaveCop ;

    //自身のインスタンス(主に客が中身を見る)
    public static Cup instance;

    public Effect nowEffect { get; private set; }

    [SerializeField]
    Canvas canvas;

    private void Start() {
        originPos = transform.position;
        
        instance = this;
        Initialize();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize() {
        sweet = 0;
        spicy = 0;
        bitter = 0;
        sour = 0;
        nowEffect = Effect.None;
        juiceColor = new Color(255, 255, 255);
        havingItem = 0;
        isHaveCop = false;
        this.transform.position = originPos;
        effectText = "こうかなしの";
        tasteText = "むみの";
        juiceText = "スムージー";
        taste = Taste.None;
    }

    private void Update() {
        //コップに重なっていたらアウトラインの色を変える
        if (MargeManager.instance.OverlapFruitToCup())
            GetComponent<Outline>().ChangeOutlineColor(new Color(255, 255, 0));
        else 
            GetComponent<Outline>().ChangeOutlineColor(Color.white);


        //ラウンドごとの処理
        switch (RoundManager.instance.state) {
            case RoundManager.GameState.Make: {
                
                //コップの効能によってテキスト変更
                ChangeEffectText();

                if (!canvas.enabled)
                    canvas.enabled = true;
            }
                break;
            case RoundManager.GameState.Shake:
                if (this.transform.position.y < 1)
                    transform.Translate(-transform.up * speed * Time.deltaTime);
                
                break;
            case RoundManager.GameState.Drink:
                if (!isHaveCop)
                    transform.Translate(-transform.forward * speed * Time.deltaTime);
                canvas.enabled = false;
                break;
            case RoundManager.GameState.Result:
                break;
            case RoundManager.GameState.Max:
                break;
        }

        //コップの中身の色を反映
        juiceMaterial.color = juiceColor;
        //ジュースの中にあるアイテムの数の反映
        havingItem = sweet + spicy + bitter + sour;
        //コップの味によるテキスト変更
        ChangeTasteText();
        //ジュースの名前を作成
        copText.text = tasteText + "\n" + effectText + "\n" + juiceText;

    }

    
    public void ChangeisHaveCop(bool _haveCop) {
        isHaveCop = _haveCop;
    }

    /// <summary>
    /// 外部から呼び出し可能なリセット関数
    /// </summary>
    public void Resetting() {
        Initialize();
    }

    public void ChangeText(string text) {
        tasteText = text;
        effectText = "";
        juiceText = "";
    }

    public void ChangeEffect(Effect effect) {
        nowEffect = effect;
    }

    private void ChangeEffectText() {
        switch (nowEffect) {
            case Effect.Life:
                effectText = "げんきがもらえる";
                break;
            case Effect.Power:
                effectText = "ちからのつきそうな";
                break;
            case Effect.Defense:
                effectText = "がんじょうになれそうな";
                break;
            case Effect.Heal:
                effectText = "かいふくによさそうな";
                break;
            case Effect.Magic:
                effectText = "まりょくがもらえそうな";
                break;
            case Effect.Lucky:
                effectText = "こううんの";
                break;
            
        }
    }

    /// <summary>
    /// 味の追加ァ！
    /// </summary>
    /// <param name="taste"></param>
    public void AddTaste(Taste taste) {
        switch (taste) {
           
            case Taste.Sweet:
                sweet++;
                break;
            case Taste.Spicy:
                spicy++;
                break;
            case Taste.Bitter:
                bitter++;
                break;
            case Taste.Sour:
                sour++;
                break;
            
        }
    }

    private void ChangeTasteText() {
        //ここでいちばん高い味の要素をもらってその色に変更する
        if (sweet == spicy && spicy == bitter && bitter == sour) {
            max = 0;
        }
        else {
            max = Mathf.Max(sweet, spicy, bitter, sour);
        }

        if (max == sweet) {
            juiceColor = new Color(1, 0.6f, 1);
            tasteText = "あまい";
            taste = Taste.Sweet;
        }
        if (max == spicy) {
            juiceColor = Color.red;
            tasteText = "からい";
            taste = Taste.Spicy;
        }
        if (max == bitter) {
            juiceColor = Color.green;
            tasteText = "にがい";
            taste = Taste.Bitter;
        }
        if (max == sour) {
            juiceColor = Color.yellow;
            tasteText = "すっぱい";
            taste = Taste.Sour;
        }
        if (max == 0) {
            if (havingItem == 0) {
                juiceColor = Color.white;
                taste = Taste.None;
                tasteText = "ふつうな";
            }
            else {
                juiceColor = ColorManager.rainbow;
                taste = Taste.Chaos;
                tasteText = "カオスな";
            }
        }
    
    }

    /// <summary>
    /// 味を渡す
    /// </summary>
    /// <returns></returns>
    public Taste GetTaste() {
        return taste;
    }

    /// <summary>
    /// 効能も渡す
    /// </summary>
    /// <returns></returns>
    public Effect GetEffect() {
        return nowEffect;
    }

    /// <summary>
    /// レイキャストが自身に当たっているかを返す
    /// </summary>
    /// <returns></returns>
    public bool GetRayCop() {
        return RayUtility.CheckShootRay(gameObject);
    }



}