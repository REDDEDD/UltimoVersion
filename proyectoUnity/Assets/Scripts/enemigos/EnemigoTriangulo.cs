using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTriangulo : MonoBehaviour
{

    public float visionRadius = 15;
    public float speed = 3;
    public float salto = 300f;
    public bool grounded;
    Vector3 inicial;
    GameObject player;

    //RIGIDBODY QUITAR FREEZE POSITION X Y ROTATION Z
    void Start()
    {
        //jugador
        inicial = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        //si la distancia hasta el jugador es menor que el radio de visión el objetivo ira hacia él
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            if (grounded)
            {
                StartCoroutine(volverPosicion());
                grounded = false;
            }
        }
    }

    IEnumerator volverPosicion()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, salto));
        yield return 0.1;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}