using UnityEngine;

public class Script_notaTudo : MonoBehaviour
{
    [SerializeField] float velocidaddy;
    void Update()
    {
        transform.position += velocidaddy * Time.deltaTime * Vector3.up;
    }
}