using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Mh : MonoBehaviour
{

    public static Mh mh;

    public float speed = 3;    //velocidad a la que se mueve la plataforma
    public bool m_derecha = true;   //verifica si se mueve a la derecha
    int x_actual;
    public int LimiteDerecho = 5;    //x derecha y x izquierda
    public int LimiteIzq = 5;

    void Start()
    {

         x_actual = Convert.ToInt32(transform.position.x);  //se obtiene la posición actual de la plataforma
         LimiteDerecho = x_actual + LimiteDerecho;    //se le agrega el limite del movimiento a la derecha e izquierda
         LimiteIzq = x_actual - LimiteIzq;

    }

    void Update()
    {
        // se comprueba si la plataforma llego al limite
        if (transform.position.x > LimiteDerecho)
        {
            m_derecha = false;  //si llego entonces no puede seguir el movimiento a la derecha
        }
        if (transform.position.x < LimiteIzq)
        {
            m_derecha = true;   //si llega al limite izquierdo entonces tiene que ir a la derecha
        }


        if (m_derecha == true)  //si se tiene que ir a la derecha entonces se traslada a la derecha
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else    //si derecha == false entonces se traslada a la izquierda
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)  //se ejecuta cada vez que un objeto ente dentro del trigger
    {
        // Incluímos como hijo de la plataforma a cualquier objeto que se pose sobre ella (personaje)

        collision.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Excluímos como hijo de la plataforma a cualquier objeto que se separe de ella

        collision.transform.parent = null;

    }
}
