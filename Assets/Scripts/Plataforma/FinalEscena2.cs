using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalEscena2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)         // cuando el objeto player colisiona con el totem cambia de nivel
    {
        if (other.name == "Personaje 1")
        {
            Puntaje.score = 0;
            SceneManager.LoadScene("Escenario 3", LoadSceneMode.Single);
        }
    }
}
