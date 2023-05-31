using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //menu
    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject menuWin;
    //fondo
    public Renderer fondo;
    //crear mapa
    public GameObject col;
    public List<GameObject> cols;
    public float velocidad = 2;
    //piedras
    public GameObject piedra1;
    public GameObject piedra2;
    public List<GameObject> obstaculos;
    //para el juego
    public bool gameOver = false;
    public bool start = false;
    //obstaculos aire
    public GameObject torre1;
    public GameObject inicio1;
    public List<GameObject> inicio;
    //puntuacion
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        //craer mapa
        for (int i = 0; i <= 21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-11 + i, -4), Quaternion.identity));
        }
        //crear piedras
        //obstaculos.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        //obstaculos.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));
        
        obstaculos.Add(Instantiate(torre1, new Vector2(4, 5), Quaternion.identity));
        obstaculos.Add(Instantiate(torre1, new Vector2(6, 2), Quaternion.identity));
        obstaculos.Add(Instantiate(inicio1, new Vector2(0, 1), Quaternion.identity));        
    }


    void Update(){
        //incia el juego cuando presiono x
        if (start == false)
        {
            menuWin.SetActive(false);

            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        //muere
        if (start == true && gameOver == true)
        {
            menuWin.SetActive(false);
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        //gana
        if (start == true && win == true)
        {
            menuWin.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (start == true && gameOver == false)
        {
             menuPrincipal.SetActive(false);
             menuWin.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
            //Mover mapa
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -11)
                {
                    cols[i].transform.position = new Vector3(11, -4, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            //mover obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    float randomObsX = Random.Range(11, 18);
                    float randomObsY = Random.Range(-3, 4);
                    obstaculos[i].transform.position = new Vector3(randomObsX, randomObsY, 0);
                }
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            //piedra incial
            for (int i = 0; i < 2; i++)
            {
                inicio[i].transform.position = inicio[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

        }
        
       
    }

}
