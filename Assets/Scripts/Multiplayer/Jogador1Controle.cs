using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Jogador1Controle : MonoBehaviourPunCallbacks
{
    GameObject[] notasRed, notasGreen, notasPink, notasBlue;
    public static int notasDestruidas1;
    public static int combo;
    PhotonView phView;

    void Start()
    {
        phView = GetComponent<PhotonView>();
        combo = 0;
        notasDestruidas1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(vermelho);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(vermelho);
                                }
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(verde);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(verde);
                                }
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(rosa);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(rosa);
                                }
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(azul);
                                }
                                else
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(vermelho);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(vermelho);
                                }
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(verde);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(verde);
                                }
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(rosa);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(rosa);
                                }
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
                                if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(50);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(azul);
                                }
                                else
                                {
                                    PhotonNetwork.LocalPlayer.AddScore(1);
                                    notasDestruidas1++;
                                    combo++;
                                    Destroy(azul);
                                }
                            }
                        }
                    }

                    // Parte do 2� toque

                    if (Physics.Raycast(raio2, out RaycastHit hit2))
                    {
                        if (hit2.collider.CompareTag("AreaRed"))
                        {
                            foreach (var vermelho in notasRed)
                            {
                                Collider redCol = vermelho.GetComponent<Collider>();
                                if (hit2.collider.bounds.Intersects(redCol.bounds))
                                {
                                    if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                    {
                                        PhotonNetwork.LocalPlayer.AddScore(50);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(vermelho);
                                    }
                                    else
                                    {
                                        PhotonNetwork.LocalPlayer.AddScore(1);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(vermelho);
                                    }
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
                                    if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                    {
                                        PhotonNetwork.LocalPlayer.AddScore(50);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(verde);
                                    }
                                    else
                                    {
                                        PhotonNetwork.LocalPlayer.AddScore(1);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(verde);
                                    }
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
                                    if (PhotonNetwork.LocalPlayer.GetScore() < 50)
                                    {
                                        PhotonNetwork.LocalPlayer.AddScore(50);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(rosa);
                                    }
                                    else
                                    {
                                        PhotonNetwork.LocalPlayer.AddScore(1);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(rosa);
                                    }
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
                                    if(PhotonNetwork.LocalPlayer.GetScore() < 50)
                                {
                                        PhotonNetwork.LocalPlayer.AddScore(50);
                                        notasDestruidas1++;
                                        combo++;
                                        Destroy(azul);
                                    }
                                else
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
                }
        
            }
        }
    }
}
