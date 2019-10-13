using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidas : MonoBehaviour
{

    public static int lives = 3;    //se empiezan con 3 vidas
    public string liveString;

    public Text TextLive;   //texto que se muestra en pantalla
    public static vidas Vidas;


    void awake()
    {
        Vidas = this;
        //setea una clase como estatica
    }

    void Start()
    {

    }

    void Update()
    {

        TextLive.text = liveString + lives.ToString();  //se castea a string

    }

    public static void restar()
    {

        lives -= 1; //se resta una vida

    }

}


