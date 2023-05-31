using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour
{
    public int puntos = 0;
    public int puntosPorSegundo = 50;
    public int puntosObjetivo = 1000;
    public float intervaloPuntos = 1f;
    public bool juegoTerminado = false;
    public GameObject menuWin;

    private void Start()
    {
        InvokeRepeating("SumarPuntos", intervaloPuntos, intervaloPuntos);
    }

    private void Update()
    {
        menuWin.SetActive(false);
        if (!juegoTerminado)
        {
            if (puntos >= puntosObjetivo)
            {
                GanarJuego();
            }
        }
    }

    private void SumarPuntos()
    {
        puntos += puntosPorSegundo;
    }

    private void GanarJuego()
    {
        juegoTerminado = true;
        Debug.Log("¡Has ganado!");
        menuWin.SetActive(true);
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
