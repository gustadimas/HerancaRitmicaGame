using TMPro;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] bool desativarEntradas = false;
    [SerializeField] float velocidadeMovimento;

    [Header("Atribuições:")]
    [SerializeField] RectTransform joystick;
    [SerializeField] RectTransform areaJoystick;
    [SerializeField] RectTransform pontoJoystick;

    Vector3 direcaoMovimento;
    Vector2 posicaoPonto, posicaoInicialPonto;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicaoInicialPonto = pontoJoystick.position;
    }

    void Update()
    {
        if (!desativarEntradas)
            Joystick();
    }

    void Joystick()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            Vector2 posicaoToque = toque.position;

            if (RectTransformUtility.RectangleContainsScreenPoint(areaJoystick, posicaoToque))
            {
                if (toque.phase == TouchPhase.Moved)
                {
                    posicaoPonto = toque.position - (Vector2)joystick.position;
                    posicaoPonto = Vector2.ClampMagnitude(posicaoPonto, 50f);

                    pontoJoystick.position = (Vector2)joystick.position + posicaoPonto;
                }

                if (toque.phase == TouchPhase.Ended || toque.phase == TouchPhase.Canceled)
                    ResetarPosicaoJoystick();
            }

            else
                ResetarPosicaoJoystick();
        }

        direcaoMovimento = (pontoJoystick.position - joystick.position).normalized;

        if (direcaoMovimento != Vector3.zero)
        {
            rb.velocity = new Vector3(direcaoMovimento.x * velocidadeMovimento, rb.velocity.y, direcaoMovimento.y * velocidadeMovimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direcaoMovimento.x, 0, direcaoMovimento.y)), 0.15f);
        }
        else
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    void ResetarPosicaoJoystick()
    {
        posicaoPonto = Vector2.zero;
        pontoJoystick.position = posicaoInicialPonto;
    }
}
