using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideSceneManager : MonoBehaviour
{

    public Animator fadingTextAnimator;
    public string triggerParameterName = "TriggerFadeIn";
    public GameObject canvas2;

    public bool enteredTomb = false;

    private FunctionTimer timer;

    public void OnEnterTomb()
    {
        enteredTomb = true;
        fadingTextAnimator.SetTrigger(triggerParameterName);
        //fadingTextAnimator.f
        timer = new FunctionTimer(OnAnimationFinish, 480 / 60 - 1);
    }

    private void Update()
    {
        if(enteredTomb)
            timer.Update();
    }

    private void OnAnimationFinish()
    {
        //print("Animation finish");
        canvas2.SetActive(false);
    }

}
