using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RayoCast : MonoBehaviour
{
    private int contadorBasura = 0;
    private int limiteBasura = 31;
    private float alcanceRayo = 5f;
    [SerializeField] public GameObject mensajeDinamica2;
    [SerializeField] public GameObject mensajeDinamica2_2;
    [SerializeField] public GameObject contador;


    private Vector3 direccionFija = Vector3.forward;

    private void Start()
    {
        mensajeDinamica2.SetActive(false);
        mensajeDinamica2_2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (contadorBasura >= limiteBasura)
            {
                Debug.Log("Se ha alcanzado el límite de objetos destruidos. Raycast desactivado.");
                contador.SetActive(false);
                mensajeDinamica2.SetActive(true);
                return;
            }

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(direccionFija), out hit, alcanceRayo))
            {
                Debug.Log("Colisiona con un objeto");

                if (hit.collider.CompareTag("Basura"))
                {
                    Debug.Log("Destruyendo objeto: " + hit.collider.gameObject.name);
                    Destroy(hit.collider.gameObject);
                    contadorBasura++;

                    // Actualizar el contador de basura en el UI
                    HandlerUI.Instance.ActualizarContadorBasura(contadorBasura);


                    Debug.Log("Objetos destruidos: " + contadorBasura);
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(direccionFija) * hit.distance, Color.green);
            }
            else
            {
                Debug.Log("No colisiona");
                Debug.DrawRay(transform.position, transform.TransformDirection(direccionFija) * alcanceRayo, Color.red);
            }
        }
    }
    public void cambioMensaje()
    {
        mensajeDinamica2.SetActive(false);
        mensajeDinamica2_2.SetActive(true);
        StartCoroutine(OcultarDialogo(mensajeDinamica2_2));
    }
    private IEnumerator OcultarDialogo(GameObject dialogo)
    {
        yield return new WaitForSeconds(5);
        if (dialogo != null)
        {
            dialogo.SetActive(false);
        }
    }
}
