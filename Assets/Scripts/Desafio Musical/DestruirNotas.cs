using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestruirNotas : MonoBehaviour
{
    [SerializeField] Slider barra;
    GameObject[] notasRed, notasGreen, notasPink, notasBlue;
    public static float pontos, notasDestruidas;
    Scene desafioAtual;
    public static int combo;
    [SerializeField] Image mensagemCombo;
    [SerializeField] Sprite[] mensagens;

    AudioSource musica;
    [SerializeField] GameObject painelVitoria, brilhoRed, brilhoGreen, brilhoPink, brilhoBlue;

    public static bool venceuSamba, venceuJongo, venceuSussa;

    bool combou;
    private void Awake()
    {
        musica = GetComponent<AudioSource>();
        painelVitoria.SetActive(false);
        combo = 0;
        pontos = 50;
        notasDestruidas = 0;
        desafioAtual = SceneManager.GetActiveScene();
        venceuSamba = false;
        venceuJongo = false;
        venceuSussa = false;
        SumaBrilho();
    }
    void Update()
    {
        VerificarCombo();
        notasRed = GameObject.FindGameObjectsWithTag("Red");
        notasGreen = GameObject.FindGameObjectsWithTag("Green");
        notasPink = GameObject.FindGameObjectsWithTag("Pink");
        notasBlue = GameObject.FindGameObjectsWithTag("Blue");
        
        barra.value = pontos;
        
        if (pontos > 100)
        {
            pontos = 100;
        }
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
                            brilhoRed.SetActive(true);
                            Destroy(vermelho);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoGreen.SetActive(true);
                            Destroy(verde);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoPink.SetActive(true);
                            Destroy(rosa);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoBlue.SetActive(true);
                            Destroy(azul);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoRed.SetActive(true);
                            Destroy(vermelho);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoGreen.SetActive(true);
                            Destroy(verde);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoPink.SetActive(true);
                            Destroy(rosa);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                            brilhoBlue.SetActive(true);
                            Destroy(azul);
                            Invoke(nameof(SumaBrilho), 0.2f);
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
                                brilhoRed.SetActive(true);
                                Destroy(vermelho);
                                Invoke(nameof(SumaBrilho), 0.2f);
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
                                brilhoGreen.SetActive(true);
                                Destroy(verde);
                                Invoke(nameof(SumaBrilho), 0.2f);
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
                                brilhoPink.SetActive(true);
                                Destroy(rosa);
                                Invoke(nameof(SumaBrilho), 0.2f);
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
                                brilhoBlue.SetActive(true);
                                Destroy(azul);
                                Invoke(nameof(SumaBrilho), 0.2f);
                            }
                        }
                    }
                }
            }

            
        }

        if (!musica.isPlaying)
        {
            ContabilizarPontos();
        }
    }

    void SumaBrilho()
    {
        brilhoRed.SetActive(false);
        brilhoGreen.SetActive(false);
        brilhoPink.SetActive(false);
        brilhoBlue.SetActive(false);
    }
    void ContabilizarPontos()
    {
        painelVitoria.SetActive(true);
        Dialogos.dialogoAtivo = true;
        if (desafioAtual.name == "SambaDeRoda")
        {
            venceuSamba = true;
        }
        if (desafioAtual.name == "Jongo")
        {
            if (barra.value > 50)
            {
                venceuJongo = true;
            }
            else if (barra.value <= 50)
            {
                venceuJongo = false;
            }
        }

        if (desafioAtual.name == "Sussa")
        {
            if (barra.value > 50)
            {
                venceuSussa = true;
            }
            else if (barra.value <= 50)
            {
                venceuSussa = false;
            }
        }
    }

    [ContextMenu("PularCena")]
    public void MudarCena()
    {
        if (desafioAtual.name == "SambaDeRoda")
        {
            SceneManager.LoadScene("Mapa");
            ControladorCenas.quilombo1 = true;
        }
        if (desafioAtual.name == "Jongo")
        {
            if (barra.value > 50)
            {
                SceneManager.LoadScene("Mapa");
                ControladorCenas.quilombo2 = true;
            }
            else if (barra.value <= 50)
            {
                SceneManager.LoadScene("Quilombo1");
            }
        }

        if (desafioAtual.name == "Sussa")
        {
            if (barra.value > 50)
            {
                SceneManager.LoadScene("Quilombo3");
                ControladorCenas.quilombo3 = true;
            }
            else if (barra.value <= 50)
            {
                SceneManager.LoadScene("Quilombo2");
            }
        }
    }
    void VerificarCombo()
    {
        if (!combou)
        {
            float randomPos = Random.Range(-4.44f, 4.44f);

            mensagemCombo.transform.position = new Vector2(randomPos, mensagemCombo.transform.position.y);
        }
        switch (combo)
        {
            case 0:
                combou = false;
                mensagemCombo.enabled = false;
                break;

            case 3:
                combou = true;
                mensagemCombo.enabled = true;
                mensagemCombo.sprite = mensagens[0];
                StartCoroutine(AumentaEDiminui());
                break;

            case 6:
                mensagemCombo.sprite = mensagens[1];
                StartCoroutine(AumentaEDiminui());
                break;

            case 9:
                mensagemCombo.sprite = mensagens[2];
                StartCoroutine(AumentaEDiminui());
                break;

            case 12:
                mensagemCombo.sprite = mensagens[3];
                StartCoroutine(AumentaEDiminui());
                break;
        }
    }
    IEnumerator AumentaEDiminui()
    {
        float tempoDecorrido = 0f;
        float duracaoAnimacao = 0.3f;

        Vector3 escalaInicial = mensagemCombo.rectTransform.localScale;
        Vector3 escalaFinal = new Vector3(1.5f, 1.5f, 1f);

        while (tempoDecorrido < duracaoAnimacao)
        {
            mensagemCombo.rectTransform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tempoDecorrido / duracaoAnimacao);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }

        mensagemCombo.rectTransform.localScale = escalaFinal;

        yield return new WaitForSeconds(0.2f);

        tempoDecorrido = 0f;
        escalaInicial = mensagemCombo.rectTransform.localScale;
        escalaFinal = new Vector3(1f, 1f, 1f);

        while (tempoDecorrido < duracaoAnimacao)
        {
            mensagemCombo.rectTransform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tempoDecorrido / duracaoAnimacao);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }
        mensagemCombo.rectTransform.localScale = escalaFinal;
    }
}