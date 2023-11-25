using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorDialogo : MonoBehaviour
{
    [Header("Itens da Caixa de Diálogo:")]
    [SerializeField] Image npcImage;
    [SerializeField] TextMeshProUGUI npcNome;
    [SerializeField] TextMeshProUGUI textoMensagem;
    [HideInInspector] public RectTransform backgroundCaixa;

    Mensagem[] mensagemAtual;
    NPC[] npcAtual;
    int mensagemAtiva = 0;
    public static bool dialogoAtivo = false;
    public static bool comecarDialogo = false;

    void Start()
    {
        backgroundCaixa.transform.localScale = Vector3.zero;
    }

    public void AbrirDialogo(Mensagem[] mensagens, NPC[] npcs)
    {
        npcAtual = npcs;
        mensagemAtual = mensagens;
        mensagemAtiva = 0;
        dialogoAtivo = true;

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
            npcNome.text = npcParaMostrar.nome;
            npcImage.sprite = npcParaMostrar.sprite;

            CorDoTextoAnimado();
        }
    }

    public void ProximaMensagem()
    {
        mensagemAtiva++;

        if (mensagemAtiva < mensagemAtual.Length)
            MensagemTela();

        else
        {
            print("O Diálogo Acabou!");
            backgroundCaixa.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            dialogoAtivo = false;
        }
    }

    void CorDoTextoAnimado()
    {
        LeanTween.textAlpha(textoMensagem.rectTransform, 0, 0);
        LeanTween.textAlpha(textoMensagem.rectTransform, 1, 0.5f);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && dialogoAtivo == true)
            ProximaMensagem();
    }
}