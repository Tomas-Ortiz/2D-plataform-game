using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Meteorito : MonoBehaviour {

    public float VelCaida = 3;  //velocidad a la que cae el meteorito
    bool MovAbajo = true;
    int Yactual;

    public int LimiteInf = 40;  //limite inferior del meteorito


	void Start () {

        Yactual = Convert.ToInt32(transform.position.y);    //se obtiene la posición actual del obj en Y
        LimiteInf = Yactual - LimiteInf;    //se obtiene el limite inferior según la posición actual

    }

    void Update () {

        if (transform.position.y > LimiteInf)   //si la posicion en Y es mayor al limite entonces se mueve hacia abajo
        {
            MovAbajo = true;
        }
        else if(transform.position.y <LimiteInf)    //si la posición en Y es menor entonces no se mueve hacia abajo
        {
            MovAbajo = false;
        }

        if (MovAbajo == true)   //si se puede mover hacia abajo entonces se traslada hacia abajo
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - VelCaida * Time.deltaTime);
        }
        else  //Si se supera el limite (posY<LimiteInf) entonces se le vuelve asignar la posicion inicial
        {
            transform.position = new Vector2(transform.position.x, Yactual);

        }

    }
}
