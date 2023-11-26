using UnityEngine;

public class DialogoFinal : MonoBehaviour
{
    [Header("Anciões:")]
    [SerializeField] GameObject reinaldo;
    [SerializeField] GameObject donaRosa;
    [SerializeField] GameObject zeMaria;

    Animator[] animator = new Animator[3];

    private void Start()
    {
        animator[0] = reinaldo.transform.GetChild(0).GetComponent<Animator>();
        animator[1] = donaRosa.transform.GetChild(0).GetComponent<Animator>();
        animator[2] = zeMaria.transform.GetChild(0).GetComponent<Animator>();
    }

    public void AnimacaoFinal(int _valor)
    {
        animator[0].SetInteger("estado", _valor == 0 ? 2 : 0);
        animator[1].SetInteger("estado", _valor == 1 ? 2 : 0);
        animator[2].SetInteger("estado", _valor == 2 ? 2 : 0);
    }
}