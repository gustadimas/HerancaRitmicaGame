using TMPro;
using UnityEngine;

public enum estadoMovimento { parado, andando, falando }

public class Jogador : MonoBehaviour
{
    [Header("Configura��es:")]
    [SerializeField] bool desativarEntradas = false;
    [SerializeField] float velocidadeMovimento;

    [Header("Atribui��es:")]
    [SerializeField] RectTransform joystick;
    [SerializeField] RectTransform areaJoystick;
    [SerializeField] RectTransform pontoJoystick;

    Vector3 direcaoMovimento;
    Vector2 posicaoPonto, posicaoInicialPonto;

    Rigidbody rb;
    Animator anima;

    estadoMovimento estado;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anima = transform.GetChild(0).gameObject.GetComponent<Animator>();
        posicaoInicialPonto = pontoJoystick.position;
    }

    void Update()
    {
        if (ControladorDialogo.dialogoAtivo)
        {
            direcaoMovimento = Vector3.zero;
            return;
        }

        if (ObjetivoTexto.textoAtivo)
        {
            direcaoMovimento = Vector3.zero;
            return;
        }

        if (!desativarEntradas)
            Joystick();

        AtualizarEstadoAnimacao();
    }

    void FixedUpdate()
    {
        if (direcaoMovimento != Vector3.zero)
        {
            Vector3 movimentoHorizontal = new Vector3(direcaoMovimento.x, 0, direcaoMovimento.y);

            rb.MovePosition(transform.position +  velocidadeMovimento * Time.deltaTime * movimentoHorizontal);
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

    void AtualizarEstadoAnimacao()
    {
        if (direcaoMovimento != Vector3.zero)
            estado = estadoMovimento.andando;

        else if(direcaoMovimento == Vector3.zero)
            estado = estadoMovimento.parado;

        anima.SetInteger("estado", (int)estado);
    }

    public void AlterarEstadoAnimacao(estadoMovimento _estado)
    {
        estado = _estado;
        anima.SetInteger("estado", 2);
    }
}