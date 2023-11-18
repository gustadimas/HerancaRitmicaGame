using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCenas : MonoBehaviour
{
    [HideInInspector] public static bool quingoma, quilombo1, quilombo2, quilombo3 = false;

    public void Quingoma_Mapa()
    {
        SceneManager.LoadScene("Mapa");
        quingoma = true;
    }

    public void Quilombo1_Mapa()
    {
        SceneManager.LoadScene("Mapa");
        quilombo1 = true;
    }

    public void Quilombo2_Mapa()
    {
        SceneManager.LoadScene("Mapa");
        quilombo2 = true;
    }

    public void Quilombo3_Mapa()
    {
        SceneManager.LoadScene("Mapa");
        quilombo3 = true;
    }
}