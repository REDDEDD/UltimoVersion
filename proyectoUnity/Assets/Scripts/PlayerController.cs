using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{

    //todo lo que declaremos public, tendremos acceso a ello desde el inspector en unity
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;

    private bool jump;
    private bool derecha;
    private bool izquierda;
    public bool suelo;
    private Rigidbody2D rb2d;
    //private Animator anim;
    private bool movement = true;

    //variables vida
    public int curHealth;
    public int maxHealth = 3;

    public int val;

    public string sceneName;

    AudioSource sonido;
    AudioSource sonidoSalto;

    public Button left;
    public Button right;
    public Button up;

    float directionX;
    public int scores;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        curHealth = maxHealth;

        val = 0;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        AudioSource[] sonidos = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>();
        sonido = sonidos[0];
        sonidoSalto = sonidos[1];
        sonido.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sonido", 0);
        sonidoSalto.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sonido", 0);

        up.onClick.AddListener(salto);

        if (PlayerPrefs.GetInt("score_2", 0) >= 100)
        {
            PlayerPrefs.SetInt("next_level", 1);
        }

        scores = (PlayerPrefs.GetInt("score_1", 0) + PlayerPrefs.GetInt("score_2", 0) + PlayerPrefs.GetInt("score_3", 0) + PlayerPrefs.GetInt("score_4", 0));

        Social.ReportScore(scores, RED.leaderboard_general, (bool success) => {});

        if (scores == 1200)
        {
            Social.ReportProgress(RED.achievement_dios, 100.0f, (bool success) => { });
        }
        
    }

    public void salto()
    {
        if (grounded)
        {
            jump = true;
            grounded = false;
        }
    }

    public void MoverDerecha()
    {
        derecha = true;
    }

    public void MoverIzquierda()
    {
        izquierda = true;
    }

    public void Detener()
    {
        jump = false;
        derecha = false;
        izquierda = false;
    }

    // Igual que el Update pero se usa cuando se va a usar la fisica en el juego
    private void FixedUpdate()
    {
        PlayerPrefs.SetInt("ultima_puntuacion", val);
        PlayerPrefs.SetString("ultima_escena",sceneName);

        Vector3 fixedVelocity = rb2d.velocity;
        //Para reducir la velocidad del personaje 
        fixedVelocity.x *= 0.75f;
        /*if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }*/

        float h = Input.GetAxis("Horizontal");

        // Esto es para comprobar cual es la velocidad del personaje en tiempo de ejecucion
        //Debug.Log(rb2d.velocity.x);

        //para determinar la velocidad del personaje y hacia que lado va
        
            rb2d.AddForce(Vector2.right * speed * h);

        if (derecha)
        {
            rb2d.AddForce(Vector2.right * speed * 1);
        }

        if (izquierda)
        {
            rb2d.AddForce(Vector2.left * speed * 1);
        }

        /*Mathf.Clamp lo usamos para decirle que la velocidad tiene que estar entre -5 y 5 de esta manera se
        establece una velocidad maxima*/
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            sonidoSalto.Play();
            jump = false;
        }

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("hijo"))
        {
            val = val + 100;
            Destroy(col.gameObject);
            switch (sceneName)
            {
                case "Nivel1":
                    if (val > PlayerPrefs.GetInt("score_1", 0))
                    {
                        PlayerPrefs.SetInt("score_1", val);
                        if (PlayerPrefs.GetInt("score_1", 0) >= 100)
                        {
                            Social.ReportProgress(RED.achievement_primeros_pasos, 100.0f,(bool success) => { });
                            PlayerPrefs.SetInt("score_2", 1);
                        }
                    }
                    break;

                case "Nivel2Boss":
                    if (val > PlayerPrefs.GetInt("score_2", 0))
                    {
                        PlayerPrefs.SetInt("score_2", val);
                        if (PlayerPrefs.GetInt("score_2", 0) >= 100)
                        {
                            PlayerPrefs.SetInt("next_level", 1);
                            PlayerPrefs.SetInt("score_3", 1);
                        }
                    }
                    break;

                case "Nivel1Mun2":
                    if (val > PlayerPrefs.GetInt("score_3", 0))
                    {
                        PlayerPrefs.SetInt("score_3", val);
                        if (PlayerPrefs.GetInt("score_3", 0) >= 100)
                        {
                            PlayerPrefs.SetInt("score_4", 1);
                        }
                    }
                    break;

                case "Nievel2Boss2":
                    if (val > PlayerPrefs.GetInt("score_4", 0))
                    {
                        PlayerPrefs.SetInt("score_4", val);
                        if (PlayerPrefs.GetInt("score_4", 0) >= 100)
                        {
                            Social.ReportProgress(RED.achievement_veterano, 100.0f, (bool success) => { });
                            PlayerPrefs.SetInt("creditos", 1);
                        }
                    }
                    break;
            }   
        }
    }

    //si cambia de escena la variable val se pone a 0
    void OnLevelWasLoaded()
    {
        val = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "obstaculo")
        {
            grounded = true;
        }

        //Declaramos los scripts de los enemigos
        EnemigoHexagono amarillo = col.collider.GetComponent<EnemigoHexagono>();
        EnemigoRapid morado = col.collider.GetComponent<EnemigoRapid>();
        EnemigoRojo rojo = col.collider.GetComponent<EnemigoRojo>();
        EnemigoTriangulo gris = col.collider.GetComponent<EnemigoTriangulo>();
        Boss1 b1 = col.collider.GetComponent<Boss1>();
        Boss2 b2 = col.collider.GetComponent<Boss2>();

        //si colisiona con alguno...
        if (gris != null || b1 != null || b2 != null)
        {
            sonido.Play();
        }
        if (amarillo != null || morado != null || rojo != null)
        {
            sonido.Play();
            foreach (ContactPoint2D point in col.contacts)
            {
                //Si golpea por arriba muere el enemigo
                if (point.normal.y >= 0.7f)
                {
                    Destroy(col.gameObject);
                }
                //sino pierde vida
                else
                {
                    Damage(1);
                }
            }
        }
        if (gris != null)
        {
            Damage(1);
        }

        if (b1 != null || b2 != null)
        {
            foreach (ContactPoint2D point in col.contacts)
            {
                Damage(1);
            }
        }
    }

    //Si se queda sin vidas llamamos a Die que reinicia el juego
    void Die()
    {
        //restart
        SceneManager.LoadScene("MenuGameOver");
    }

    //resta vida al jugador
    public void Damage(int dmg)
    {
        curHealth -= dmg;
        //impulso al perder vida, igual hay que tocarlo por que se va a cuenca cuando toca los pinchos o el triangulo
        //para determinar la velocidad del personaje y hacia que lado va
        float h = Input.GetAxis("Horizontal");
        if (h > 1)
        {
            Debug.Log("derecha");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(600f, 600f));
        }
        if (h < 1)
        {
            Debug.Log("izquierda");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f, 600f));
        }
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(600f, 600f));
    }

    //Al tocar los pinchos pega un impulso
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb2d.velocity = new Vector2(0, 0);
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y + knockbackPwr, transform.position.z));
        }

        yield return 0;
    }
}
