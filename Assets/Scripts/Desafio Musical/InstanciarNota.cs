using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstanciarNota : MonoBehaviour
{
    [SerializeField] Vector2[] posTempoNota;
    [SerializeField] GameObject notinhas;
    [SerializeField] Transform[] posicoesPossiveis;
    [SerializeField] Color[] cores;
    [SerializeField] string[] tags;
    Scene cena;
    public static AudioSource audioSource;
    [SerializeField] AudioClip[] musicas;
    public static bool comecou, musicaTocando;
    Vector2[] posTempoNotaOnline;
    
    void Start()
    {
        musicaTocando = false;
        audioSource = GetComponent<AudioSource>();
        cena = SceneManager.GetActiveScene();
        if (cena.name == "Multijogador")
        {
            StartCoroutine(NotaSpawnOnline());
        }

        else
            StartCoroutine(NotaSpawn());
    }

    private void SelecionarMusica()
    {
        audioSource.clip = musicas[0];
        IniciarVetor(68);

        audioSource.Play();
        musicaTocando = true;
    }

    void IniciarVetor(int tamanho)
    {
        posTempoNotaOnline = new Vector2[tamanho];

        for (int i = 0; i < tamanho; i++)
        {
            posTempoNotaOnline[i].y = Random.Range(0.5f, 1f);
            posTempoNotaOnline[i].x = Random.Range(0, 4);
        }
    }
    IEnumerator NotaSpawn()
    {
        for (int i = 0; i < posTempoNota.Length; i++)
        {
            yield return new WaitForSeconds(posTempoNota[i].y);
            GameObject novaNota = Instantiate(notinhas, posicoesPossiveis[(int)(posTempoNota[i].x)].position, Quaternion.identity);
            novaNota.transform.GetComponentInChildren<SpriteRenderer>().color = cores[(int)posTempoNota[i].x];
            novaNota.tag = tags[(int)posTempoNota[i].x];
        }
    }

    IEnumerator NotaSpawnOnline()
    {
        yield return new WaitUntil(() => comecou);

        SelecionarMusica();

        for (int i = 0; i < posTempoNotaOnline.Length; i++)
        {
            yield return new WaitForSeconds(posTempoNotaOnline[i].y);
            GameObject novaNota = Instantiate(notinhas, posicoesPossiveis[(int)(posTempoNotaOnline[i].x)].position, Quaternion.identity);
            novaNota.transform.GetComponentInChildren<SpriteRenderer>().color = cores[(int)posTempoNotaOnline[i].x];
            novaNota.tag = tags[(int)posTempoNotaOnline[i].x];
        }
    }

    [ContextMenu("SetarNotas")]
    [ExecuteInEditMode]

    void SetarTempinhos()
    {
        for (int i = 0; i <= posTempoNota.Length; i++)
        {
            posTempoNota[i].y = Random.Range(0.5f, 1f);
            posTempoNota[i].x = Random.Range(0, 4);
        }
    }
}