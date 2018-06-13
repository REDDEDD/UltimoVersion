using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject follow;

    public Vector2 minCamPos, maxCamPos;

    // Use this for initialization
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musica",0);
        Camera.main.GetComponent<AudioSource>().Play();
    }

    //Comprueba en cada frame donde se encuentra el GameObject que le asignermos a follow
    //El follow se añade desde unity, arrastrando el objeto hasta follow
    private void FixedUpdate()
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;


        //Determinamos cual es el principio y final de nuestra pantalla para usando Clamp
        //Los valores minimos y maximos, los fijamos desde el inspector
        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);


    }
}
