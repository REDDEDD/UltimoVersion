using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{

    public float visionRadius = 1;
    public float speed = 3;
    Vector3 target;
    public float fuerzaSalto = 0.001f;
    public bool grounded;
    GameObject player;

    //variables vida
    public int curHealth;
    public int maxHealth = 3;

    //variable puntos
    public int val;
    PlayerController pc;

    string sceneName;

    void Start()
    {
        //jugador
        player = GameObject.FindGameObjectWithTag("Player");
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        curHealth = maxHealth;
        val = 0;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
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

    private void FixedUpdate()
    {
        //si la vida del pj es mayor a la maxima que puede tener se iguala al maximo
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        //si se queda sin vidas muere
        if (curHealth <= 0)
        {
            Die();
        }
    }

    public void Damage()
    {
        curHealth--;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void Die()
    {
        //restart
        if (sceneName == "Nivel2Boss")
        {
            switch (pc.curHealth)
            {
                case 1:
                    PlayerPrefs.SetInt("score_2", 100);
                    break;
                case 2:
                    PlayerPrefs.SetInt("score_2", 200);
                    break;
                case 3:
                    PlayerPrefs.SetInt("score_2", 300);
                    break;
            }

            SceneManager.LoadScene("MenuMundo2");
        }
        if(sceneName == "Nivel2Boss2")
        {
            switch (pc.curHealth)
            {
                case 1:
                    PlayerPrefs.SetInt("score_4", 100);
                    break;
                case 2:
                    PlayerPrefs.SetInt("score_4", 200);
                    break;
                case 3:
                    PlayerPrefs.SetInt("score_4", 300);
                    break;
            }
            StartCoroutine(pasarEscena());
        }
    }

    IEnumerator pasarEscena()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Continuara");
    }
}
