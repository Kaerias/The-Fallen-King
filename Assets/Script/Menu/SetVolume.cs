using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    [SerializeField] Slider[] sliderVolume = null;
    [SerializeField] GameObject music = null;
    float volume = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        volume = AudioListener.volume;
        sliderVolume[0].value = volume;
        sliderVolume[1].value = music.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = sliderVolume[0].value;
        music.GetComponent<AudioSource>().volume = sliderVolume[1].value;
    }
}
