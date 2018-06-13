using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoverController : MonoBehaviour {

    public Text puntuacion;
    public Text record;
    public string sceneName;

    void Start()
    {
        sceneName = PlayerPrefs.GetString("ultima_escena");

        puntuacion.text = PlayerPrefs.GetInt("ultima_puntuacion", 0).ToString();
        switch (sceneName)
        {
            case "Nivel1":
                record.text = PlayerPrefs.GetInt("score_1", 0).ToString();
                break;

            case "Nivel2Boss":
                record.text = PlayerPrefs.GetInt("score_2", 0).ToString();
                break;

            case "Nivel1Mun2":
                record.text = PlayerPrefs.GetInt("score_3", 0).ToString();
                break;

            case "Nivel2Boss2":
                record.text = PlayerPrefs.GetInt("score_4", 0).ToString();
                break;
        }
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(sceneName);
    }
}
