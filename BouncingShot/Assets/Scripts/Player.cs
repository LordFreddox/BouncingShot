using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class Player : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody, spawnPoint;
    public GameObject sphere, failUI;
    private float xRotation = 0f;
    public int maxBullets=5;
    public Text countBullets;
    private SoundManager soundManager;
    public AudioSource audio;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        countBullets.text = maxBullets.ToString();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Movimiento de la cámara con el ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Disparo
        if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" por el nombre de tu botón de disparo si es diferente
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Verifica si se asignó un prefab de esfera y un punto de aparición
        if (sphere != null && spawnPoint != null)
        {
            if (maxBullets > 0 && Time.timeScale>0) { 
            // Instancia el prefab de la esfera en el punto de aparición
            GameObject bullet = Instantiate(sphere, spawnPoint.position, spawnPoint.rotation);
                maxBullets--;
                countBullets.text = maxBullets.ToString();
                audio.Play();
                // Obtén el componente Rigidbody del prefab de la esfera
                Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // Comprueba si el Rigidbody existe en el prefab
            if (rb != null)
            {
                // Aplica una fuerza hacia adelante al Rigidbody del prefab de la esfera
                rb.AddForce(spawnPoint.forward * 1000f);
            }
            else
            {
                Debug.LogError("El prefab de la esfera no tiene un componente Rigidbody.");
            }
            }
            else if (maxBullets <= 0)
            {
                Time.timeScale = 0f;
                failUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            Debug.LogError("Prefab de la esfera o punto de aparición no asignados en el Inspector.");
        }
    }
}
