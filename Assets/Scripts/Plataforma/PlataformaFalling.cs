using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour
{
    public float fallDelay = 0.5f;  //variable para el tiempo de caida de la plataforma 
    public float respawnDelay = 5f; //variable para el tiempo de reaparicion de la plataforma

    private Rigidbody2D rb2d;   //creamos una variable rigidbody
    private PolygonCollider2D pc2d; //creamos una variable del colisionador
    private Vector3 start;  //vector para guardar la posicion inicial de la plataforma

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //al iniciar accedemos al riggidbody y al colisionador poligonal
        pc2d = GetComponent<PolygonCollider2D>();
        start = transform.position; //se guarda la posición inicial
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje 1"))  //si el personaje colisiona con el objeto
        {
            Invoke("Fall", fallDelay);  //invocamos al metodo fall 
            Invoke("Respawn", fallDelay + respawnDelay);    //invocamos el metodo respawn
        }
    }
        private void Fall(){    // metodo para que caiga la plataforma
            rb2d.isKinematic = false; //para que al rigid body del objeto le afecte la gravedad
            pc2d.isTrigger = true;  //cuando cae la plataforma, la misma no puede colisionar
    }

    private void Respawn()
    {
        transform.position = start; //la plataforma se reubica al principio
        rb2d.isKinematic = true;        //volvemos a poner en true a la gravedad 
        rb2d.velocity = Vector3.zero;   //velocidad de reaparicion 
        pc2d.isTrigger = false;
    }
}

