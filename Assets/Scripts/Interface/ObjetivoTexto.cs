using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjetivoTexto : MonoBehaviour
{
    public TextMeshProUGUI textoObjetivo;
    public Image fundoImagem;
    public float duracaoTexto = 5f;
    public float duracaoVisivel = 3f; 
    public static bool textoAtivo = true;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = fundoImagem.GetComponent<CanvasGroup>();
        MostrarTextoObjetivo();
    }

    void Update()
    {
        if (textoAtivo)
        {
            duracaoTexto -= Time.deltaTime;

            float escala = Mathf.Lerp(1f, 0f, (duracaoTexto / 5f));
            textoObjetivo.transform.localScale = new Vector3(escala, escala, escala);

            if (escala <= 1f)
            {
                if (duracaoTexto <= duracaoVisivel)
                {
                    canvasGroup.alpha = 1f;
                }
                else
                {
                    float alpha = Mathf.Lerp(1f, 0f, (duracaoTexto - duracaoVisivel) / (5f - duracaoVisivel));
                    canvasGroup.alpha = alpha;
                }
            }

            if (duracaoTexto <= 0f)
            {
                textoAtivo = false;
                textoObjetivo.gameObject.SetActive(false);
                fundoImagem.gameObject.SetActive(false);
            }
        }
    }

    void MostrarTextoObjetivo()
    {
        textoObjetivo.text = "Objetivo: Encontre o Ancião(a) local!";
        textoObjetivo.gameObject.SetActive(true);
        textoAtivo = true;

        fundoImagem.gameObject.SetActive(true);
    }
}
