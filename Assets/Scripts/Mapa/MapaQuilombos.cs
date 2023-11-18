using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MapaQuilombos : MonoBehaviour
{
    [SerializeField] Transform containerNiveis;
    List<GameObject> elementos = new List<GameObject>();
    GameObject ElementoAtual => elementos[indiceAtual];

    [SerializeField] string nomeObjetoLabel1 = "Quilombo1Panel";
    [SerializeField] string nomeObjetoLabel2 = "Quilombo2Panel";

    Image Quilombo1Panel, Quilombo2Panel;
    TextMeshProUGUI textoPanel1, textoPanel2;

    int indiceAtual = 0;

    public static MapaQuilombos Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia == null)
            Instancia = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < containerNiveis.childCount; i++)
            elementos.Add(containerNiveis.GetChild(i).gameObject);

        for (int i = 1; i < elementos.Count; i++)
            elementos[i].SetActive(false);

        SceneManager.sceneLoaded += AoCarregarCena;
        DontDestroyOnLoad(gameObject);
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        Quilombo1Panel = GameObject.Find(nomeObjetoLabel1)?.GetComponent<Image>();
        Quilombo2Panel = GameObject.Find(nomeObjetoLabel2)?.GetComponent<Image>();
        textoPanel1 = GameObject.Find(nomeObjetoLabel1)?.GetComponentInChildren<TextMeshProUGUI>();
        textoPanel2 = GameObject.Find(nomeObjetoLabel2)?.GetComponentInChildren<TextMeshProUGUI>();

        if (cena.name == "Mapa" && ControladorCenas.quingoma)
        {
            ControladorCenas.quilombo1 = false;
            ControladorCenas.quingoma = false;
            ControladorCenas.quilombo2 = false;
            ControladorCenas.quilombo3 = false;
            Invoke("CenaQuilombo1", 4f);
            indiceAtual = Mathf.Clamp(indiceAtual, 0, elementos.Count - 1);
            ElementoAtual.SetActive(true);
        }

        if (cena.name == "Mapa" && ControladorCenas.quilombo1)
        {
            ControladorCenas.quilombo1 = false;
            ControladorCenas.quingoma = false;
            ControladorCenas.quilombo2 = false;
            ControladorCenas.quilombo3 = false;
            Invoke("Quilombo1Concluido", 2f);
            Invoke("NivelQuilombo2", 4f);
            Invoke("CenaQuilombo2", 8f);
            indiceAtual = Mathf.Clamp(indiceAtual, 0, elementos.Count - 1);
            ElementoAtual.SetActive(true);
        }

        if (cena.name == "Mapa" && ControladorCenas.quilombo2)
        {
            ControladorCenas.quilombo1 = false;
            ControladorCenas.quingoma = false;
            ControladorCenas.quilombo2 = false;
            ControladorCenas.quilombo3 = false;
            Invoke("Quilombo2Concluido", 2f);
            Invoke("NivelQuilombo3", 4f);
            Invoke("CenaQuilombo3", 8f);
            indiceAtual = Mathf.Clamp(indiceAtual, 0, elementos.Count - 1);
            ElementoAtual.SetActive(true);
        }
    }

    public void NivelQuilombo2()
    {
        AtivarNivel(indiceAtual + 1);
    }

    public void NivelQuilombo3()
    {
        AtivarNivel(indiceAtual + 1);
    }

    public void SelecionarNivelAnterior()
    {
        AtivarNivel(indiceAtual - 1);
    }

    private void AtivarNivel(int index)
    {
        if (index >= 0 && index < elementos.Count)
        {
            elementos[indiceAtual].SetActive(false);
            indiceAtual = index;
            elementos[indiceAtual].SetActive(true);
        }
    }

    void CenaQuilombo1()
    {
        SceneManager.LoadScene("Quilombo1");
    }

    void CenaQuilombo2()
    {
        SceneManager.LoadScene("Quilombo2");
    }

    void CenaQuilombo3()
    {
        SceneManager.LoadScene("Quilombo3");
    }

    void Quilombo1Concluido()
    {
        if (Quilombo1Panel != null)
            Quilombo1Panel.color = Color.green;

        if (textoPanel1 != null)
            textoPanel1.color = Color.black;
    }

    void Quilombo2Concluido()
    {
        if (Quilombo2Panel != null)
            Quilombo2Panel.color = Color.green;

        if (textoPanel2 != null)
            textoPanel2.color = Color.black;
    }
}