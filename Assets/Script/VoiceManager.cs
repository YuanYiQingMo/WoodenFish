using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    public static VoiceManager instance {get; private set;}
    private AudioSource aus;
    private void Awake() {
        instance = this;
        aus = GetComponent<AudioSource>();
    }
    public void playClip(AudioClip auc){
        aus.PlayOneShot(auc);
    }
}
