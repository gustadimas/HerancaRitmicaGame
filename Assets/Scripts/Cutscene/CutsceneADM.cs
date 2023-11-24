
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneADM : MonoBehaviour
{
    [SerializeField]
    private Image[] imagens;

    private int imagemAtual = 0;

    void Start()
    {
        //Application.targetFrameRate = 60;

        Invoke(nameof(TrocarImagens), 12f);
    }

    void Update()
    {
        imagens[imagemAtual].color += new Color (0,0,0,0.4f) * Time.deltaTime;
    }

    private void TrocarImagens()
    {
        if (imagemAtual < imagens.Length - 1)
        {
            imagens[imagemAtual].gameObject.SetActive(false);
            
            imagens[imagemAtual + 1].gameObject.SetActive(true);

            imagemAtual++;
        }
        else
        {
            SceneManager.LoadScene("Mapa");
            ControladorCenas.quingoma = true;
        }

        Invoke(nameof(TrocarImagens), 10f);
    }

    public void PularCutscene()
    {
        CancelInvoke();
        TrocarImagens();
    }
}
