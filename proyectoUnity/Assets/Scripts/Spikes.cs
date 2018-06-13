using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
    //Si colisiona con los pinchos
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);

            //se hecha atras
            StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
        }
    }
}
