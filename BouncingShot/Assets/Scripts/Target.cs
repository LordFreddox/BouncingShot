using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            //Cursor.visible=true;   
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
