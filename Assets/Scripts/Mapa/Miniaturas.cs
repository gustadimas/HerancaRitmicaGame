using UnityEngine;

public class Miniaturas : MonoBehaviour
{
    [SerializeField] GameObject quingoma, quilombo1, quilombo2;

    Vector3 rotacionarY = Vector3.up;
    float rotationSpeed = 40f;

    void Update()
    {
        //if (ControladorCenas.quingoma)
            quingoma.transform.Rotate(rotacionarY, rotationSpeed * Time.deltaTime);

        //if (ControladorCenas.quilombo1)
            quilombo1.transform.Rotate(rotacionarY, rotationSpeed * Time.deltaTime);

        //if (ControladorCenas.quilombo2)
            quilombo2.transform.Rotate(rotacionarY, rotationSpeed * Time.deltaTime);
    }
}