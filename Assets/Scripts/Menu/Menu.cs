using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    float value;

    private void Start()
    {
        mixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Fase 1");
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
