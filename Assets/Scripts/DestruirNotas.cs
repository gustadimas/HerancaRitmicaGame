using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirNotas : MonoBehaviour
{
    GameObject[] notasRed, notasGreen, notasPink, notasBlue;
    [SerializeField] Collider areaRed, areaGreen, areaPink, areaBlue;
    public static int pontos;
    [SerializeField] Slider barra;

    private void Start()
    {
        pontos = 50;
    }
    private void OnMouseUpAsButton()
    {
        if (gameObject.name == "BotaoRed")
            DestruirRed();

        if (gameObject.name == "BotaoGreen")
            DestruirGreen();

        if (gameObject.name == "BotaoPink")
            DestruirPink();

        if (gameObject.name == "BotaoBlue")
            DestruirBlue();
    }
    void Update()
    {
        notasRed = GameObject.FindGameObjectsWithTag("Red");
        notasGreen = GameObject.FindGameObjectsWithTag("Green");
        notasPink = GameObject.FindGameObjectsWithTag("Pink");
        notasBlue = GameObject.FindGameObjectsWithTag("Blue");
        AlterarBarra();
    }
    public void DestruirRed()
    {
        foreach (GameObject vermelho in notasRed)
        {
            Collider redCol = vermelho.GetComponent<Collider>();
            if (areaRed.bounds.Intersects(redCol.bounds))
            {
                pontos += 3;
                Destroy(vermelho);
            }
            else
            {
                pontos--;
            }
        }        
    }
    
    void DestruirGreen()
    {
        foreach (GameObject verde in notasGreen)
        {
            Collider greenCol = verde.GetComponent<Collider>();
            if (areaGreen.bounds.Intersects(greenCol.bounds))
            {
                pontos += 3;
                Destroy(verde);
            }
            else
            {
                pontos--;
            }
        }
    }

    void DestruirPink()
    {
        foreach (GameObject rosa in notasPink)
        {
            Collider pinkCol = rosa.GetComponent<Collider>();
            if (areaPink.bounds.Intersects(pinkCol.bounds))
            {
                pontos += 3;
                Destroy(rosa);
            }
            else
            {
                pontos--;
            }
        }
    }

    void DestruirBlue()
    {
        foreach (GameObject azul in notasBlue)
        {
            Collider blueCol = azul.GetComponent<Collider>();
            if (areaBlue.bounds.Intersects(blueCol.bounds))
            {
                pontos += 3;
                Destroy(azul);
            }
            else
            {
                pontos--;
            }
        }
    }

    void AlterarBarra()
    {
        barra.value = pontos;
    }
}
