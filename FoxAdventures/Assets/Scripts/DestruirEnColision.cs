using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEnColision : MonoBehaviour 
{
    public GameObject explosionPrefab; // Prefab del objeto de explosión.

    private bool colisionHabilitada = true; // Variable para habilitar o deshabilitar la funcionalidad del colisionador.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!colisionHabilitada) // Verificar si la colisión está habilitada.
        {
            return; // Si la colisión está deshabilitada, salir del método.
        }

        if (other.CompareTag("Player"))
        {
            // Desactivar la funcionalidad del colisionador.
            colisionHabilitada = false;

            // Desactivar el objeto actual.
            gameObject.SetActive(false);

            // Instanciar el objeto de explosión (si se ha asignado).
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
