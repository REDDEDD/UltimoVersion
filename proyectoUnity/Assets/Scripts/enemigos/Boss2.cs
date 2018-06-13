using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    
    
    Vector3 target;
    public float fuerzaSalto = 0.001f;
    public bool grounded;
    GameObject player;
    public float visionRadius = 5;
    public float speed = 3;
    

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
            if (player.transform.position.x < transform.position.x)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.1f, 0), ForceMode2D.Impulse);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.1f, 0), ForceMode2D.Impulse);
            }
        }

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
