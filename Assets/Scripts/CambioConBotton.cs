using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioConBotton : MonoBehaviour
{
   
   
    private void Start()
    {
        
    }
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }
}
