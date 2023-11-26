using UnityEngine;

public class DialogoFinal : MonoBehaviour
{
    [Header("Anciões:")]
    [SerializeField] GameObject reinaldo;
    [SerializeField] GameObject donaRosa;
    [SerializeField] GameObject zeMaria;

    Animator animReinaldo, animDonaRosa, animZeMaria;

    private void Start()
    {
        animReinaldo = reinaldo.transform.GetChild(0).GetComponent<Animator>();
        animDonaRosa = donaRosa.transform.GetChild(0).GetComponent<Animator>();
        animZeMaria = zeMaria.transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        animReinaldo.SetInteger("estado", 2);
        animDonaRosa.SetInteger("estado", 2);
        animZeMaria.SetInteger("estado", 2);
    }
}
