using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Preset de Ilumina��o", menuName = "Scriptables/Preset de Ilumina��o", order = 1)]
public class PresetDeIluminacao : ScriptableObject
{
    public Gradient CorAmbiente;    // Cor Ambiente
    public Gradient CorDirecional;    // Cor Direcional
    public Gradient CorNeblina;    // Cor da Neblina
}