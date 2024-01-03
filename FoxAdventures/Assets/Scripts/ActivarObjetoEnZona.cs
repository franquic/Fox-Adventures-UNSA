using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjetoEnZona : MonoBehaviour
{
    public GameObject objetoAActivar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el objeto cuando el jugador entra en la zona
            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }
            else
            {
                Debug.LogError("No se asignó el objeto a activar en el Inspector.");
            }
        }
    }
}
