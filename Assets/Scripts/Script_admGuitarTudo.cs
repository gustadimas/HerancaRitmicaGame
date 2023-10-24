using UnityEngine;
using System.Collections;

public class Script_admGuitarTudo : MonoBehaviour
{
    [SerializeField] Vector2[] posTempoNota;
    [SerializeField] GameObject notinhas;
    [SerializeField] Transform[] posicoesPossiveis;
    [SerializeField] Color[] cores;

    void Start()
    {
        StartCoroutine(NotaSpawn());
    }

    IEnumerator NotaSpawn()
    {
        for(int i = 0; i < posTempoNota.Length; i++)
        {
            yield return new WaitForSeconds(posTempoNota[i].y);
            GameObject _obj_nota = Instantiate(notinhas, posicoesPossiveis[(int)(posTempoNota[i].x)].position, Quaternion.identity);
            _obj_nota.transform.GetComponentInChildren<MeshRenderer>().material.color = cores[(int)posTempoNota[i].x];
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