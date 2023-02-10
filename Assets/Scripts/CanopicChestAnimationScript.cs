using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanopicChestAnimationScript : MonoBehaviour
{

    public Animator animator;

    private void Start()
    {
        animator.SetTrigger("OnPlay");
    }

}
