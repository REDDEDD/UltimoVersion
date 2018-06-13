using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [System.Serializable]
    public class Level
    {
        public string LevelText;
        public int UnLocked;
        public bool IsInteractable;

        public Button.ButtonClickedEvent OnClickEvent;
    }

    public List<Level> LevelList;
    public GameObject levelButton;
    public Transform PanelNiveles;
    int cont = 1;

    // Use this for initialization
    void Start()
    {
        FillList();
    }

    void FillList()
    {
        foreach (var level in LevelList)
        {
            GameObject newbutton = Instantiate(levelButton) as GameObject;
            newbutton.name = "button" + cont;
            cont++;
            LevelButton button = newbutton.GetComponent<LevelButton>();
            Debug.Log(button);
            button.LevelText.text = level.LevelText;

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
            {
                level.UnLocked = 1;
                level.IsInteractable = true;
            }
            button.unlocked = level.UnLocked;
            button.GetComponent<Button>().interactable = level.IsInteractable;

            button.GetComponent<Button>().onClick.AddListener(() => loadLevels("Level" + button.LevelText.text));

            //Puntuacion hay que solucionar lo otro
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 0)
            {
                button.Star1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 50)
            {
                button.Star2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 120)
            {
                button.Star3.SetActive(true);
            }

            newbutton.transform.SetParent(PanelNiveles);
            newbutton.transform.localScale = new Vector3(1, 1, 1);
        }

        SaveAll();
    }

    void SaveAll()
    {
        /*if (PlayerPrefs.HasKey("Level1"))
        {
            return;
        }
        else
        {*/
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach (GameObject buttons in allButtons)
        {
            LevelButton button = buttons.GetComponent<LevelButton>();
            PlayerPrefs.SetInt("Level" + button.LevelText, button.unlocked);
        }
        //}
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    void loadLevels(string value)
    {
        SceneManager.LoadScene(value);
    }
}
