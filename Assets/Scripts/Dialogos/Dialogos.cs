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
