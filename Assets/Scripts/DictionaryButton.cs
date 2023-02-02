using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DictionaryButton : MonoBehaviour, IPointerClickHandler
{

    public GameObject window;

    public bool isWindowOpen = false;

    public void OpenWindow()
    {
        isWindowOpen = true;
        window.SetActive(true);
    }

    public void CloseWindow()
    {
        isWindowOpen = false;
        window.SetActive(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        OpenWindow();
    }
}
