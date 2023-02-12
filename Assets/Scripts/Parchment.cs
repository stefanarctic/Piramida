using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parchment : MonoBehaviour
{

    public Sprite canvasSprite;

    public TakeParchmentScript parchmentScript;

    public GameObject[] pages;

    //private void Awake()
    //{
    //    parchmentScript = FindObjectOfType<TakeParchmentScript>();
    //}

    private void OnMouseOver()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            PageManager.instance.pages = pages;
        }
        parchmentScript.CheckParchment(this);
        //MenuScript.instance.HidePauseMenu();
        if(!parchmentScript.holdingParchment)
            parchmentScript.ShowCrosshair();
    }

    private void OnMouseExit()
    {
        parchmentScript.HideCrosshair();
    }
}
