using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicController : MonoBehaviour {

    public Slider volumeMusic;
    public Slider volumeSound;

    void Start()
    {
        /*PlayerPrefs.SetFloat("musica", 1f);
        PlayerPrefs.SetFloat("sonido", 1f);*/
        volumeMusic.value = PlayerPrefs.GetFloat("musica", 0);
        volumeSound.value = PlayerPrefs.GetFloat("sonido", 0);
    }

    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("musica", volumeMusic.value);
        PlayerPrefs.SetFloat("sonido", volumeSound.value);
        PlayerPrefs.Save();
    }
}
