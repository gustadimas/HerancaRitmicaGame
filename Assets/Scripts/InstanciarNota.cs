using UnityEngine;
using System.Collections;

public class InstanciarNota : MonoBehaviour
{
    [SerializeField] Vector2[] posTempoNota;
    [SerializeField] GameObject notinhas;
    [SerializeField] Transform[] posicoesPossiveis;
    [SerializeField] Color[] cores;
    [SerializeField] string[] tags;

    void Start()
    {
        StartCoroutine(NotaSpawn());
    }

    IEnumerator NotaSpawn()
    {
        for(int i = 0; i < posTempoNota.Length; i++)
        {
            yield return new WaitForSeconds(posTempoNota[i].y);
            GameObject novaNota = Instantiate(notinhas, posicoesPossiveis[(int)(posTempoNota[i].x)].position, Quaternion.identity);
            novaNota.transform.GetComponentInChildren<MeshRenderer>().material.color = cores[(int)posTempoNota[i].x];
            novaNota.tag = tags[(int)posTempoNota[i].x];
        }        
    }

    [ContextMenu("SetarNotas")]
    [ExecuteInEditMode]

    void SetarTempinhos()
    {
        for (int i = 0; i <= posTempoNota.Length; i++)
        {
            posTempoNota[i].y = Random.Range(0f, 1f);
        }
    }
        
}