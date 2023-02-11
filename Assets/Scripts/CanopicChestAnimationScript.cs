using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanopicChestAnimationScript : MonoBehaviour
{

    public Animator animator;
    public GameObject crosshair;
    public GameObject player;
    public float maxDistance = 8f;

    private bool startedAnimation = false;

    private void OnMouseOver()
    {
        //print("On mouse over");
        ShowCrosshair();
        if(!startedAnimation
            && Input.GetMouseButtonDown(0) && Vector3.Distance(player.transform.position, gameObject.transform.position) < maxDistance)
        {
            startedAnimation = true;
            animator.SetTrigger("OnPlay");
            print("Triggered animation");
        }
    }

    private void OnMouseExit()
    {
        HideCrosshair();
    }

    public void ShowCrosshair()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < maxDistance)
            crosshair.SetActive(true);
    }

    public void HideCrosshair()
    {
        crosshair.SetActive(false);
    }

}
