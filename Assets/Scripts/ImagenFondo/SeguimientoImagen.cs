using UnityEngine;
using System.Collections;

public class SeguimientoImagen : MonoBehaviour {

    public float Velocidad = 0.5f;  //variable pública que puede ser modificada en el inspector
     Renderer rend; //se crea objeto de tipo Renderer 

	void Start () {

        rend = GetComponent<Renderer>();    //la variable rend obtiene el componente 
	}
	
	void Update () {

        //se le asigna la velocidad (constante) en el eje X, y en eje Y se deja igual
        Vector2 Desplazamiento = new Vector2(Time.time * Velocidad, 0f); 

        rend.material.mainTextureOffset = Desplazamiento;  //se le asigna el desplazamiento (velocidad) al renderer
	
	}
}
