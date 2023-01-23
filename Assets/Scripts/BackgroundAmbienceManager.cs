using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAmbienceManager : MonoBehaviour
{

    private void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.BackgroundAmbience);
    }
}
