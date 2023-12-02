using UnityEngine;

public class ControleEventos : MonoBehaviour
{
    [SerializeField] AudioClip[] andando;

    void AndandoChao()
    {
        transform.parent.GetComponent<AudioSource>().PlayOneShot(andando[Random.Range(0, andando.Length)]);
    }
}
