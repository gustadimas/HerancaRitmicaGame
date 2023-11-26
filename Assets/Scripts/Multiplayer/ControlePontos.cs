using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlePontos : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject painelVitoria;
    [SerializeField] Slider barra;
    [SerializeField] TMP_Text mensagemVitoria;
    int pontosP1;
    int pontosP2;
    void Start()
    {
        painelVitoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ContabilizarPontos();
    }

    [PunRPC]
    void ContabilizarPontos()
    {
        foreach (var jogador in PhotonNetwork.PlayerList)
        {
            if (jogador.ActorNumber == 1)
            {
                pontosP1 = jogador.GetScore();
            }
            if (jogador.ActorNumber == 2)
            {
                pontosP2 = -jogador.GetScore();
            }
        }
        barra.value = pontosP1 + pontosP2;
        if (!InstanciarNota.audioSource.isPlaying && InstanciarNota.musicaTocando)
        {
            TerminouJogo();
        }
    }

    void TerminouJogo()
    {
        painelVitoria.SetActive(true);
        if (barra.value == 50)
        {
            mensagemVitoria.text = "EMPATE";
            Invoke(nameof(VoltarMenu), 3f);
        }
        if (barra.value < 50)
        {
            mensagemVitoria.text = "JOGADOR 2 VENCEU!";
            Invoke(nameof(VoltarMenu), 3f);
        }
        if (barra.value > 50)
        {
            mensagemVitoria.text = "JOGADOR 1 VENCEU!";
            Invoke(nameof(VoltarMenu), 3f);
        }
    }

    void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
