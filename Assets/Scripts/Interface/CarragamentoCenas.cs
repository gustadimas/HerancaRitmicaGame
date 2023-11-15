using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarragamentoCenas : MonoBehaviour
{
    [SerializeField] GameObject telaDeCarregamento;
    [SerializeField] Slider barraDeCarregamento;

    public void CarregarCena(string cena)
    {
        telaDeCarregamento.SetActive(true);
        StartCoroutine(CarregamentoFalsoAsync(cena));
    }

    IEnumerator CarregamentoFalsoAsync(string cena)
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(cena);
        operacao.allowSceneActivation = false;

        float tempoInicial = Time.time;
        float tempoCarregamento = 5f; // Tempo de simulação de carregamento em segundos

        while (Time.time - tempoInicial < tempoCarregamento)
        {
            float progresso = Mathf.Clamp01((Time.time - tempoInicial) / tempoCarregamento);
            barraDeCarregamento.value = progresso;

            yield return null;
        }

        operacao.allowSceneActivation = true;

        // Aguarde um pouco para exibir o carregamento completo
        yield return new WaitForSeconds(0.5f);

        telaDeCarregamento.SetActive(false);
    }
}
