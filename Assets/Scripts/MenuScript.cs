using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject titleMenu;
    public GameObject settingsMenu;
    //public GameObject loadingScreen;

    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    public AudioSource audioSource;
    public AudioClip ambienceAudioClip;
    public AudioClip musicAudioClip;

    public Transform position1;
    public Transform position2;

    private static MenuScript Instance = null;
    public static MenuScript instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType<MenuScript>();
            return Instance;
        }
    }

    private void Start()
    {
        ShowMenu();
        ActivateMusic();
    }

    public void OnPlay()
    {
        HideMenu();
        ActivateAmbience();
        //GameObject playerGameObject = FindObjectOfType<PlayerMovement>().gameObject;
        //playerTransform.position = position1.position;
        //playerGameObject.transform.position = position2.position;
    }

    public void OnOpenSettings()
    {
        HideMenu();
        OpenSettingsMenu();
    }

    public void OnCloseSettings()
    {
        HideSettingsMenu();
        ShowMenu();
    }

    public void ActivateMusic()
    {
        audioSource.Stop();
        audioSource.clip = musicAudioClip;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    public void ActivateAmbience()
    {
        audioSource.Stop();
        audioSource.clip = ambienceAudioClip;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

    public void ShowMenu()
    {
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.TitleMenu;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        titleMenu.SetActive(true);
    }

    public void HideMenu()
    {
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.None;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        titleMenu.SetActive(false);
    }

    public void OpenSettingsMenu()
    {
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.SettingsMenu;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        settingsMenu.SetActive(true);
    }

    public void HideSettingsMenu()
    {
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.None;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        settingsMenu.SetActive(false);
    }

}
