using UnityEngine;

[ExecuteAlways]
public class GerenciadorDeIluminacao : MonoBehaviour
{
    // Referências da Cena
    [SerializeField] private Light LuzDirecional;
    [SerializeField] private PresetDeIluminacao Preset;
    // Variáveis
    [SerializeField, Range(0, 24)] private float HoraDoDia;


    private void Update()
    {
        AtualizarIluminacao(HoraDoDia / 24f);

        if (Preset == null)
            return;

        // Remova esta verificação para permitir a mudança manual
        // if (Application.isPlaying)
        // {
        //     //(Substituir por uma referência ao tempo de jogo)
        //     HoraDoDia += Time.deltaTime;
        //     HoraDoDia %= 24; // Módulo para garantir que sempre esteja entre 0-24
        //     AtualizarIluminacao(HoraDoDia / 24f);
        // }
        // else
        // {
        //             AtualizarIluminacao(HoraDoDia / 24f);
        // }
    }


    private void AtualizarIluminacao(float percentualDeTempo)
    {
        // Definir luz ambiente e cor da neblina
        RenderSettings.ambientLight = Preset.CorAmbiente.Evaluate(percentualDeTempo);
        RenderSettings.fogColor = Preset.CorNeblina.Evaluate(percentualDeTempo);

        // Se a luz direcional estiver configurada, então rotacionar e definir sua cor
        if (LuzDirecional != null)
        {
            LuzDirecional.color = Preset.CorDirecional.Evaluate(percentualDeTempo);

            // A rotação raramente é usada, pois gera sombras longas, a menos que o valor seja limitado
            LuzDirecional.transform.localRotation = Quaternion.Euler(new Vector3((percentualDeTempo * 360f) - 90f, 170f, 0));
        }

    }

    // Tente encontrar uma luz direcional para usar se não tivermos configurado uma
    private void OnValidate()
    {
        if (LuzDirecional != null)
            return;

        // Procurar pela luz do sol nas configurações de iluminação
        if (RenderSettings.sun != null)
        {
            LuzDirecional = RenderSettings.sun;
        }
        // Procurar na cena por uma luz que atenda aos critérios (luz direcional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    LuzDirecional = light;
                    return;
                }
            }
        }
    }
}
