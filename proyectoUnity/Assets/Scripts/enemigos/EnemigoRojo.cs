using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRojo : MonoBehaviour
{

    public float visionRadius = 1;
    public float speed = 3;
    Vector3 target;
    public float fuerzaSalto = 0.001f;
    public bool grounded;
    GameObject player;

    void Start()
    {
        //jugador
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //si la distancia hasta el jugador es menor que el radio de visión el objetivo ira hacia él
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            Vector3 target = player.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            Vector3 aux = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            aux.y = transform.position.y;
            transform.position = aux;
        }

        //SALTO

        if (grounded && dist < visionRadius)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
