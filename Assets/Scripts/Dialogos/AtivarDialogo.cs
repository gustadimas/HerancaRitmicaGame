using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarDialogo : MonoBehaviour
{
    public Mensagem[] mensagens;
    public NPC[] npcs;
    public bool dialogoCollider;

    [HideInInspector] public GameObject CaixaDeDialogo;

    float tempoUltimoToque;

    void Start()
    {
        CaixaDeDialogo.SetActive(true);
    }

    void Update()
    {
        if (dialogoCollider)
        {
            if (Input.touchCount == 1)
            {
                Touch toque = Input.GetTouch(0);

                if (toque.phase == TouchPhase.Began)
                {
                    if (Time.time - tempoUltimoToque < 0.5f)
                        ComecarDialogo();

                    tempoUltimoToque = Time.time;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            dialogoCollider = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            dialogoCollider = false;
    }

    public void ComecarDialogo()
    {
        FindObjectOfType<ControladorDialogo>().AbrirDialogo(mensagens, npcs);
    }
}

[System.Serializable]
public class Mensagem
{
    public int npcID;
    public string mensagens;
}

[System.Serializable]
public class NPC
{
    public string nome;
    public Sprite sprite;
}
