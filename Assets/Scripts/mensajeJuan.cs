using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mensajeJuan : MonoBehaviour
{
    [SerializeField] public GameObject msjJuan; 
 
   
   
    
    void Start()
    {
        msjJuan.SetActive(false);
       
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador")) 
        {
           msjJuan.SetActive(true);
           StartCoroutine(OcultarDialogo(msjJuan));
           Time.timeScale = 0f;
          
           
        }
        

       
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
