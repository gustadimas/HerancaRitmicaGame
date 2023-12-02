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
    [SerializeField] GameObject painelVitoria, brilhoRed, brilhoGreen, brilhoPink, brilhoBlue, maosRed, maosGreen, maosPink, maosBlue;

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

        // Iterar por todos os toques
        for (int i = 0; i < Input.touchCount; i++)
        {
            Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            RaycastHit hit;

            // Verificar colisões apenas se o toque atingiu um objeto
            if (Physics.Raycast(raio, out hit))
            {
                if (hit.collider.CompareTag("AreaRed"))
                {
                    DestruirNotasNaArea(notasRed, maosRed, brilhoRed, hit);
                }
                else if (hit.collider.CompareTag("AreaGreen"))
                {
                    DestruirNotasNaArea(notasGreen, maosGreen, brilhoGreen, hit);
                }
                else if (hit.collider.CompareTag("AreaPink"))
                {
                    DestruirNotasNaArea(notasPink, maosPink, brilhoPink, hit);
                }
                else if (hit.collider.CompareTag("AreaBlue"))
                {
                    DestruirNotasNaArea(notasBlue, maosBlue, brilhoBlue, hit);
                }
            }
        }

        if (!musica.isPlaying)
        {
            ContabilizarPontos();
        }
    }

    // Método para destruir notas na área
    void DestruirNotasNaArea(GameObject[] notas, GameObject maos, GameObject brilho, RaycastHit hit)
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
                brilho.SetActive(true);
                Destroy(nota);
                Invoke(nameof(SumaBrilho), 0.2f);
            }
        }
    }

    void SumaBrilho()
    {
        brilhoRed.SetActive(false);
        brilhoGreen.SetActive(false);
        brilhoPink.SetActive(false);
        brilhoBlue.SetActive(false);
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