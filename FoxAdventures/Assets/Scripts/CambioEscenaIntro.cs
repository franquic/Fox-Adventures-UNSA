using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    private string nombreEscena = "Level 0";

    public void LoadScene()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
