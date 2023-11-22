using UnityEngine;
using UnityEngine.SceneManagement;
public class MovimentoNota : MonoBehaviour
{
    float velocidade;
    Scene desafioAtual;

    private void Start()
    {
        desafioAtual = SceneManager.GetActiveScene();
        if (desafioAtual.name == "SambaDeRoda")
        {
            velocidade = 2.5f;
        }
        if (desafioAtual.name == "Jongo")
        {
            velocidade = 3;
        }
        if (desafioAtual.name == "Sussa")
        {
            velocidade = 5;
        }
    }
    void Update()
    {
        transform.position += velocidade * Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag ("Limite"))
        {
            Destroy(gameObject);
        }
    }
}