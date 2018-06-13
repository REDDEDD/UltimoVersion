using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHexagono : MonoBehaviour
{

    public float speed = 5f;
    public bool choque = true;

    void start()
    {

    }

    void FixedUpdate()
    {
        if (choque)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
        }

        if (!choque)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * -1, 0));
        }
    }

    //cuando colisione con una caja cambiara de direccion, preferible poner una roca o algo que no se mueva ya que con las cajas se le puede dejar atrapado facil
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstaculo")
        {
            if (choque)
            {
                choque = false;
            }
            else
            {
                choque = true;
            }
        }
    }
}
