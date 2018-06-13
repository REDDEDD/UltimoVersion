using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHijo : MonoBehaviour
{
    //variable puntos
    public int val;
    private PlayerController player;
    //public int puntosGanados = 1;
    // private GameObject Score;
    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        val = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            val += 100;
            Debug.Log(val);//100
            //Establecer highscore
            
            Destroy(gameObject);
        }
    }*/
}