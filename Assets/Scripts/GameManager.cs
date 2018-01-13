using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの終わりを管理する
/// </summary>
public class GameManager : MonoBehaviour
{

    /// <summary>
    /// 味方の拠点。やられると負け
    /// </summary>
    public Unit MyTower;
    /// <summary>
    /// 敵の拠点。倒すと勝ち
    /// </summary>
    public Unit EnemyTower;

    /// <summary>
    /// ゲームクリア時に表示するキャンバス
    /// </summary>
    public Canvas GameClearCanvas;
    private bool isClear = false;

    /// <summary>
    /// かかった時間
    /// </summary>
    public MyTime time = new MyTime();

    void Start()
    {
        if (MyTower == null || EnemyTower == null)
            Debug.LogError("味方と敵の拠点をセットしてください");

    }

    // Update is called once per frame
    void Update()
    {
        // 勝ち
        if (EnemyTower.Hp <= 0 && !isClear)
        {
            isClear = true;
            foreach (var unit in GetComponentsInChildren<Unit>())
            {
                unit.isStop = true;
            }
            // 勝ちを表示
            GameClearCanvas.gameObject.SetActive(true);
        }
        // 負け
        else if (MyTower.Hp <= 0)
        {

        }
        if (!isClear)
            time.Add(Time.deltaTime);
    }
}
