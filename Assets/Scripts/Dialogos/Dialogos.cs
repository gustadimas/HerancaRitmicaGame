using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Dialogos : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] public RectTransform backgroundCaixa;
    [SerializeField] GameObject[] tambores;
    public static bool dialogoAtivo = true;
    Scene cenaAtual;

    void Start()
    {
        cenaAtual = SceneManager.GetActiveScene();
        backgroundCaixa.transform.localScale = Vector3.zero;
        textoDialogo.text = "";
    }

    void Update()
    {
        if (dialogoAtivo)
        {
            for (int i = 0; i < tambores.Length; i++)
            {
                tambores[i].SetActive(false);
            }
            IniciarDialogo();
        }
    }

    void IniciarDialogo()
    {
        backgroundCaixa.LeanScale(Vector3.one, 0.5f);

        if (cenaAtual.name == "SambaDeRoda" && DestruirNotas.venceuSamba)
            textoDialogo.text = "Não tenho mais nada a te ensinar, Amina. Tenho certeza de que será bem sucedida em seu objetivo, e eu, junto com todos os outros, aguardamos ansiosamente o seu retorno. Agora, vá!";

        if (cenaAtual.name == "Jongo" && DestruirNotas.venceuJongo)
        {
            textoDialogo.text = "Amina, minha querida, seus passos no Jongo ecoaram como o pulsar do coração da nossa comunidade. Continue dançando com a força dos nossos ancestrais.";
        }
        else if (cenaAtual.name == "Jongo" && !DestruirNotas.venceuJongo)
        {
            textoDialogo.text = "Não se desanime, pois a dança é um fluxo constante, e cada movimento é uma chance de aprender e evoluir. Continue dançando com o coração, e vamos tentar mais uma vez! ";
        }

        if (cenaAtual.name == "Sussa" && DestruirNotas.venceuSussa)
        {
            textoDialogo.text = "Parabéns, Amina. Você captou a verdadeira essência da Sussa. Continue a dançar com o coração, pois cada passo é uma celebração da nossa herança.";
        }
        else if (cenaAtual.name == "Sussa" && !DestruirNotas.venceuSussa)
        {
            textoDialogo.text = "Ainda não está certo, Amina. Você precisa colocar mais paixão! Vamos tentar mais uma vez, sim?";
        }
    }
}
