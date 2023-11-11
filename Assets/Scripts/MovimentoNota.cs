using UnityEngine;

public class MovimentoNota : MonoBehaviour
{
    [SerializeField] float velocidaddy;
    void Update()
    {
        transform.position += velocidaddy * Time.deltaTime * Vector3.up;
    }
}