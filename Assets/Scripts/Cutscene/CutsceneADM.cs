
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
        Application.targetFrameRate = 60;

        Invoke("TrocarImagens", 12f);
    }

    void Update()
    {
        imagens[imagemAtual].color += new Color (0,0,0,0.01f);
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
            SceneManager.LoadScene("Quingoma");
        }

        Invoke("TrocarImagens", 12f);
    }
}
