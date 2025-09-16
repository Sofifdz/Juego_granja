using UnityEngine;
using UnityEngine.SceneManagement;

public class ClaseSingleton : MonoBehaviour
{
    public static ClaseSingleton Instance { get; private set; }
   

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
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    public void cambioEscena(int idx)
    {
        SceneManager.LoadScene(idx);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Escena cargada: " + scene.name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
