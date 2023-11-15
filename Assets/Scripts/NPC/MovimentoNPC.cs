using UnityEngine;
using UnityEngine.AI;

public class MovimentoNPC : MonoBehaviour
{
    public NavMeshAgent agente;
    public float alcance;

    public Transform pontoCentral;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agente.remainingDistance <= agente.stoppingDistance)
        {
            Vector3 ponto;

            if (PontoAleatorio(pontoCentral.position, alcance, out ponto))
            {
                Debug.DrawRay(ponto, Vector3.up, Color.blue, 1.0f);

                agente.SetDestination(ponto);
            }
        }
    }

    bool PontoAleatorio(Vector3 centro, float alcance, out Vector3 resultado)
    {
        Vector3 pontoAleatorio = centro + Random.insideUnitSphere * alcance;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(pontoAleatorio, out hit, 1.0f, NavMesh.AllAreas))
        {
            resultado = hit.position;
            return true;
        }

        resultado = Vector3.zero;
        return false;
    }
}