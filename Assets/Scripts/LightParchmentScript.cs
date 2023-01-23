using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightParchmentScript : MonoBehaviour
{

    public int brightnessIncrease = 50;
    public GameObject borderObject;
    public GameObject canvasObject;

    private Material borderMaterial;
    private Material canvasMaterial;

    private void Awake()
    {
        borderMaterial = borderObject.GetComponent<MeshRenderer>().material;
        canvasMaterial = borderObject.GetComponent<MeshRenderer>().material;
        //print(borderMaterial.name);
        //borderMaterial.color.r += 50;
    }

    private void OnMouseOver()
    {
        //borderMaterial.color.r += brightnessIncrease;
        borderMaterial.color = new Color(
                borderMaterial.color.r + brightnessIncrease,
                borderMaterial.color.g + brightnessIncrease,
                borderMaterial.color.b + brightnessIncrease
        );
        canvasMaterial.color = new Color(
            canvasMaterial.color.r + brightnessIncrease,
            canvasMaterial.color.g + brightnessIncrease,
            canvasMaterial.color.b + brightnessIncrease
        );
        print($"On Mouse Over {borderMaterial.name}");
        print($"On Mouse Over {canvasMaterial.name}");
    }

    private void OnMouseExit()
    {
        borderMaterial.color = new Color(
            borderMaterial.color.r - brightnessIncrease,
            borderMaterial.color.g - brightnessIncrease,
            borderMaterial.color.b - brightnessIncrease
        );
        canvasMaterial.color = new Color(
            canvasMaterial.color.r - brightnessIncrease,
            canvasMaterial.color.g - brightnessIncrease,
            canvasMaterial.color.b - brightnessIncrease
        );
        print($"On Mouse Exit {borderMaterial.name}");
        print($"On Mouse Exit {canvasMaterial.name}");
    }

}
