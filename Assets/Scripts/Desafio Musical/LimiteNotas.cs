using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LimiteNotas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Multiplayer")
        {
            Destroy(other.gameObject);
            Jogador1Controle.notasDestruidas1++;
            Jogador2Controle.notasDestruidas2++;
            DestruirNotas.combo = 0;
        }
        else
        {
            Destroy(other.gameObject);
            DestruirNotas.pontos -= 1f;
            DestruirNotas.notasDestruidas++;
            DestruirNotas.combo = 0;
        }
    }
}
