using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class HandlerUI : MonoBehaviour
{
    public static HandlerUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI contMonedasTexto;  
    [SerializeField] private TextMeshProUGUI TextoTiempo;       

    public float contSegundos;
    private float tiempoTranscurrido;
    public int monedas;   

    [SerializeField] public GameObject mensaje1;   
    [SerializeField] public GameObject mensaje2;   
    [SerializeField] private TextMeshProUGUI contBasura;
    

       

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        mensaje1.SetActive(false);
        mensaje2.SetActive(false);
        MostrarDialogo();
        //contSegundos = 200;
        tiempoTranscurrido = 0;
       
    }

    void Update()
    {
        /*if (contSegundos > 0)
        {
            tiempoTranscurrido += Time.deltaTime;
            if (tiempoTranscurrido >= 1.0f)
            {
                contSegundos--;
                tiempoTranscurrido = 0;
                TextoTiempo.text = contSegundos.ToString(); 
            }
        }*/
    }
    public void ActualizarContadorBasura(int contador)
    {
        contBasura.text =  contador.ToString()+"/31";  
    }

    public void MostrarDialogo()
    {
         if (SceneManager.GetActiveScene().name == "Dinamica1")
        {
            mensaje1.SetActive(true);
        }
    }
    public void cambioDialogo()
    {
        mensaje1.SetActive(false);
        mensaje2.SetActive(true);
        StartCoroutine(OcultarImagen(mensaje2));
    }

    private IEnumerator OcultarImagen(GameObject imagen)
    {
        yield return new WaitForSeconds(5);
        if (imagen != null)
        {
            imagen.SetActive(false);
        }
    }

   
   
   
    
}
