/*
 * Date 2025年6月23日
 * programar Sum1r3
 * ColorManager.cs
 * ジュースを複製とか挙動とかさせるためのモノ、バイバイン方式で増やす
 */
using UnityEngine;
using static ShakeUtility;

public class Juice : MonoBehaviour{
    Rigidbody rb;
    private float powor = 10;

    //飛び出さないためのモノ
    private const float maxSpeed = 1;
    private float distance = -1;
    private const float maxDistanace = 0.3f;
    private GameObject Cup;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        Cup = GameObject.Find("コップ");
    }
    private void Update() {
        //スピードの最大値を設定
        if(rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
        //はみ出しすぎないためにはみ出し度を設定
        distance = Vector3.Distance(this.gameObject.transform.position, Cup.transform.position);
        //はみだし度がはみ出し最高値を超えそうになったら真ん中に戻される
        if (distance > maxDistanace) {
            rb.velocity = Vector3.zero;
            this.transform.position = Cup.transform.position;
        }
        if(IsShake())
        //シェイクマネージャーからスマホの振った力をもらって自身を飛ばす
        rb.AddForce(GetShakePower() / powor, ForceMode.Impulse);
    }

}
