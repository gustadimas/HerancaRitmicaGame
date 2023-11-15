using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Dialogos : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] string[] falas;
    [SerializeField] float delayEntreLetras;
    [SerializeField] GameObject CaixaDeDialogo;

    NavMeshAgent npcNavMeshAgent;
    bool dialogoAtivo = false;
    int index = 0;

    void Start()
    {
        npcNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
        CaixaDeDialogo.SetActive(false);
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
            CaixaDeDialogo.SetActive(true);
            index = 0;
            IniciarDialogo();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcNavMeshAgent.isStopped = false;
            CaixaDeDialogo.SetActive(false);
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
        StartCoroutine(TipoDeFala(falas[index]));
    }

    void FinalizarDialogo()
    {
        npcNavMeshAgent.isStopped = false;
        CaixaDeDialogo.SetActive(false);
        dialogoAtivo = false;
        index = 0;
        gameObject.SetActive(false);
    }
}
