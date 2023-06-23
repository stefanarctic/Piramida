using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{

    public Toggle option1, option2, option3;
    public Image checkMark;

    public Toggle GetAtIndex(int index)
    {
        if (index == 1)
            return option1;
        else if (index == 2)
            return option2;
        else if (index == 3)
            return option3;
        else
            Debug.LogError("Index toggle out of bounds!");

        return null;
    }

}
