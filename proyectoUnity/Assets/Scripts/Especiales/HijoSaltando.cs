using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HijoSaltando : MonoBehaviour {
    public bool grounded = true;
    public float power = 300f;

    private void FixedUpdate()
    {
        if (grounded)
        {
            StartCoroutine(saltito());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    IEnumerator saltito()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, power));
        grounded = false;
        yield return 0.1;
    }
}
