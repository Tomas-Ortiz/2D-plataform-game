using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Mv : MonoBehaviour
{
    public float speed = 3;     //velocidad a la que se traslada la plataforma
    public bool m_arriba = true;    //puede trasladarse arriba
    int y_actual;
   public int LimiteSuperior = 2;    //Y arriba e Y abajo
   public int LimiteInferior = 2;

    void Start()
    {

        y_actual = Convert.ToInt32(transform.position.y);   //se obtiene la posición actual de la plataforma
        LimiteSuperior = y_actual + LimiteSuperior; //se establecen los limites a los que puede llegar
        LimiteInferior = y_actual - LimiteInferior;

    }

    void Update()
    {
        // se comprueba si la plataforma llego al limite
        if (transform.position.y > LimiteSuperior)
        {
            m_arriba = false;
        }
        if (transform.position.y < LimiteInferior)
        {
            m_arriba = true;
        }


        if (m_arriba == true)   //si puede ir arriba entonces se traslada hacia arriba
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else    //si no puede ir hacia arriba entonces se traslada hacia abajo
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - speed * Time.deltaTime);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)   //se ejecuta cada vez que un objeto ente dentro del trigger
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
