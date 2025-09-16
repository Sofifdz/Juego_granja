using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt_Player : MonoBehaviour
{
    Transform ubi_obj_a_mirar;
    CalcularDistancia_Enemigo auxComponenteDistance;

    private void Awake(){
        ubi_obj_a_mirar = GameObject.Find("Jugador").GetComponent<Transform>();
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
        if(distanciaAlEnemigo < 3.5f){ // umbral de distancia con el personaje
            float valY = ubi_obj_a_mirar.position.y;

            if (valY>3.0f){// si esta por encima del humbral (3.0f)
            transform.LookAt(new Vector3(
                ubi_obj_a_mirar.position.x,
                3.0f,
                ubi_obj_a_mirar.position.z
            ));
        }
            else{
                transform.LookAt(ubi_obj_a_mirar.position);

            }
    }
    }
    }

//Vinculacion de componentes es así...
//componentes en el Start
//los GameObjects en el awakeusing System.Collections;
