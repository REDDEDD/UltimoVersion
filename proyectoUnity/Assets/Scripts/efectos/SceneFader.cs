using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
        Debug.Log(scene);
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }

}
