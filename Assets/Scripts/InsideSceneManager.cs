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

    public GameObject treasureMenu;
    public GameObject roomsMenu;
    public GameObject[] treasureParchmentPages;
    public GameObject[] roomsParchmentPages;

    private FunctionTimer timer;

    public void CheckPages(Parchment parchment)
    {
        if(parchment.parchmentType == TakeParchmentScript.ParchmentType.TreasureParchment)
        {
            PageManager.instance.pages = treasureParchmentPages;
            PageManager.instance.storyMenu = treasureMenu;
            TakeParchmentScript.instance.uiParchment = treasureMenu;
        }
        else if(parchment.parchmentType == TakeParchmentScript.ParchmentType.RoomParchment)
        {
            PageManager.instance.pages = roomsParchmentPages;
            PageManager.instance.storyMenu = roomsMenu;
            TakeParchmentScript.instance.uiParchment = roomsMenu;
        }
        else
        {
            print("Unknown parchment option");
        }
    }

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
