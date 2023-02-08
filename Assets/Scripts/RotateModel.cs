using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{

    private void Update()
    {
        //if(!MenuScript.instance.isPauseMenuOpen)
        transform.Rotate(new Vector3(0f, 0f, 1f / 8f));
    }

}
