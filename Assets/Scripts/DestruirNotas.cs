using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestruirNotas : MonoBehaviour
{
    [SerializeField] Collider2D areaRed, areaGreen, areaPink, areaBlue;
    [SerializeField] Slider barra;
    GameObject[] notasRed, notasGreen, notasPink, notasBlue;
    public static float pontos, notasDestruidas;
    Scene desafioAtual;
    public static bool venceuJongo, venceuSussa;
    public static int combo;
    [SerializeField] Image mensagemCombo;
    [SerializeField] Sprite[] mensagens;

    private void Start()
    {
        combo = 0;
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
        VerificarCombo();
        notasRed = GameObject.FindGameObjectsWithTag("Red");
        notasGreen = GameObject.FindGameObjectsWithTag("Green");
        notasPink = GameObject.FindGameObjectsWithTag("Pink");
        notasBlue = GameObject.FindGameObjectsWithTag("Blue");
        barra.value = pontos;
        if (Input.touchCount == 1)
        {
            Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(raio, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("AreaRed"))
                {
                    foreach (var vermelho in notasRed)
                    {
                        Collider redCol = vermelho.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(redCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            combo++;
                            Destroy(vermelho);
                        }
                    }

                }

                if (hit.collider.CompareTag("AreaGreen"))
                {
                    foreach (var verde in notasGreen)
                    {
                        Collider greenCol = verde.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(greenCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            combo++;
                            Destroy(verde);
                        }
                    }
                }

                if (hit.collider.CompareTag("AreaPink"))
                {
                    foreach (var rosa in notasPink)
                    {
                        Collider pinkCol = rosa.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(pinkCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            combo++;
                            Destroy(rosa);
                        }
                    }
                }

                if (hit.collider.CompareTag("AreaBlue"))
                {
                    foreach (var azul in notasBlue)
                    {
                        Collider blueCol = azul.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(blueCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            combo++;
                            Destroy(azul);
                        }
                    }
                }
            }
        }
        //SEGUNDO TOQUE
        if (Input.touchCount == 2)
        {
            Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray raio2 = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
            if (Physics.Raycast(raio, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("AreaRed"))
                {
                    foreach (var vermelho in notasRed)
                    {
                        Collider redCol = vermelho.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(redCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            Destroy(vermelho);
                        }
                    }

                }

                if (hit.collider.CompareTag("AreaGreen"))
                {
                    foreach (var verde in notasGreen)
                    {
                        Collider greenCol = verde.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(greenCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            Destroy(verde);
                        }
                    }
                }

                if (hit.collider.CompareTag("AreaPink"))
                {
                    foreach (var rosa in notasPink)
                    {
                        Collider pinkCol = rosa.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(pinkCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            Destroy(rosa);
                        }
                    }
                }

                if (hit.collider.CompareTag("AreaBlue"))
                {
                    foreach (var azul in notasBlue)
                    {
                        Collider blueCol = azul.GetComponent<Collider>();
                        if (hit.collider.bounds.Intersects(blueCol.bounds))
                        {
                            pontos++;
                            notasDestruidas++;
                            Destroy(azul);
                        }
                    }
                }

                // Parte do 2º toque

                if (Physics.Raycast(raio2, out RaycastHit hit2))
                {
                    if (hit2.collider.CompareTag("AreaRed"))
                    {
                        foreach (var vermelho in notasRed)
                        {
                            Collider redCol = vermelho.GetComponent<Collider>();
                            if (hit2.collider.bounds.Intersects(redCol.bounds))
                            {
                                pontos++;
                                notasDestruidas++;
                                Destroy(vermelho);
                            }
                        }

                    }

                    if (hit2.collider.CompareTag("AreaGreen"))
                    {
                        foreach (var verde in notasGreen)
                        {
                            Collider greenCol = verde.GetComponent<Collider>();
                            if (hit2.collider.bounds.Intersects(greenCol.bounds))
                            {
                                pontos++;
                                notasDestruidas++;
                                Destroy(verde);
                            }
                        }
                    }

                    if (hit2.collider.CompareTag("AreaPink"))
                    {
                        foreach (var rosa in notasPink)
                        {
                            Collider pinkCol = rosa.GetComponent<Collider>();
                            if (hit2.collider.bounds.Intersects(pinkCol.bounds))
                            {
                                pontos++;
                                notasDestruidas++;
                                Destroy(rosa);
                            }
                        }
                    }

                    if (hit2.collider.CompareTag("AreaBlue"))
                    {
                        foreach (var azul in notasBlue)
                        {
                            Collider blueCol = azul.GetComponent<Collider>();
                            if (hit2.collider.bounds.Intersects(blueCol.bounds))
                            {
                                pontos++;
                                notasDestruidas++;
                                Destroy(azul);
                            }
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

    void VerificarCombo()
    {
        switch (combo)
        {
            case 0:
                mensagemCombo.enabled = false;
                break;

            case 3:
                mensagemCombo.enabled = true;
                mensagemCombo.sprite = mensagens[0];
                break;

            case 6:
                mensagemCombo.sprite = mensagens[1];
                break;

            case 9:
                mensagemCombo.sprite = mensagens[2];
                break;

            case 12:
                mensagemCombo.sprite = mensagens[3];
                break;
        }
    }
}