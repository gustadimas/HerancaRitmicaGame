using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GerenciadorSala : MonoBehaviourPunCallbacks
{

    PhotonView phView;

    bool jogadoresNaSala = false;

    int tempoEspera = 12;

    public static bool comecou;

    [SerializeField] GameObject telaSincronizacaoJogadores;

    [SerializeField] GameObject jogador1, jogador2;

    void Start()
    {
        phView = GetComponent<PhotonView>();

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CriarJogadores());
        }
    }


    [PunRPC]
    void CriarJogador()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("Criando jogador 1");
            PhotonNetwork.Instantiate(jogador1.name, transform.position, Quaternion.identity);
        }
        else
        {
            print("Criando jogador 2");
            PhotonNetwork.Instantiate(jogador2.name, transform.position, Quaternion.identity);
        }
        telaSincronizacaoJogadores.SetActive(false);

    }

    IEnumerator CriarJogadores()
    {
        yield return new WaitForSeconds(tempoEspera);

        if (!jogadoresNaSala && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            photonView.RPC("CriarJogador", RpcTarget.AllBuffered);
            jogadoresNaSala = true;
        }

        if (jogadoresNaSala == false)
            StartCoroutine(CriarJogadores());
    }


}

