using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControlMensajes : MonoBehaviour
{
    public Canvas canvasDialogo;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    public KeyCode cerrarCanvasKey = KeyCode.X;

    private bool juegoPausado = false;
    private int currentLine = 0;
    private bool colliderDestroyed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliderDestroyed && other.CompareTag("Player"))
        {
            PausarJuego();
            MostrarDialogo();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OcultarDialogo();
            ReanudarJuego();
            // Destruir el objeto con el Box Collider al salir para que no se active nuevamente
            Destroy(gameObject);
            colliderDestroyed = true;
        }
    }

    private void MostrarDialogo()
    {
        // Verificar si el objeto canvasDialogo sigue existiendo
        if (canvasDialogo != null)
        {
            // Verificar si el componente dialogueText no es null antes de acceder a su propiedad text
            if (dialogueText != null)
            {
                // Verificar si hay líneas de diálogo disponibles
                if (dialogueLines != null && dialogueLines.Length > 0)
                {
                    dialogueText.text = dialogueLines[currentLine];
                }
                else
                {
                    // Manejo de caso donde el array de líneas de diálogo es null o está vacío
                    Debug.LogError("No se asignaron líneas de diálogo en el Inspector.");
                }
            }
            else
            {
                // Manejo de caso donde el componente es null
                Debug.LogError("No se asignó el componente TMP_Text en el Inspector.");
            }

            canvasDialogo.gameObject.SetActive(true);
            Time.timeScale = 0f; // Pausar el juego
        }
        else
        {
            // Manejo de caso donde el objeto canvasDialogo ha sido destruido
            Debug.LogError("El objeto canvasDialogo ha sido destruido.");
        }
    }

    private void OcultarDialogo()
    {
        // Verificar si el objeto canvasDialogo sigue existiendo antes de acceder a sus componentes
        if (canvasDialogo != null)
        {
            canvasDialogo.gameObject.SetActive(false);
            Time.timeScale = 1f; // Reanudar el juego
        }
        else
        {
            // Manejo de caso donde el objeto canvasDialogo ha sido destruido
            Debug.LogError("El objeto canvasDialogo ha sido destruido.");
        }
    }

    private void PausarJuego()
    {
        juegoPausado = true;
        //Time.timeScale = 0f; // Pausar el juego
    }

    private void ReanudarJuego()
    {
        juegoPausado = false;
        //Time.timeScale = 1f; // Reanudar el juego
    }

    private void Update()
    {
        if (juegoPausado && Input.GetKeyDown(cerrarCanvasKey))
        {
            if (dialogueLines != null && currentLine < dialogueLines.Length - 1)
            {
                currentLine++;
                MostrarDialogo();
            }
            else
            {
                OcultarDialogo();
                ReanudarJuego();
            }
        }
    }
}
