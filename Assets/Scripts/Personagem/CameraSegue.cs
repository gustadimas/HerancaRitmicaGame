using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    [Header("Configuração da Camera:")]
    [SerializeField] Transform obj;
    [SerializeField] float suavizacao;
    [SerializeField] Vector3 deslocamento;
    
    Vector3 velocidade = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        if (obj != null)
        {
            Vector3 posicaoObj = obj.position + deslocamento;
            transform.position = Vector3.SmoothDamp(transform.position, posicaoObj, ref velocidade, suavizacao);
        } 
    }
}