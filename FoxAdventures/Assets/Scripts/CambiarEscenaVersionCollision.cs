using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaVersionCollision : MonoBehaviour
{
    public string nombreDeLaEscenaACambiar; // Reemplaza con el nombre de la escena a la que deseas cambiar.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto con el que colisionamos tiene la etiqueta "Player".
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiar a la escena especificada.
            SceneManager.LoadScene(nombreDeLaEscenaACambiar);
        }
    }
}
