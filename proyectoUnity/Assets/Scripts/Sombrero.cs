using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sombrero : MonoBehaviour {
    private PlayerController player;
    private Boss1 boss;
    private Boss1 boss1;
    public bool check;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        boss = GameObject.FindGameObjectWithTag("Boss1").GetComponent<Boss1>();

        check = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        boss1 = col.collider.GetComponent<Boss1>();
        if (col.gameObject.tag == "Player")
        {
            if (check)
            {
                boss.Damage();
                check = false;
                Invoke("espera",2);
            }
        }
    }

    void espera()
    {
        check = true;
    }
}
