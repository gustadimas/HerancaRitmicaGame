using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoNPC : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anima;

    [SerializeField] float raioDeVagar = 15f;
    [SerializeField] float tempoEntreDestinos = 8f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima = transform.GetChild(0).GetComponent<Animator>();
        Debug.Log("Animator: " + anima.gameObject.name);
        StartCoroutine(Vagar());
    }

    private void Update()
    {
        AtualizarEstadoAnimacao();
        Debug.Log("Animator: " + anima.gameObject.name);
    }

    private IEnumerator Vagar()
    {
        while (true)
        {
            Vector3 destination = ObterDestinoAleatorio();
            agent.SetDestination(destination);
            tempoEntreDestinos = Random.Range(3f, 8f);
            yield return new WaitForSeconds(tempoEntreDestinos);
        }
    }

    private Vector3 ObterDestinoAleatorio()
    {
        NavMeshHit _hit;
        NavMesh.SamplePosition(Random.insideUnitSphere * raioDeVagar + base.transform.position, out _hit, raioDeVagar, -1);
        return _hit.position;
    }

    void AtualizarEstadoAnimacao()
    {
        Vector3 movimento = agent.velocity;

        if (movimento.magnitude > 0.1f)
        {
            anima.SetInteger("estado", 1);
            Debug.Log("Andando");
        }

        else
        {
            anima.SetInteger("estado", 0);
            Debug.Log("Parado");
        }
    }
}