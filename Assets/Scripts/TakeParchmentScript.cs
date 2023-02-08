using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeParchmentScript : MonoBehaviour
{

    private static TakeParchmentScript Instance = null;
    public static TakeParchmentScript instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType<TakeParchmentScript>();
            return Instance;
        }
    }

    public float maxDistance = 1f;
    public int brightnessIncrease = 10;

    public GameObject uiParchment;

    public GameObject crosshair;

    private GameObject borderObject;
    private GameObject canvasObject;

    private Parchment currentParchment = null;

    [HideInInspector]
    public bool holdingParchment = false;

    private void Awake()
    {
        //borderMaterial = borderObject.GetComponent<MeshRenderer>().material;
        //canvasMaterial = borderObject.GetComponent<MeshRenderer>().material;
        //print(borderMaterial.name);
        //borderMaterial.color.r += 50;
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown("g"))
    //    {
    //        Time.timeScale = 1f;
    //    }
    //}

    public void ShowCrosshair()
    {
        if(Vector3.Distance(transform.position, currentParchment.gameObject.transform.position) < maxDistance)
            crosshair.SetActive(true);
    }

    public void HideCrosshair()
    {
        crosshair.SetActive(false);
    }

    private void Update()
    {
        if (holdingParchment && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)))
        {
            DropParchment();
        }
    }

    public void CheckParchment(Parchment parchment)
    {
        currentParchment = parchment;
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward));
        if(!holdingParchment
            && Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, parchment.gameObject.transform.position) < maxDistance && !(MenuScript.instance.isPauseMenuOpen))
        {
            holdingParchment = true;
            TakeParchment();
            HideCrosshair();
        }
    }

    private void TakeParchment()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        //Parchment parchment = parchment.gameObject.GetComponent<Parchment>();
        uiParchment.SetActive(true);
        //uiParchment.sprite = currentParchment.canvasSprite;
    }

    private void DropParchment()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        holdingParchment = false;
        uiParchment.SetActive(false);
        currentParchment = null;
        //StartCoroutine(WaitForPauseMenu());
        ////if (MenuScript.instance.isPauseMenuOpen)
        ////{
        ////    MenuScript.instance.HidePauseMenu();
        ////    print("Hide pause menu");
        ////}
        //MenuScript.instance.HidePauseMenu();
        //print(MenuScript.instance.isPauseMenuOpen);
        //print("Hide pause menu");
    }

    //IEnumerator WaitForPauseMenu()
    //{
    //    print("In Coroutine");
    //    yield return new WaitForSeconds(5);
    //    print("After Coroutine");

    //    MenuScript.instance.HidePauseMenu();

    //}

    //private void OnMouseOverParchment(RaycastHit hit)
    //{
    //    borderObject = hit.collider.gameObject.transform.GetChild(0).gameObject;
    //    canvasObject = hit.collider.gameObject.transform.GetChild(1).gameObject;
    //    borderMaterial = borderObject.GetComponent<MeshRenderer>().material;
    //    canvasMaterial = borderObject.GetComponent<MeshRenderer>().material;

    //    borderMaterial.color = new Color(
    //            borderMaterial.color.r + brightnessIncrease,
    //            borderMaterial.color.g + brightnessIncrease,
    //            borderMaterial.color.b + brightnessIncrease
    //    );
    //    canvasMaterial.color = new Color(
    //        canvasMaterial.color.r + brightnessIncrease,
    //        canvasMaterial.color.g + brightnessIncrease,
    //        canvasMaterial.color.b + brightnessIncrease
    //    );
    //    print($"On Mouse Over {borderMaterial.name}");
    //    print($"On Mouse Over {canvasMaterial.name}");
    //}

    //private void OnMouseExitParchment(RaycastHit hit)
    //{

    //    borderMaterial.color = new Color(
    //        borderMaterial.color.r - brightnessIncrease,
    //        borderMaterial.color.g - brightnessIncrease,
    //        borderMaterial.color.b - brightnessIncrease
    //    );
    //    canvasMaterial.color = new Color(
    //        canvasMaterial.color.r - brightnessIncrease,
    //        canvasMaterial.color.g - brightnessIncrease,
    //        canvasMaterial.color.b - brightnessIncrease
    //    );
    //    print($"On Mouse Exit {borderMaterial.name}");
    //    print($"On Mouse Exit {canvasMaterial.name}");

    //    borderObject = null;
    //    canvasObject = null;
    //}

}
