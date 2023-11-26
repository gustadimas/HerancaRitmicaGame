using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Dialogos : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] string[] falas;
    [SerializeField] float delayEntreLetras;
    [SerializeField] public RectTransform backgroundCaixa;

    NavMeshAgent npcNavMeshAgent;
    bool dialogoAtivo = false;
    int index = 0;

    void Start()
    {
        npcNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
        backgroundCaixa.transform.localScale = Vector3.zero;
        textoDialogo.text = "";
    }

    void Update()
    {
        if (dialogoAtivo)
        {
            if (index == 0 && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (textoDialogo.text != falas[index])
                {
                    StopAllCoroutines();
                    textoDialogo.text = falas[index];
                }
                else if (index < falas.Length - 1)
                {
                    index++;
                    StartCoroutine(TipoDeFala(falas[index]));
                }
                else
                {
                    FinalizarDialogo();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcNavMeshAgent.isStopped = true;
            index = 0;
            IniciarDialogo();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcNavMeshAgent.isStopped = false;
            dialogoAtivo = false;
            index = 0;
        }
    }

    IEnumerator TipoDeFala(string fala)
    {
        textoDialogo.text = "";

        foreach (char letra in fala)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(delayEntreLetras);
        }
    }

    void IniciarDialogo()
    {
        dialogoAtivo = true;
        backgroundCaixa.LeanScale(Vector3.one, 0.5f);
        StartCoroutine(TipoDeFala(falas[index]));
    }

    void FinalizarDialogo()
    {
        npcNavMeshAgent.isStopped = false;
        backgroundCaixa.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        dialogoAtivo = false;
        index = 0;
        gameObject.SetActive(false);
    }

    void CorDoTextoAnimado()
    {
        LeanTween.textAlpha(textoDialogo.rectTransform, 0, 0);
        LeanTween.textAlpha(textoDialogo.rectTransform, 1, 0.5f);
    }
}
