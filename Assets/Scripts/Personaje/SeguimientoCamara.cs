using UnityEngine;
using System.Collections;

public class SeguimientoCamara : MonoBehaviour {

    public GameObject Seguimiento; //variable para insertar el GameObject (personaje) al script
    public float SuavizadoCam; //velocidad a la que se mueve la camara (retardo)

    private Vector2 velocidad; //vector para suavizar tanto en eje X como en eje Y

	void Start () {
	
	}
	
	void Update () {
       
        //Se utiliza SmoothDamp para el seguimiento al personaje   //ref velocidad hace referencia a la velocidad en x e y (es cero)
        float posX = Mathf.SmoothDamp(transform.position.x, Seguimiento.transform.position.x+ 3.2f, ref velocidad.x, SuavizadoCam);
        float posY = Mathf.SmoothDamp(transform.position.y, Seguimiento.transform.position.y+ 1, ref velocidad.y, SuavizadoCam);

        //se le asigna la posición en X e Y a la camara
        transform.position = new Vector3(posX, posY, transform.position.z); //la posicion Z se deja igual

    }
}
