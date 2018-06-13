using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;
    public Button btn1;
    public Button btn2;

    string sceneName = "";

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "MenuMundo1")
        {
            Estrellas star1 = btn1.GetComponent<Estrellas>();
            Estrellas star2 = btn2.GetComponent<Estrellas>();

            List<Estrellas> lista = new List<Estrellas>();
            lista.Add(star1);
            lista.Add(star2);
            if (PlayerPrefs.GetInt("score_1", 0) > 0)
            {
                Debug.Log("Has pasado el nivel puedes avanzar al siguiente nivel.");
                btn2.interactable = true;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (PlayerPrefs.GetInt("score_" + (i + 1), 0) > 99)
                {
                    //1estrella
                    lista[i].Star1.SetActive(true);
                }
                if (PlayerPrefs.GetInt("score_" + (i + 1), 0) > 101)
                {
                    //2estrellas
                    lista[i].Star2.SetActive(true);
                }
                if (PlayerPrefs.GetInt("score_" + (i + 1), 0) > 201)
                {
                    //3esteellas
                    lista[i].Star3.SetActive(true);
                }
            }
        }
        else if (sceneName == "MenuMundo2")
        {
            Estrellas star1 = btn1.GetComponent<Estrellas>();
            Estrellas star2 = btn2.GetComponent<Estrellas>();

            List<Estrellas> lista = new List<Estrellas>();
            lista.Add(star1);
            lista.Add(star2);
            if (PlayerPrefs.GetInt("score_3", 0) > 0)
            {
                Debug.Log("Has pasado el nivel puedes avanzar al siguiente nivel.");
                btn2.interactable = true;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (PlayerPrefs.GetInt("score_" + (i + 3), 0) > 99)
                {
                    //1estrella
                    lista[i].Star1.SetActive(true);
                }
                if (PlayerPrefs.GetInt("score_" + (i + 3), 0) > 101)
                {
                    //2estrellas
                    lista[i].Star2.SetActive(true);
                }
                if (PlayerPrefs.GetInt("score_" + (i + 3), 0) > 201)
                {
                    //3esteellas
                    lista[i].Star3.SetActive(true);
                }
            }
        }

    }

    public void Select(string levelName)
    {
        if (levelName == "Salir")
        {
            Application.Quit();
        }else if (levelName == "MenuMundo2")
        {
            if(PlayerPrefs.GetInt("next_level",0) == 1)
            {
                fader.FadeTo(levelName);
            }
            else
            {
                Debug.Log("Tienes que pasar el mundo primero");
            }
        }
        else
        {
            fader.FadeTo(levelName);
        }
    }
}
