using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{

    public enum Sound
    {
        BackgroundAmbience,
        EgyptianMusic
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        GameAssets.SoundAdioClip soundAdioClip = GetSoundAudioClip(sound);
        audioSource.volume = soundAdioClip.volume;
        audioSource.PlayOneShot(soundAdioClip.audioClip);
        //audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static GameAssets.SoundAdioClip GetSoundAudioClip(Sound sound)
    {
        foreach(GameAssets.SoundAdioClip soundAdioClip in GameAssets.i.soundAdioClipArray)
        {
            if(soundAdioClip.sound == sound)
            {
                return soundAdioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }

    private static AudioClip GetAudioClip(Sound sound) => GetSoundAudioClip(sound).audioClip;

}
