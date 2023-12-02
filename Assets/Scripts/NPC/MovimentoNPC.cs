using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoNPC : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anima;

    [SerializeField] float raioDeVagar = 15f;
    [SerializeField] float tempoEntreDestinos = 10f;
    [SerializeField] float tempoDeEspera = 1f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima = transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine(Vagar());
    }

    private void Update()
    {
        AtualizarEstadoAnimacao();

        if (AtivarDialogo.dialogoCollider)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }

    private IEnumerator Vagar()
    {
        while (true)
        {
            Vector3 destination = ObterDestinoAleatorio();
            agent.SetDestination(destination);

            yield return new WaitUntil(() => agent.remainingDistance < 0.1f);

            yield return new WaitForSeconds(tempoDeEspera);

            tempoEntreDestinos = Random.Range(3f, 10f);
            yield return new WaitForSeconds(tempoEntreDestinos);
        }
    }

    private Vector3 ObterDestinoAleatorio()
    {
        NavMesh.SamplePosition(Random.insideUnitSphere * raioDeVagar + base.transform.position, out NavMeshHit hit, raioDeVagar, -1);
        return hit.position;
    }

    void AtualizarEstadoAnimacao()
    {
        Vector3 movimento = agent.velocity;

        if (ControladorDialogo.dialogoAtivo)
        {
            anima.SetInteger("estado", 2);
        }
        else
        {
            if (movimento.magnitude > 0.1f)
            {
                anima.SetInteger("estado", 1);
            }
            else
            {
                anima.SetInteger("estado", 0);
            }
        }
    }
}
