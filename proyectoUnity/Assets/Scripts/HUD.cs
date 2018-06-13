using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public Sprite[] HeartSprites;
    public Image HeartUI;
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //se cambian las imagenes segun la vida del jugador
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}
