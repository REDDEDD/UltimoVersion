using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text score;
    //public Text highScore;
    private PlayerController player;

    // Use this for initialization
    void Start () {
        //buscamos el script de playercontroller
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //actualizamos variable highscore
    }

    // Update is called once per frame
    void Update() {
        //actualizamos texto segun puntos jugador
        score.text = player.val.ToString();
    }
}
