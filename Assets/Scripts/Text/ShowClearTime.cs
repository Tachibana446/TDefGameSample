using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowClearTime : MonoBehaviour {

    GameManager parent;

	// Use this for initialization
	void Start () {
        parent = gameObject.GetComponentInParent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = "クリアタイム\n" + parent.time.ToString();
	}
}
