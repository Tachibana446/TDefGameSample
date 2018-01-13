using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MyTime
{
    public float H { get; private set; }
    public float M { get; private set; }
    public float S { get; private set; } 

    public MyTime()
    {
        H = M = S = 0;
    }

    public void Add(float delta)
    {
        S += delta;
        
        if (S > 60)
        {
            M += Mathf.Floor(S / 60);
            S = S % 60;
        }
        if (M > 60)
        {
            H += Mathf.Floor(M / 60);
            M = M % 60;
        }
    }

    public override string ToString()
    {
        return string.Format("{0:00}:{1:00}:{2:00}", H, M, Mathf.Floor(S));
    }
}
