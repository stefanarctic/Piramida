using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parchment : MonoBehaviour
{

    public Sprite canvasSprite;

    private TakeParchmentScript parchmentScript;

    private void Awake()
    {
        parchmentScript = FindObjectOfType<TakeParchmentScript>();
    }

    private void OnMouseOver()
    {
        parchmentScript.CheckParchment(this);
        MenuScript.instance.HidePauseMenu();
        if(!parchmentScript.holdingParchment && !(MenuScript.instance.isPauseMenuOpen))
            parchmentScript.ShowCrosshair();
    }

    private void OnMouseExit()
    {
        parchmentScript.HideCrosshair();
    }
}
