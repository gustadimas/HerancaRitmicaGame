using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoviPersona : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = cam.forward * Input.GetAxis("Vertical") + cam.right * Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
    }
}
