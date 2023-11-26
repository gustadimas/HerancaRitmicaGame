using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtivarDialogo : MonoBehaviour
{
    public Mensagem[] mensagens;
    public NPC[] npcs;
    public static bool dialogoCollider;

    [HideInInspector] public bool controleDialogo = false;
    [HideInInspector] public bool animacao = false;

    [HideInInspector] public GameObject CaixaDeDialogo;

    Animator anim;

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        if (animacao)
            anim.SetInteger("estado", 2);

        else
            anim.SetInteger("estado", 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 posicaoObjeto = collision.gameObject.transform.position;

            dialogoCollider = true;
            controleDialogo = true;
            animacao = false;

            transform.LookAt(Vector3.Lerp(transform.position, new Vector3(posicaoObjeto.x, transform.position.y, posicaoObjeto.z), .5f));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogoCollider = false;
            controleDialogo = false;
            animacao = false;
        }
    }

    public void ComecarDialogo()
    {
        if (controleDialogo)
        {
            animacao = true;
            FindObjectOfType<ControladorDialogo>().AbrirDialogo(mensagens, npcs);
        }
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