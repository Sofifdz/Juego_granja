using System.Collections;
using System.Collections.Generic;
using EasyPrimitiveAnimals;
using UnityEngine;

public class DesactMov_Vaca : MonoBehaviour
{
    public bool enemigoMovimientoActivo;
    public bool Animalcontrolleractivo;
    [SerializeField] public GameObject mensajeIncorrecto;

    public string tagAComprobar;
    private int contadorAnimales = 0; 

    private void Start()
    {
        enemigoMovimientoActivo = true;
        Animalcontrolleractivo = true;
        mensajeIncorrecto.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagAComprobar))
        {
           
            contadorAnimales++;
            Debug.Log("Contador de animales incrementado. Total: " + contadorAnimales);

           
            if (contadorAnimales == 20)
            {
                Debug.Log("¡Has alcanzado 20 animales!");
                
            }

          
            Movimiento_Enemigo movimiento = other.GetComponent<Movimiento_Enemigo>();
            if (movimiento != null)
            {
                movimiento.enabled = false;
                enemigoMovimientoActivo = false;
                Debug.Log("Movimiento del enemigo desactivado");
            }

          
            AnimalController animalController = other.GetComponent<AnimalController>();
            if (animalController != null)
            {
                animalController.enabled = false;
                Animalcontrolleractivo = false;
                Debug.Log("Animal controller desactivado");
            }

            return; 
        }

        // Si el tag no coincide, mostrar mensaje incorrecto
        //Debug.Log("Panel incorrecto, tag no coincide.");
        //mensajeIncorrecto.SetActive(true);
        //StartCoroutine(OcultarDialogo(mensajeIncorrecto));
    }

    /*private IEnumerator OcultarDialogo(GameObject dialogo)
    {
        yield return new WaitForSeconds(2);
        if (dialogo != null)
        {
            dialogo.SetActive(false);
        }
    }*/
}
