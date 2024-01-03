using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    private string nombreEscena = "Level0";

    public void LoadScene()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
