using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Enemigo : MonoBehaviour
{
    CalcularDistancia_Enemigo auxComponenteDistance;
    Transform ubi_personaje;

    private void Awake(){
        ubi_personaje = GameObject.Find("Jugador").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        auxComponenteDistance = GetComponent<CalcularDistancia_Enemigo>();

    }

    // Update is called once per frame
    void Update()
    {
        float distanciaAlEnemigo = auxComponenteDistance.getDistance();
        if(distanciaAlEnemigo < 5.5f){ // umbral de distancia con el personaje
            float velocidad = 1f * Time.deltaTime;
            transform.position = 
                Vector3.MoveTowards(transform.position, ubi_personaje.position, velocidad);
    }
}
}