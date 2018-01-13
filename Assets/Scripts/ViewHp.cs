using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GUI Textにアタッチして、親のHPを表示する
/// </summary>
public class ViewHp : MonoBehaviour {

    Unit parent;

	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<Unit>();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = parent.Hp.ToString();

    }
}
