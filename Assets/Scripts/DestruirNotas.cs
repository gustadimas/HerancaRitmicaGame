using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestruirNotas : MonoBehaviour
{
    [SerializeField] Collider areaRed, areaGreen, areaPink, areaBlue;
    [SerializeField] Slider barra;
    public static float pontos, notasDestruidas;
    Scene desafioAtual;
    public static bool venceuJongo, venceuSussa;

    private void Start()
    {
        pontos = 50;
        notasDestruidas = 0;
        desafioAtual = SceneManager.GetActiveScene();
        if (desafioAtual.name == "Jongo")
        {
            venceuJongo = false;
        }
        if (desafioAtual.name == "Sussa")
        {
            venceuSussa = false;
        }
    }
    void Update()
    {
        barra.value = pontos;
        if (Input.touchCount > 0)
        {
            Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(raio, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Red"))
                {
                    if (hit.collider.bounds.Intersects(areaRed.bounds))
                    {
                        pontos++;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.75f;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.CompareTag("Green"))
                {
                    if (hit.collider.bounds.Intersects(areaGreen.bounds))
                    {
                        pontos++;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.75f;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.CompareTag("Pink"))
                {
                    if (hit.collider.bounds.Intersects(areaPink.bounds))
                    {
                        pontos++;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.75f;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.CompareTag("Blue"))
                {
                    if (hit.collider.bounds.Intersects(areaBlue.bounds))
                    {
                        pontos++;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.75f;
                        notasDestruidas++;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
        if (desafioAtual.name == "Samba de Roda")
        {
            if (notasDestruidas >= 100)
            {
                ContabilizarPontos();
            }
        }
        if (desafioAtual.name == "Jongo")
        {
            if (notasDestruidas >= 330)
            {
                ContabilizarPontos();
            }
        }
        if (desafioAtual.name == "Sussa")
        {
            if (notasDestruidas >= 100)
            {
                ContabilizarPontos();
            }
        }
    }

    void ContabilizarPontos()
    {
        if (desafioAtual.name == "Samba de Roda")
        {
            SceneManager.LoadScene("Game");
        }
        if (desafioAtual.name == "Jongo")
        {
            if (barra.value > 50)
            {
                venceuJongo = true;
                SceneManager.LoadScene("Game");
            }
            else if (barra.value <= 50)
            {
                SceneManager.LoadScene("Game");
            }
        }

        if (desafioAtual.name == "Sussa")
        {
            if (barra.value > 50)
            {
                venceuSussa = true;
                SceneManager.LoadScene("Game");
            }
            else if (barra.value <= 50)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
