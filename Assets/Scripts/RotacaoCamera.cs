using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float camSensibility;

    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Xmouse = (Input.GetAxis("Mouse X") * camSensibility);
        float Ymouse = (Input.GetAxis("Mouse Y") * camSensibility);

        rotation -= Ymouse;
        rotation = Mathf.Clamp(rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        player.Rotate(Vector3.up * Xmouse);
    }
}
