using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : Menu
{
    public PlayerMovement playerMovement;
    public MouseLook mouseLook;


    public override void Show()
    {
        //MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.TitleMenu;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        menuObject.SetActive(true);
    }

    public override void Hide()
    {
        //MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.None;
        Cursor.lockState = CursorLockMode.Locked;
        menuObject.SetActive(false);
        playerMovement.enabled = true;
        mouseLook.enabled = true;
    }

}
