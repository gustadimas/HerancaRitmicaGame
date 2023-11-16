using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirNotas : MonoBehaviour
{
    [SerializeField] Collider areaRed, areaGreen, areaPink, areaBlue;
    [SerializeField] Slider barra;
    public static float pontos;

    private void Start()
    {
        pontos = 50;
    }
    void Update()
    {
        barra.value = pontos;
        if (Input.touchCount > 0)
        {
            Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            
            if (Physics.Raycast(raio, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Red"))
                {
                    if (hit.collider.bounds.Intersects(areaRed.bounds))
                    {
                        pontos++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.5f;
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.CompareTag("Green"))
                {
                    if (hit.collider.bounds.Intersects(areaGreen.bounds))
                    {
                        pontos++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.5f;
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.CompareTag("Pink"))
                {
                    if (hit.collider.bounds.Intersects(areaPink.bounds))
                    {
                        pontos++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.5f;
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.CompareTag("Blue"))
                {
                    if (hit.collider.bounds.Intersects(areaBlue.bounds))
                    {
                        pontos++;
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        pontos -= 0.5f;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }


        }
    }
   /* void DestruirRed()
    {
        foreach (GameObject vermelho in notasRed)
        {
            Collider redCol = vermelho.GetComponent<Collider>();
            if (areaRed.bounds.Intersects(redCol.bounds))
            {
                LimiteNotas.pontos += 3;
                Destroy(vermelho);
            }
            else
            {
                //LimiteNotas.pontos -= 0.5f;
                Destroy(gameObject);
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
                LimiteNotas.pontos += 3;
                Destroy(verde);
            }
            else
            {
                //LimiteNotas.pontos -= 0.5f;
                Destroy(gameObject);
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
                LimiteNotas.pontos += 3;
                Destroy(rosa);
            }
            else
            {
                // LimiteNotas.pontos -= 0.5f;
                Destroy(gameObject);
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
                LimiteNotas.pontos += 3;
                Destroy(azul);
            }
            else
            {
                //LimiteNotas.pontos -= 0.5f;
                Destroy(gameObject);
            }
        }
    }*/
}
