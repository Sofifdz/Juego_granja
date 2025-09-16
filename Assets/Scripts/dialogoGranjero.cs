using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogoGranjero : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject mensajeGranjero; 
    void Start()
    {
        mensajeGranjero.SetActive(false);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) 
        {
           mensajeGranjero.SetActive(true);
           StartCoroutine(OcultarDialogo(mensajeGranjero));
        }
        

       
    }
    private IEnumerator OcultarDialogo(GameObject dialogo)
    {
        yield return new WaitForSeconds(3);
        if (dialogo != null)
        {
            dialogo.SetActive(false);
        }
    }
}
