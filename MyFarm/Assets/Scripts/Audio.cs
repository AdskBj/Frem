using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public Slider bgmSlider;
    public Slider soundSlider;
    private AudioSource bgmAudio;
    private AudioSource soundAudio;

    void Start () {
        bgmAudio = GameObject.Find("BGM").GetComponent<AudioSource>();
        soundAudio = GameObject.Find("Sound").GetComponent<AudioSource>();

    }

    void Update () {
        bgmAudio.volume = bgmSlider.value;
        soundAudio.volume = soundSlider.value;    
    }
}
