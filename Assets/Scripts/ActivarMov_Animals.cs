using System.Collections;
using System.Collections.Generic;
using EasyPrimitiveAnimals;
using UnityEngine;

public class ActivarMov_Animals : MonoBehaviour
{
   
    public bool enemigoMovimientoActivo;
    public bool Animalcontrolleractivo;

    private void Start()
    {
        
        enemigoMovimientoActivo = false;
        Animalcontrolleractivo = false;

       
        Movimiento_Enemigo movimiento = GetComponent<Movimiento_Enemigo>();
        if (movimiento != null)
        {
            movimiento.enabled = false;
        }

        AnimalController animalController = GetComponent<AnimalController>();
        if (animalController != null)
        {
            animalController.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Jugador"))
        {
            Movimiento_Enemigo movimiento = GetComponent<Movimiento_Enemigo>();
            if (movimiento != null)
            {
                movimiento.enabled = true;
                enemigoMovimientoActivo = true;
                Debug.Log("Movimiento del enemigo activado.");
            }

            AnimalController animalController = GetComponent<AnimalController>();
            if (animalController != null)
            {
                animalController.enabled = true;
                Animalcontrolleractivo = true;
                Debug.Log("Animal controller activado.");
            }
        }
    }
}
