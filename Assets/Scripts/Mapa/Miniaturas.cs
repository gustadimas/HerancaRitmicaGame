using UnityEngine;

public class Miniaturas : MonoBehaviour
{
    [SerializeField] GameObject quingoma, quilombo1, quilombo2;

    Vector3 rotacionarY = Vector3.up;
    float rotationSpeed = 40f;

    void Update()
    {
            quingoma.transform.Rotate(rotacionarY, rotationSpeed * Time.deltaTime);
            quilombo1.transform.Rotate(rotacionarY, rotationSpeed * Time.deltaTime);
            quilombo2.transform.Rotate(rotacionarY, rotationSpeed * Time.deltaTime);
    }
}