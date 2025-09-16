using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ManagerLife : MonoBehaviour
{
    Image valorVida;

    [SerializeField] float vida; 
    
    
    private void Start()
    {
        vida = 1; 
        valorVida = GameObject.Find("Vida").GetComponent<Image>(); 
        valorVida.fillAmount = vida; 
       
    }

    public void AumentarVida(float cantidad)
    {
       
        vida += cantidad;
        vida = Mathf.Clamp(vida, 0, 1); 
        valorVida.fillAmount = vida; 
    }

    
}