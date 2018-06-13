using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {

    public bool paused;

    public void pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }
}
