using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleController2 : MonoBehaviour {

    public GameObject handle;
    private RectTransform handleTransform;

    public float speed = 1;
    static float t = 0.0f;

    private float handleSize;
    private float onPosX;
    private float offPosX;

    public float handleOffset = 4;
    public RectTransform toggle;

    public int switched = 1;
    public Button btn;

    public Color onColorBg;
    public Color offColorBg;

    private void Awake()
    {
        handleTransform = handle.GetComponent<RectTransform>();
        RectTransform handleRect = handle.GetComponent<RectTransform>();
        handleSize = handleRect.sizeDelta.x;
        float toggleSizeX = toggle.sizeDelta.x;
        onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
        offPosX = onPosX * -1;
    }

    // Use this for initialization
    void Start()
    {
        btn.onClick.AddListener(change);
        switched = PlayerPrefs.GetInt("switch", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (switched == 1)
        {
            //handleTransform.localPosition = new Vector3(15,-0.3f);
            //con efecto pero empieza en cuenca
            handleTransform.localPosition = SmoothMove(handle, onPosX * -1, offPosX * -1);
            btn.GetComponent<Image>().color = Color.green;

        }
        else
        {
            //handleTransform.localPosition = new Vector3(-12.21f, -0);
            //con efecto pero empieza en cuenca
            handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
            btn.GetComponent<Image>().color = Color.red;
        }

    }

    void change()
    {
        if (switched == 1)
        {
            switched = 0;
        }
        else
        {
            switched = 1;
        }

    }

    Vector3 SmoothMove(GameObject toggleHandle, float startPosX, float endPosX)
    {

        Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += speed * Time.deltaTime), 0f, 0f);
        return position;
    }

    void OnApplicationQuit()
    {
        //cuando el usuario cierra la aplicacion guarda el valor del switch para saber si la proxima vez tiene que activar o desactivar la musica
        PlayerPrefs.SetInt("switch_2", switched);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetInt("switch") != 0);
    }
}
