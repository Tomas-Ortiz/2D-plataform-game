using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour {


    public AudioClip RecogerMoneda; //audioclip para insertarle sonido al script cuando recoge moneda
    AudioSource sonido;

    void Start () {

        sonido = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D (Collider2D obj)
    {
        
        if (obj.gameObject.name == "Personaje 1")   //si la moneda colisiona con el personaje entonces
        {
            sonido.clip = RecogerMoneda;   //se le asigna al audiosource el sonido de recoger moneda

            sonido.Play();  //se reproduce el sonido

            Puntaje.score = Puntaje.score + 10; //Puntaje clase estática para acceder al score, que se le suma 10

            Destroy(gameObject, 0.177f);
            //por último se destruye el gameObject(moneda) con delay para que tener tiempo que se reproduzca la musica

        }




    }


}
