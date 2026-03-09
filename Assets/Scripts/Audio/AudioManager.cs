using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioBGM;
    public AudioSource audioSFX;

    private void Awake()
    {
        instance = this;
    }

    public void SetBGMVolume(float value)
    {
        if(audioBGM != null)
        {
            audioBGM.volume = value;
        }
    }

    public void SetSFXVolume(float value)
    {
        if(audioSFX != null)
        {
            audioSFX.volume = value;
        }
    }

    public void PlaySFX(AudioClip audioClip)
    {
        if(audioClip == null)
        {
            return;
        }

        audioSFX.PlayOneShot(audioClip);
    }
}
