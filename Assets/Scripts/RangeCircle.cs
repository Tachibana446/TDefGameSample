using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ユニットの攻撃範囲の円
/// </summary>
public class RangeCircle : MonoBehaviour {

    /// <summary>
    /// 経過フレーム
    /// </summary>
    private int frame = 0;
    /// <summary>
    /// 攻撃間隔
    /// </summary>
    private int attackFrame;
    /// <summary>
    /// このフレームで範囲に入った敵
    /// </summary>
    private List<GameObject> enemies = new List<GameObject>();
    /// <summary>
    /// 1度に何体の敵に攻撃できるか
    /// </summary>
    private int canEnemyCount = 1;
    /// <summary>
    /// どのタグのユニットを攻撃するか
    /// </summary>
    private string targetTag;

    /// <summary>
    /// 親＝ユニット
    /// </summary>
    public Unit Parent { get
        {
            return transform.parent.GetComponent<Unit>();
        } }

    /// <summary>
    /// 円の大きさを範囲（range）に合わせる
    /// </summary>
    /// <param name="range"></param>
    /// <param name="attackFrame">何フレームごとに攻撃するか</param>
    /// <param name="tag">どのタグのユニットを攻撃するか</param>
    /// <param name="canEnemyCount">一度に何体の敵に攻撃できるか</param>
    public void Init(float range, int attackFrame, string tag,int canEnemyCount = 1)
    {
        this.attackFrame = attackFrame;
        targetTag = tag;
        this.canEnemyCount = canEnemyCount;
        var rate = range / transform.lossyScale.x;
        transform.localScale = new Vector3(rate, rate, 1);
    }

    /// <summary>
    /// 判定 1フレームに最初のn回のみ（n = canEnemyCount)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != targetTag)
            return;
        if (enemies.Count >= canEnemyCount)
            return;
        enemies.Add(other.gameObject);
    }
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 停止中ならスキップ
        if (Parent.isStop)
            return;

        // 攻撃処理
        if(frame % attackFrame == 0)
        {
            foreach (var e in enemies)
            {
                // DEBUG
                Debug.Log("Attack!");

                var unit = e.GetComponent<Unit>();
                unit.Hp -= Parent.Damage;
                if(unit.Hp <= 0)
                {
                    // TODO: 倒した時の処理
                    GameObject.Destroy(unit.gameObject);
                }
            }
        }

        frame++;
        enemies.Clear();
	}
}
