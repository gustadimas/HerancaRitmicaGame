using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ComecarJogo()
    {
        SceneManager.LoadScene("CutsceneInicial");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ComecarOnline()
    {
        SceneManager.LoadScene("CarregandoMultijogador");
    }
}
