using UnityEngine;

[ExecuteAlways]
public class GerenciadorDeIluminacao : MonoBehaviour
{
    [Header("Luz e Preset de Luz:")]
    [SerializeField] private Light LuzDirecional;
    [SerializeField] private PresetDeIluminacao Preset;

    [Header("Definir a Hora:")]
    [SerializeField, Range(0, 24)] private float HoraDoDia;


    private void Update()
    {
        AtualizarIluminacao(HoraDoDia / 24f);

        if (Preset == null)
            return;

        // Remover esta verificação permite a mudança manual
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
        RenderSettings.ambientLight = Preset.CorAmbiente.Evaluate(percentualDeTempo);
        RenderSettings.fogColor = Preset.CorNeblina.Evaluate(percentualDeTempo);

        if (LuzDirecional != null)
        {
            LuzDirecional.color = Preset.CorDirecional.Evaluate(percentualDeTempo);
            LuzDirecional.transform.localRotation = Quaternion.Euler(new Vector3((percentualDeTempo * 360f) - 90f, 170f, 0));
        }

    }

    private void OnValidate()
    {
        if (LuzDirecional != null)
            return;

        if (RenderSettings.sun != null)
            LuzDirecional = RenderSettings.sun;

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
