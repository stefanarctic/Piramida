using System;
using UnityEngine;

public class FunctionTimer
{

    private Action action;
    private float timer;

    public FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            action();
        }
    }

}