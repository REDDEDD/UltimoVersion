using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continuaraController : MonoBehaviour {

    void Start()
    {
        StartCoroutine(continuar());
    }

    IEnumerator continuar()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MenuCreditos");
    }
}
