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

    private int frame = 0;
    private float range = 3.0f;
    public float speed = 0.02f;

    // Use this for initialization
    void Start()
    {
        var circle = transform.GetComponentInChildren<RangeCircle>();
        string tag = isMine ? "enemy" : "mine";
        circle.Init(range, 10, tag);

        if (!isMine)
            speed *= -1;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Unit>().isStop)
            return;
        // Move
        var pos = transform.position;
        pos.x += speed;
        transform.position = pos;
        
        frame++;
    }
}
