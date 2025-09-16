using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarObjetos : MonoBehaviour
{
    public bool isTaken;
    public bool isObjectNextYou;
    public GameObject objectTaken;

    private Vector3 originalScale; // Escala original
    public float scaleFactor = 0.5f; // Factor para reducir la escala del objeto al tomarlo

    GameObject padre;

    private void Awake() {
        padre = GameObject.Find("Jugador");
    }

    void Start()
    {
        isTaken = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            isTaken = !isTaken; // Alterna el estado de isTaken
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("TakenObject")){
            isObjectNextYou = true;        
        }
    }

    private void OnTriggerStay(Collider other) {
        GameObject temporal = other.gameObject;

        if (temporal.CompareTag("TakenObject")){
            if (isObjectNextYou){
                if (isTaken && objectTaken == null){ // Solo toma el objeto si no hay otro en las manos
                    objectTaken = temporal;  // Guarda la instancia del objeto tomado

                    // Guardar la escala original solo una vez al tomarlo por primera vez
                    if (objectTaken.transform.parent == null) {
                        originalScale = objectTaken.transform.localScale;
                    }

                    temporal.transform.SetParent(padre.transform); // Cambia de padre
                    Rigidbody rb = temporal.GetComponent<Rigidbody>(); // Obtiene el Rigidbody
                    rb.isKinematic = true; // Activa la funcionalidad kinemática
                    rb.useGravity = false; // Desactiva la gravedad del objeto

                    temporal.transform.localScale = originalScale * scaleFactor; // Reduce la escala del objeto
                    temporal.transform.position = transform.position; // Mueve el objeto a las manos
                    temporal.transform.rotation = transform.rotation; // Ajusta la rotación del objeto
                }
                else if (!isTaken && objectTaken != null){
                    objectTaken.transform.SetParent(null); // Quita el padre
                    Rigidbody rb = objectTaken.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;

                    objectTaken.transform.localScale = originalScale; // Recupera la escala original
                    objectTaken = null; // Libera el objeto
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("TakenObject")){
            isObjectNextYou = false;
        }
    }
}
