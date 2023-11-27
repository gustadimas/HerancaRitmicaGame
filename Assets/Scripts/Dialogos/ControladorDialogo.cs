using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ControladorDialogo : MonoBehaviour
{
    [Header("Itens da Caixa de Diálogo:")]
    [SerializeField] Image npcImage;
    [SerializeField] TextMeshProUGUI npcNome;
    [SerializeField] TextMeshProUGUI textoMensagem;
    [SerializeField] public RectTransform backgroundCaixa;
    [SerializeField] GameObject botaoInteragir;

    Mensagem[] mensagemAtual;
    NPC[] npcAtual;
    int mensagemAtiva = 0;
    public static bool dialogoAtivo = false;
    public static bool comecarDialogo = false;
    AtivarDialogo abrirDialogo = null;

    DialogoFinal dialogoFinal;

    Jogador jogador;

    void Awake()
    {
        botaoInteragir.SetActive(false);
        backgroundCaixa.transform.localScale = Vector3.zero;
        jogador = FindObjectOfType<Jogador>();
    }

    private void Update()
    {
        if (AtivarDialogo.dialogoCollider)
            botaoInteragir.SetActive(true);
        else
            botaoInteragir.SetActive(false);
    }

    public void AbrirDialogo(Mensagem[] mensagens, NPC[] npcs, AtivarDialogo _abrirDialogo, DialogoFinal _dialogoFinal)
    {
        dialogoFinal = _dialogoFinal;
        abrirDialogo = _abrirDialogo;
        npcAtual = npcs;
        mensagemAtual = mensagens;
        mensagemAtiva = 0;
        dialogoAtivo = true;
        jogador.AlterarEstadoAnimacao(estadoMovimento.falando);

        print("O Diálogo Começou! Mensagens Carregadas: " + mensagens.Length);

        comecarDialogo = true;

        MensagemTela();

        backgroundCaixa.LeanScale(Vector3.one, 0.5f);
    }

    private void MensagemTela()
    {
        if (mensagemAtiva < mensagemAtual.Length)
        {
            Mensagem mostrarMensagem = mensagemAtual[mensagemAtiva];
            textoMensagem.text = mostrarMensagem.mensagens;

            NPC npcParaMostrar = npcAtual[mostrarMensagem.npcID];
            dialogoFinal?.AnimacaoFinal(mostrarMensagem.npcID);
            npcNome.text = npcParaMostrar.nome;
            npcImage.sprite = npcParaMostrar.sprite;

            CorDoTextoAnimado();
        }
    }

    public void ProximaMensagem()
    {
        mensagemAtiva++;

        if (mensagemAtiva < mensagemAtual.Length)
        {
            MensagemTela();
        }
        else
        {
            backgroundCaixa.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            dialogoAtivo = false;

            if (abrirDialogo != null)
            {
                StartCoroutine(abrirDialogo.CarregarCenaAposDialogo());
            }
        }
    }

    void CorDoTextoAnimado()
    {
        LeanTween.textAlpha(textoMensagem.rectTransform, 0, 0);
        LeanTween.textAlpha(textoMensagem.rectTransform, 1, 0.5f);
    }

    public void BotaoDialogo()
    {
        if (AtivarDialogo.dialogoCollider)
        {
            GameObject[] _npcs = GameObject.FindGameObjectsWithTag("NPC");

            foreach (GameObject _npc in _npcs)
            {
                _npc.GetComponent<AtivarDialogo>()?.ComecarDialogo();
            }
        }
    }
}