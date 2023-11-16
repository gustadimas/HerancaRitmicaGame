using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoNPC : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] float raioDeVagar = 15f;
    [SerializeField] float tempoEntreDestinos = 8f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Vagar());
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projetil")
        {
            Object.Destroy(other.gameObject);
            base.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projetil")
        {
            Object.Destroy(other.gameObject);
            base.gameObject.SetActive(false);
        }
    }
}