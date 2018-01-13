﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public int Hp = 300;

    /// <summary>
    /// 攻撃力
    /// </summary>
    public int Damage = 10;


    /// <summary>
    /// 倒した時の獲得賞金
    /// </summary>
    public int Money = 100;

    /// <summary>
    /// trueになると停止
    /// </summary>
    public bool isStop = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
