using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUIManager : MonoBehaviour
{

    public static CanvasUIManager sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }

        else
            Destroy(gameObject);
    }

    public GameObject Pausa;
    public GameObject Muerto;
    public GameObject Juego;

    private void Start()
    {
        Pausa.SetActive(false);
        Muerto.SetActive(false);
        Juego.SetActive(false);
    }

    public void MostrarPausa()
    {
        Pausa.SetActive(true);
        Muerto.SetActive(false);
        Juego.SetActive(false);
    }

    public void MostrarMuerto()
    {
        Pausa.SetActive(false);
        Muerto.SetActive(true);
        Juego.SetActive(false);
    }

    public void MostrarJuegoHUD()
    {
        Pausa.SetActive(false);
        Muerto.SetActive(false);
        Juego.SetActive(true);
    }
}
