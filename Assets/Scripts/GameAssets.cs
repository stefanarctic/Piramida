using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("Prefabs/GameAssets")) as GameObject).GetComponent<GameAssets>();
            //if (_i == null)
            //{
            //    GameObject gameObject = Resources.Load("Prefabs/GameAssets") as GameObject;
            //    print(gameObject);
            //}
            return _i;
        }
    }

    public SoundAdioClip[] soundAdioClipArray;

    [System.Serializable]
    public class SoundAdioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
        public float volume = 1f;
    }

}
