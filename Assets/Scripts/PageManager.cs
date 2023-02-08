using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{

    public Animator locationTextAnimator;
    public MenuScript menuScript;
    public GameObject storyMenu;
    public GameObject background;
    public GameObject currentPage;
    public GameObject[] pages;

    public int pageNumber = 0;

    public void Init()
    {
        storyMenu.SetActive(true);
        pageNumber = 1;
        currentPage = pages[0];
        currentPage.SetActive(true);
    }

    public void NextPage()
    {
        currentPage.SetActive(false);
        currentPage = pages[++pageNumber - 1];
        currentPage.SetActive(true);
    }

    public void Page1Next()
    {
        //print("Page1Next before next page");
        NextPage();
        //print("Page1Next after next page");
    }

    public void Page2Next()
    {
        NextPage();
        //background.SetActive(false);
    }

    public void Page3Next()
    {
        NextPage();
    }

    public void Page4Next()
    {
        //go to pyramid
        storyMenu.SetActive(false);
        menuScript.OnPlay();
        locationTextAnimator.SetTrigger("TriggerFadeIn");
    }

}
