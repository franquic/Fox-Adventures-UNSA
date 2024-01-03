using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena;

    public void LoadScene()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
