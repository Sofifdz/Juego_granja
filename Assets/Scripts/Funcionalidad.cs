using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funcionalidad : MonoBehaviour
{
    public Transform jugador;
    [SerializeField] float velocidad_movimiento = 2f;
    public float detect = 5.0f;
    private bool isOpen = false;
    private Vector3 posicionCerrada;
    private Vector3 posicionAbierta;

    void Start()
    {
       
        posicionCerrada = transform.position;
        posicionAbierta = transform.position + transform.right * 2; 
    }
    
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);
        
        if (distancia < detect && !isOpen)
        {
            Open();
        }
        else if (distancia >= detect && isOpen)
        {
            Close();
        }
        
        // Suavizamos la transición de movimiento con Lerp
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, posicionAbierta, velocidad_movimiento * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, posicionCerrada, velocidad_movimiento * Time.deltaTime);
        }
    }

    void Open()
    {
        isOpen = true;
    }

    void Close()
    {
        isOpen = false;
    }
}
