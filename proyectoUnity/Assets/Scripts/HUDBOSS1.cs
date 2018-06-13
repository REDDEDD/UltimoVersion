using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDBOSS1 : MonoBehaviour
{

    public Sprite[] HeartSprites;
    public Image HeartUI;
    private Boss1 boss1;

    void Start()
    {
        boss1 = GameObject.FindGameObjectWithTag("Boss1").GetComponent<Boss1>();
    }

    void Update()
    {
        //se cambian las imagenes segun la vida del jugador
        HeartUI.sprite = HeartSprites[boss1.curHealth];
    }
}