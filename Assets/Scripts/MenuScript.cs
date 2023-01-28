using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class MenuScript : MonoBehaviour
{

    public GameObject titleMenu;
    public GameObject settingsMenu;
    public GameObject pauseSettings;
    public GameObject pauseMenu;
    //public GameObject loadingScreen;

    public PlayerMovement playerMovement;
    public MouseLook mouseLook;

    public AudioSource audioSource;
    public AudioClip ambienceAudioClip;
    public AudioClip musicAudioClip;

    public Transform position1;
    public Transform position2;

    public Slider volumeSlider;
    public Slider pauseVolumeSlider;

    private bool isPlaying = false;
    public bool isPauseMenuOpen = false;
    public bool isSettingsMenuOpen = false;

    public PostProcessLayer postProcessLayer;
    public PostProcessVolume postProcessVolume;

    private float audioSourceVolume;

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
        audioSourceVolume = audioSource.volume;
        volumeSlider.value = audioSourceVolume;
        pauseVolumeSlider.value = audioSourceVolume;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPlaying && !(isSettingsMenuOpen))
        {
            if (isPauseMenuOpen)
                HidePauseMenu();
            else
                ShowPauseMenu();
        }
    }

    public void MuteVolume()
    {
        audioSourceVolume = audioSource.volume;
        audioSource.volume = 0f;
    }

    public void UnMuteVolume()
    {
        audioSource.volume = audioSourceVolume;
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void OnSliderValueChanged(float newValue)
    {
        audioSource.volume = newValue;
    }

    public void ShowPauseMenu()
    {
        //PauseMusic();
        isPauseMenuOpen = true;
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.PauseMenu;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        //PlayMusic();
        isPauseMenuOpen = false;
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.None;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        pauseMenu.SetActive(false);
    }

    public void OnPlay()
    {
        isPlaying = true;
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
        isSettingsMenuOpen = false;
        if (isPauseMenuOpen)
        {
            ShowPauseMenu();
            HideSettingsMenu();
            return;
        }
        HideSettingsMenu();
        ShowMenu();
    }

    public void OnOpenSettingsFromPauseMenu()
    {
        HidePauseMenu();
        OpenSettingsMenu();
    }

    public void OnCloseSettingsFromPauseMenu()
    {
        HideSettingsMenu();
        ShowPauseMenu();
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
        isSettingsMenuOpen = true;
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.SettingsMenu;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        settingsMenu.SetActive(true);
    }

    public void HideSettingsMenu()
    {
        isSettingsMenuOpen = false;
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.None;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        settingsMenu.SetActive(false);
    }

    public void OnOpenPauseSettings()
    {
        HidePauseMenu();
        OpenPauseSettings();
    }

    public void OnClosePauseSettings()
    {
        HidePauseSettings();
        ShowPauseMenu();
    }

    public void OpenPauseSettings()
    {
        //PauseMusic();
        isSettingsMenuOpen = true;
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.SettingsMenu;
        Cursor.lockState = CursorLockMode.None;
        playerMovement.enabled = false;
        mouseLook.enabled = false;
        pauseSettings.SetActive(true);
    }

    public void HidePauseSettings()
    {
        //PlayMusic();
        isSettingsMenuOpen = false;
        MenuNavigator.instance.currentMenu = MenuNavigator.MenuType.None;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        pauseSettings.SetActive(false);
    }

    public void GoToMenuFromSettings()
    {
        SceneManager.instance.ReloadScene();
    }

    public void PostProcessingSetActive(bool b)
    {
        postProcessLayer.enabled = b;
    }

    public void AntiAliasingSetActive(bool b)
    {
        if (b)
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
        else
            postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
    }

    public void AmbientOcclusionSetActive(bool b)
    {
        postProcessVolume.profile.GetSetting<AmbientOcclusion>().active = b;
    }

    public void BloomSetActive(bool b)
    {
        postProcessVolume.profile.GetSetting<Bloom>().active = b;
    }

    public void VignetteSetActive(bool b)
    {
        postProcessVolume.profile.GetSetting<Vignette>().active = b;
    }

    public void MotionBlurSetActive(bool b)
    {
        postProcessVolume.profile.GetSetting<MotionBlur>().active = b;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
