using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideSceneManager : MonoBehaviour
{

    private static InsideSceneManager Instance = null;
    public static InsideSceneManager instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType<InsideSceneManager>();
            return Instance;
        }
    }

    public Animator fadingTextAnimator;
    public string triggerParameterName = "TriggerFadeIn";
    public GameObject canvas2;

    public GameObject[] roomPages;

    private FunctionTimer timer;

    public void Start()
    {
        fadingTextAnimator.SetTrigger(triggerParameterName);
        //fadingTextAnimator.f
        timer = new FunctionTimer(OnAnimationFinish, 480 / 60 - 1);
    }

    private void Update()
    {
        timer.Update();
    }

    private void OnAnimationFinish()
    {
        //print("Animation finish");
        canvas2.SetActive(false);
    }

}
