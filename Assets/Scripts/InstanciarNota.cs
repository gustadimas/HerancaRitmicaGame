using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstanciarNota : MonoBehaviour
{
    [SerializeField] Vector2[] posTempoNota;
    [SerializeField] GameObject notinhas;
    [SerializeField] Transform[] posicoesPossiveis;
    [SerializeField] Color[] cores;
    [SerializeField] string[] tags;
    Scene cena;
    AudioSource audioSource;
    [SerializeField] AudioClip[] musicas;
    public static bool comecou;
    Vector2[] posTempoNotaOnline;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cena = SceneManager.GetActiveScene();
        if (cena.name == "Multiplayer")
        {
            int desafioAleatorio = Random.Range(0,2);

            switch (desafioAleatorio)
            {
                case 0:
                    audioSource.clip = musicas[0];
                    for (int i = 0; i < 330; i++)
                    {
                        posTempoNotaOnline[i].y = Random.Range(0f, 1f);
                        posTempoNotaOnline[i].x = Random.Range(0, 4);
                    }
                    break;

                case 1:
                    audioSource.clip = musicas[1];
                    for (int i = 0; i < 100; i++)
                    {
                        posTempoNotaOnline[i].y = Random.Range(0f, 1f);
                        posTempoNotaOnline[i].x = Random.Range(0, 4);
                    }
                    break;

                case 2:
                    audioSource.clip = musicas[2];
                    for (int i = 0; i < 100; i++)
                    {
                        posTempoNotaOnline[i].y = Random.Range(0f, 1f);
                        posTempoNotaOnline[i].x = Random.Range(0, 4);
                    }
                    break;

            }
            StartCoroutine(NotaSpawnOnline());
        }
            

        else
            StartCoroutine(NotaSpawn());
    }
    IEnumerator NotaSpawn()
    {
        for(int i = 0; i < posTempoNota.Length; i++)
        {
            yield return new WaitForSeconds(posTempoNota[i].y);
            GameObject novaNota = Instantiate(notinhas, posicoesPossiveis[(int)(posTempoNota[i].x)].position, Quaternion.identity);
            novaNota.transform.GetComponentInChildren<SpriteRenderer>().color = cores[(int)posTempoNota[i].x];
            novaNota.tag = tags[(int)posTempoNota[i].x];
        }        
    }

    IEnumerator NotaSpawnOnline()
    {
        if (comecou)
        {
            for (int i = 0; i < posTempoNotaOnline.Length; i++)
            {
                yield return new WaitForSeconds(posTempoNotaOnline[i].y);
                GameObject novaNota = Instantiate(notinhas, posicoesPossiveis[(int)(posTempoNotaOnline[i].x)].position, Quaternion.identity);
                novaNota.transform.GetComponentInChildren<SpriteRenderer>().color = cores[(int)posTempoNotaOnline[i].x];
                novaNota.tag = tags[(int)posTempoNotaOnline[i].x];
            }
        }
    }

    [ContextMenu("SetarNotas")]
    [ExecuteInEditMode]

    void SetarTempinhos()
    {
        for (int i = 0; i <= posTempoNota.Length; i++)
        {
            posTempoNota[i].y = Random.Range(0f, 1f);
            posTempoNota[i].x = Random.Range(0, 4);
        }
    }
        
}