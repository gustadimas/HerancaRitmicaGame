using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimiteNotas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        DestruirNotas.pontos -= 0.5f;
        DestruirNotas.notasDestruidas++;
    }
}
