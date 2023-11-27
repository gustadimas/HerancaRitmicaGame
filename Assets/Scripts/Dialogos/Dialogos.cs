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
            textoDialogo.text = "N�o tenho mais nada a te ensinar, Amina. Tenho certeza de que ser� bem sucedida em seu objetivo, e eu, junto com todos os outros, aguardamos ansiosamente o seu retorno. Agora, v�!";

        if (cenaAtual.name == "Jongo" && DestruirNotas.venceuJongo)
        {
            textoDialogo.text = "Amina, minha querida, seus passos no Jongo ecoaram como o pulsar do cora��o da nossa comunidade. Continue dan�ando com a for�a dos nossos ancestrais.";
        }
        else if (cenaAtual.name == "Jongo" && !DestruirNotas.venceuJongo)
        {
            textoDialogo.text = "N�o se desanime, pois a dan�a � um fluxo constante, e cada movimento � uma chance de aprender e evoluir. Continue dan�ando com o cora��o, e vamos tentar mais uma vez! ";
        }

        if (cenaAtual.name == "Sussa" && DestruirNotas.venceuSussa)
        {
            textoDialogo.text = "Parab�ns, Amina. Voc� captou a verdadeira ess�ncia da Sussa. Continue a dan�ar com o cora��o, pois cada passo � uma celebra��o da nossa heran�a.";
        }
        else if (cenaAtual.name == "Sussa" && !DestruirNotas.venceuSussa)
        {
            textoDialogo.text = "Ainda n�o est� certo, Amina. Voc� precisa colocar mais paix�o! Vamos tentar mais uma vez, sim?";
        }
    }
}
