using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class creditController : MonoBehaviour {

    public void observador(string message)
    {
        if (message.Equals("end"))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }
}
