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

    void FixedUpdate()
    {
        if (direcaoMovimento != Vector3.zero)
        {
            Vector3 movimentoHorizontal = new Vector3(direcaoMovimento.x, 0, direcaoMovimento.y);

            rb.MovePosition(transform.position + movimentoHorizontal * velocidadeMovimento * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimentoHorizontal), 0.15f);
        }
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

                    // Defina a direção do movimento enquanto o dedo está se movendo
                    direcaoMovimento = (pontoJoystick.position - joystick.position).normalized;
                }

                if (toque.phase == TouchPhase.Ended || toque.phase == TouchPhase.Canceled)
                {
                    ResetarPosicaoJoystick();
                    direcaoMovimento = Vector3.zero;
                }
            }
            else
            {
                ResetarPosicaoJoystick();
                direcaoMovimento = Vector3.zero;
            }
        }
    }


    void ResetarPosicaoJoystick()
    {
        posicaoPonto = Vector2.zero;
        pontoJoystick.position = posicaoInicialPonto;
    }
}
