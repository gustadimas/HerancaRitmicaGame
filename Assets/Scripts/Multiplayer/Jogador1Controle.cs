using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador1Controle : MonoBehaviourPunCallbacks
{
    GameObject[] notasRed, notasGreen, notasPink, notasBlue;
    public static int notasDestruidas1;
    public static int combo;
    Image mensagemCombo;
    [SerializeField] Sprite[] mensagens;
    PhotonView phView;

    void Start()
    {
        GameObject imagemCombo = GameObject.Find("MensagemCombo");
        mensagemCombo = imagemCombo.GetComponent<Image>();
        phView = GetComponent<PhotonView>();
        combo = 0;
        notasDestruidas1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        VerificarCombo();
        notasRed = GameObject.FindGameObjectsWithTag("Red");
        notasGreen = GameObject.FindGameObjectsWithTag("Green");
        notasPink = GameObject.FindGameObjectsWithTag("Pink");
        notasBlue = GameObject.FindGameObjectsWithTag("Blue");
        if (phView.IsMine)
        {
            if (Input.touchCount == 1)
            {
                Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(raio, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("AreaRed"))
                    {
                        foreach (var vermelho in notasRed)
                        {
                            Collider redCol = vermelho.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(redCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                combo++;
                                Destroy(vermelho);
                            }
                        }

                    }

                    if (hit.collider.CompareTag("AreaGreen"))
                    {
                        foreach (var verde in notasGreen)
                        {
                            Collider greenCol = verde.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(greenCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                combo++;
                                Destroy(verde);
                            }
                        }
                    }

                    if (hit.collider.CompareTag("AreaPink"))
                    {
                        foreach (var rosa in notasPink)
                        {
                            Collider pinkCol = rosa.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(pinkCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                combo++;
                                Destroy(rosa);
                            }
                        }
                    }

                    if (hit.collider.CompareTag("AreaBlue"))
                    {
                        foreach (var azul in notasBlue)
                        {
                            Collider blueCol = azul.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(blueCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                combo++;
                                Destroy(azul);
                            }
                        }
                    }
                }
            }
            //SEGUNDO TOQUE
            if (Input.touchCount == 2)
            {
                Ray raio = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Ray raio2 = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
                if (Physics.Raycast(raio, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("AreaRed"))
                    {
                        foreach (var vermelho in notasRed)
                        {
                            Collider redCol = vermelho.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(redCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                Destroy(vermelho);
                            }
                        }

                    }

                    if (hit.collider.CompareTag("AreaGreen"))
                    {
                        foreach (var verde in notasGreen)
                        {
                            Collider greenCol = verde.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(greenCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                Destroy(verde);
                            }
                        }
                    }

                    if (hit.collider.CompareTag("AreaPink"))
                    {
                        foreach (var rosa in notasPink)
                        {
                            Collider pinkCol = rosa.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(pinkCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                Destroy(rosa);
                            }
                        }
                    }

                    if (hit.collider.CompareTag("AreaBlue"))
                    {
                        foreach (var azul in notasBlue)
                        {
                            Collider blueCol = azul.GetComponent<Collider>();
                            if (hit.collider.bounds.Intersects(blueCol.bounds))
                            {
                                PhotonNetwork.LocalPlayer.AddScore(1);
                                notasDestruidas1++;
                                Destroy(azul);
                            }
                        }
                    }

                    // Parte do 2º toque

                    if (Physics.Raycast(raio2, out RaycastHit hit2))
                    {
                        if (hit2.collider.CompareTag("AreaRed"))
                        {
                            foreach (var vermelho in notasRed)
                            {
                                Collider redCol = vermelho.GetComponent<Collider>();
                                if (hit2.collider.bounds.Intersects(redCol.bounds))
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    Destroy(vermelho);
                                }
                            }

                        }

                        if (hit2.collider.CompareTag("AreaGreen"))
                        {
                            foreach (var verde in notasGreen)
                            {
                                Collider greenCol = verde.GetComponent<Collider>();
                                if (hit2.collider.bounds.Intersects(greenCol.bounds))
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    Destroy(verde);
                                }
                            }
                        }

                        if (hit2.collider.CompareTag("AreaPink"))
                        {
                            foreach (var rosa in notasPink)
                            {
                                Collider pinkCol = rosa.GetComponent<Collider>();
                                if (hit2.collider.bounds.Intersects(pinkCol.bounds))
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    Destroy(rosa);
                                }
                            }
                        }

                        if (hit2.collider.CompareTag("AreaBlue"))
                        {
                            foreach (var azul in notasBlue)
                            {
                                Collider blueCol = azul.GetComponent<Collider>();
                                if (hit2.collider.bounds.Intersects(blueCol.bounds))
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    Destroy(azul);
                                }
                            }
                        }
                    }
                }
        
            }
        }
    }

    void VerificarCombo()
    {
        switch (combo)
        {
            case 0:
                mensagemCombo.enabled = false;
                break;

            case 3:
                mensagemCombo.enabled = true;
                mensagemCombo.sprite = mensagens[0];
                StartCoroutine(AumentaEDiminui());
                break;

            case 6:
                mensagemCombo.sprite = mensagens[1];
                StartCoroutine(AumentaEDiminui());
                break;

            case 9:
                mensagemCombo.sprite = mensagens[2];
                StartCoroutine(AumentaEDiminui());
                break;

            case 12:
                mensagemCombo.sprite = mensagens[3];
                StartCoroutine(AumentaEDiminui());
                break;
        }
    }

    IEnumerator AumentaEDiminui()
    {
        float tempoDecorrido = 0f;
        float duracaoAnimacao = 0.3f;

        Vector3 escalaInicial = mensagemCombo.rectTransform.localScale;
        Vector3 escalaFinal = new Vector3(1.5f, 1.5f, 1f);

        while (tempoDecorrido < duracaoAnimacao)
        {
            mensagemCombo.rectTransform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tempoDecorrido / duracaoAnimacao);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }

        mensagemCombo.rectTransform.localScale = escalaFinal;

        yield return new WaitForSeconds(0.2f);

        tempoDecorrido = 0f;
        escalaInicial = mensagemCombo.rectTransform.localScale;
        escalaFinal = new Vector3(1f, 1f, 1f);

        while (tempoDecorrido < duracaoAnimacao)
        {
            mensagemCombo.rectTransform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tempoDecorrido / duracaoAnimacao);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }
        mensagemCombo.rectTransform.localScale = escalaFinal;
    }
}
