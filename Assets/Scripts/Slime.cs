using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Slime : MonoBehaviour
{
    /// <summary>
	/// 味方かどうか
	/// </summary>
	public bool isMine = true;

    // Use this for initialization
    void Start()
    {
        var circle = transform.FindChild("Circle");
        var rate = range / circle.transform.lossyScale.x;
        circle.localScale = new Vector3(rate, rate, 1);
    }

    private int frame = 0;
    private float range = 3.0f;

    // Update is called once per frame
    void Update()
    {
        // Move
        float speed = 0.01f;
        if (!isMine)
            speed *= -1;
        var pos = transform.position;
        pos.x += speed;
        transform.position = pos;
        // Attack
        if (frame % 10 == 0)
        {
            int damage = 10;

            GameObject enemy = null;
            float? distance = null;
            string targetTag = isMine ? "enemy" : "mine";   // 倒すべき相手のタグ
            foreach (var e in GameObject.FindGameObjectsWithTag(targetTag))
            {
                // 距離
                var nowDistance = Mathf.Sqrt(Mathf.Pow((e.transform.position.x - pos.x), 2) + Mathf.Pow((e.transform.position.y - pos.y), 2));
                // 範囲内
                if (nowDistance > range)
                    continue;
                // 距離の小さいものを保持
                if (distance == null || nowDistance < distance)
                {
                    distance = nowDistance;
                    enemy = e;
                }
            }
            // ターゲットが居れば
            if (enemy != null)
            {
                // Hit処理
                Debug.Log("Attack!!");

                var u = enemy.GetComponent<Unit>();
                u.Hp -= damage;
                if (u.Hp <= 0)
                {
                    // TODO: GetMoney
                    Destroy(enemy);
                }
            }
        }

        frame++;
    }
}
