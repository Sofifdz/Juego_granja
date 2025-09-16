using System.Collections;
using UnityEngine;

public class S_CameraShake : MonoBehaviour
{
    public AudioClip screamSound; 
    private AudioSource audioSource; 

    [SerializeField]
    Transform cam; //agregar la camara desde inspector

    [SerializeField] float duracion; //en segundos
    [SerializeField] float amplitud;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = screamSound; 

        if (cam == null)
        {
            cam = GameObject.Find("Main Camera").transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("Jugador tocado"); 
            audioSource.Play();
            StartCoroutine(ShakeCamera()); 
        }
    }

    IEnumerator ShakeCamera()
    {
        Vector3 posicion_original = cam.position; //or localposition
        float transcurrido = 0f;
        float x, y; //podria tambien ser z (profundidad)

        while (transcurrido < duracion)
        {
            x = Random.Range(-1f, 1f) * amplitud; //max = 1 min  = 0
            y = Random.Range(-1f, 1f) * amplitud;

            cam.position = new Vector3(posicion_original.x + x,
                                       posicion_original.y + y,
                                       posicion_original.z);

            transcurrido += Time.deltaTime;

            yield return null;
        }

        cam.position = posicion_original; 
    }
}
