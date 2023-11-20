using UnityEngine;

public class FPS : MonoBehaviour
{
    float deltaTime = 0.0f;
    GUIStyle style;

    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.black;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        Rect rect = new Rect(120, 20, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}