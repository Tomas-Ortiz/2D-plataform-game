using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class ControlPersonaje : MonoBehaviour {

    public Animator anim;   //animator para asignarle la animación del personaje al script
    Rigidbody2D Personaje;  //se controla el movimiento fisico y la posición del personaje 
    public float Velocidad; //velocidad a la que corre el personaje

    SpriteRenderer PersonajeRender; //Se crea un SpriteRenderer para manipular el sprite del personaje

   public float FuerzaDeSalto;  //variable para controlar la altura del salto
   private bool EnSuelo = true; //variable booleana para verificar si está en suelo
   private bool DobleSalto = true;  //variable booleana para verificar si dispone del doble salto


    void Start() {

        Personaje = GetComponent<Rigidbody2D>();
        PersonajeRender = GetComponent<SpriteRenderer>();   //se obtienen los componentes del objeto
        anim = GetComponent<Animator>();

	}


    void OnCollisionEnter2D(Collision2D collision)   //Si el personaje se mantiene sobre esa colision (suelo)
    {
        if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Plataforma")    
        {
           anim.SetBool("EnSuelo", true);   //si personaje colisiona con el suelo o la plataforma movible entonces ensuelo = true
            EnSuelo = true;
        }

        if (collision.gameObject.tag == "Meteorito")
        {
            Personaje.position = new Vector2(-53.02f, -34.94f); //si el personaje se cae al vacío pierde y pierde el puntaje
            Puntaje.score = 0;


            vidas.restar();

            if (vidas.lives == 0)
            {

                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");

            }
        }

    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Plataforma")  //si el personaje deja de colisionar con suelo entonces suelo = false
        {
            anim.SetBool("EnSuelo", false);
            EnSuelo = false;
        }
    }
 
    void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {

            SceneManager.LoadScene("Escenario 1");
            Personaje.position = new Vector2(-53.02f, -34.94f);
        }


        float mover = Input.GetAxis("Horizontal");  //devuelve un valor entre -1 y 1 (1 si se mueve en x positivo, y -1 en x negativo)
        
        //se le asigna la velocidad de movimiento al personaje
        Personaje.velocity = new Vector2(mover*Velocidad, Personaje.velocity.y); //solo queremos que se mueva en eje X

        if (mover>0)    //si mover es 1 (se mueve a la derecha) entonces no se da vuelta el srpite 
        {
            PersonajeRender.flipX = false; 

        }
        else if(mover<0)    //si mover es -1 (se mueve a la izq) entonces se da vuelta el sprite
        {
            PersonajeRender.flipX = true;

        }

	
        if(Input.GetKey("d") || Input.GetKey("a"))  //si se aprieta "d" o "a" para moverse entonces
        {
            anim.SetBool("Correr", true);   //se activa la animación de correr
        }
        else
       {
           anim.SetBool("Correr", false);   
        }

        if(EnSuelo==true)   //se verifica si el personaje está en suelo
        {
           DobleSalto = true;   //si está en suelo entonces dispone del doble salto
        }

        if (Input.GetKeyDown(KeyCode.W) && EnSuelo==true) //se le coloca Down para detectar si se salta una vez, y no constantemente
        {
            anim.SetBool("Saltar", true);   //si se aprieta W y está en suelo entonces se hace la animación de saltar
            Personaje.AddForce(new Vector2 (0, FuerzaDeSalto)); //se le agrega una fuerza de salto en el eje Y

        }
        else
        {
            anim.SetBool("Saltar", false);  

        }

        if (Input.GetKeyDown(KeyCode.W) && EnSuelo==false && DobleSalto==true)  //si no está en suelo y dispne del doble salto entonces
        {
            anim.SetBool("Saltar", true);     //se activa la animación de saltar y se le agrega la fuerza de salto
            Personaje.AddForce(new Vector2(0, FuerzaDeSalto));
            DobleSalto = false; //si ya ha hecho el doble salto entonces ya no dispone del doble salto

        }
        else
        {
            anim.SetBool("Saltar", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //si colisiona con un objeto de tipo Trigger
    {

        if (collision.gameObject.name == "Agua")    //si colisiona con el agua entonces pierde y pierde el puntaje
        {
            Personaje.position = new Vector2(-53.02f, -34.94f); //vuelva al principio

            Puntaje.score = 0;
            vidas.restar();

        }

       
        //resta vidas con limite
        if (collision.gameObject.tag == "Limite")
        {
            Personaje.position = new Vector2(-2.94f, -1.19f);
            vidas.restar();
            Puntaje.score = 0;

        }
        
        //Fin del juego por llegada de 0 vidas
        if (vidas.lives == 0)
        {
            Puntaje.score = 0;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");

        }

     
    }


}
