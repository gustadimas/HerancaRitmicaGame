using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Dialogos : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDialogo;
    //[SerializeField] string[] falas;
  //  [SerializeField] float delayEntreLetras;
    [SerializeField] public RectTransform backgroundCaixa;
    [SerializeField] GameObject[] tambores;
    public static bool dialogoAtivo = true;
    //int index = 0;
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

            /*if (index == 0)
            {
                if (textoDialogo.text != falas[index])
                {
                    StopAllCoroutines();
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
                }*/
            /*else if (index < falas.Length - 1)
            {
                index++;
                StartCoroutine(TipoDeFala(falas[index]));
            }*/
            /*else
                {
                    FinalizarDialogo();
                }
            }*/
        }
    }

    /*IEnumerator TipoDeFala(string fala)
    {
        textoDialogo.text = "";

        foreach (char letra in fala)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(delayEntreLetras);
        }
    }*/

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
        //StartCoroutine(TipoDeFala(falas[index]));
    }

   /* void FinalizarDialogo()
    {
        backgroundCaixa.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        dialogoAtivo = false;
        index = 0;
        gameObject.SetActive(false);
    }

    void CorDoTextoAnimado()
    {
        LeanTween.textAlpha(textoDialogo.rectTransform, 0, 0);
        LeanTween.textAlpha(textoDialogo.rectTransform, 1, 0.5f);
    }*/
}
