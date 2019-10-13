using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalEscena1 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)         // cuando el objeto player colision con el totem cambia de nivel
    {
        if (other.name == "Personaje 1")
        {
            Puntaje.score = 0;
            vidas.lives = 3;
            SceneManager.LoadScene("Escenario 2", LoadSceneMode.Single);
        }
    }
}
