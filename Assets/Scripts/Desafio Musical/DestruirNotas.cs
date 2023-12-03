using System.Collections;
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
    [SerializeField] GameObject painelVitoria, particulasRed, particulasGreen, particulasPink, particulasBlue, maosRed, maosGreen, maosPink, maosBlue;

    public static bool venceuSamba, venceuJongo, venceuSussa;

    bool combou;
    Vector2 touchInicioPosicao;

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
        SumaParticulas();
        SumaMaos();
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

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Ray raio = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(raio, out hit))
                    {
                        if (hit.collider.CompareTag("AreaRed") ||
                            hit.collider.CompareTag("AreaGreen") ||
                            hit.collider.CompareTag("AreaPink") ||
                            hit.collider.CompareTag("AreaBlue"))
                        {
                            touchInicioPosicao = touch.position;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (Physics.Raycast(raio, out hit) &&
                        (hit.collider.CompareTag("AreaRed") ||
                         hit.collider.CompareTag("AreaGreen") ||
                         hit.collider.CompareTag("AreaPink") ||
                         hit.collider.CompareTag("AreaBlue")))
                    {
                        float distancia = Vector2.Distance(touchInicioPosicao, touch.position);
                        if (distancia < 10f)
                        {
                            if (hit.collider.CompareTag("AreaRed"))
                                DestruirNotasNaArea(notasRed, maosRed, particulasRed, hit);
                            else if (hit.collider.CompareTag("AreaGreen"))
                                DestruirNotasNaArea(notasGreen, maosGreen, particulasGreen, hit);
                            else if (hit.collider.CompareTag("AreaPink"))
                                DestruirNotasNaArea(notasPink, maosPink, particulasPink, hit);
                            else if (hit.collider.CompareTag("AreaBlue"))
                                DestruirNotasNaArea(notasBlue, maosBlue, particulasBlue, hit);
                        }
                    }
                    break;
            }
        }

        if (!musica.isPlaying)
        {
            ContabilizarPontos();
        }
    }

    // Método para destruir notas na área
    void DestruirNotasNaArea(GameObject[] notas, GameObject maos, GameObject particulas, RaycastHit hit)
    {
        maos.SetActive(true);
        Invoke(nameof(SumaMaos), 1.5f);

        foreach (var nota in notas)
        {
            Collider notaCol = nota.GetComponent<Collider>();

            if (notaCol.bounds.Intersects(hit.collider.bounds))
            {
                pontos++;
                notasDestruidas++;
                combo++;
                EmitirParticulas(particulas);
                Destroy(nota);
            }
        }
    }

    void EmitirParticulas(GameObject particulas)
    {
        particulas.SetActive(true);
        particulas.GetComponent<ParticleSystem>().Play();
        // Se as partículas tiverem um componente de áudio, você pode ativar o áudio aqui também
    }

    void SumaParticulas()
    {
        particulasRed.SetActive(false);
        particulasGreen.SetActive(false);
        particulasPink.SetActive(false);
        particulasBlue.SetActive(false);
    }

    void SumaMaos()
    {
        maosRed.SetActive(false);
        maosGreen.SetActive(false);
        maosPink.SetActive(false);
        maosBlue.SetActive(false);
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