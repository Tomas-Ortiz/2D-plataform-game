using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicVolume : MonoBehaviour {

    public Slider Volumen;  //variable pública para insertar el slider al script
    public AudioSource MiMusica;    //variable pública para insertar la música al script

    void Update () {

        MiMusica.volume = Volumen.value;   //al volumen de la musica se le asigna el valor del slider

	}

    void Awake()
    {
        DontDestroyOnLoad(MiMusica.gameObject); //Evitar que la música sea destruida en tiempo de ejecución 
    }

}
