using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Aleatorias_preguntas : MonoBehaviour
{
    public GameObject[] orbes;
    public GameObject GUiaCollider;
    public GameObject Resultados;
    public string[] preguntas;
    private string[] indices = {"A","B","C"};
    public string[] respuestasCorrectas;
    public string[] respuestasIncorrectas1;
    public string[] respuestasIncorrectas2;
    private string[][] bancoDePreguntas;
    public string[] UsadasPrefsName;
    public string[] usadas;
    private string pregunta;


    private void Awake()
    {
        LoadData();

    }
    // Start is called before the first frame update
    void Start()
    {
        
        CreacionMatriz();
        ElegirPreguntas();
        
    }

    // Update is called once per frame

    private void ElegirPreguntas() {
        int usadaInt=0;
        
        int n = Random.Range(0, preguntas.Length);
        for (int i = 0; i < preguntas.Length; i++)
        {
            if (bancoDePreguntas[4][i].Equals("f"))
            {
                usadaInt++;
            }
        }
        if (usadaInt!=preguntas.Length)
        {
            while (bancoDePreguntas[4][n].Equals("f"))
            {
                n = Random.Range(0, preguntas.Length);
            }

            pregunta = bancoDePreguntas[0][n];
            
            AsignarRespuestaCorrecta(n);
            bancoDePreguntas[4][n] = "f";
        }else
        {
            for (int i = 0; i < usadas.Length; i++)
            {
                usadas[i] = "t";
            }
            pregunta = bancoDePreguntas[0][n];
            
            AsignarRespuestaCorrecta(n);
            bancoDePreguntas[4][n] = "f";
        }

    }

    private void AsignarRespuestaCorrecta(int i) {

        int n = Random.Range(0,orbes.Length);
        int a = Random.Range(0, indices.Length);
        int b = Random.Range(0, indices.Length);
        int c = Random.Range (0, indices.Length);
        orbes[n].GetComponent<Recolectar>().correcta = true;
  
        while (a==b || a==c || b==c)
        {
            b = Random.Range(0, indices.Length);
            c = Random.Range(0, indices.Length);
            a = Random.Range(0, indices.Length);
        }
        
        orbes[0].GetComponentInChildren<TextMeshPro>().SetText(indices[a]);
        orbes[1].GetComponentInChildren<TextMeshPro>().SetText(indices[b]);
        orbes[2].GetComponentInChildren<TextMeshPro>().SetText(indices[c]);

        for (int e = 0; e < orbes.Length; e++)
        {
            
            if (orbes[e].GetComponent<Recolectar>().correcta)
            {
                if (orbes[e].GetComponentInChildren<TextMeshPro>().text.Equals("A"))
                {
                    MandarPreguntas(bancoDePreguntas[1][i],bancoDePreguntas[2][i],bancoDePreguntas[3][i]);
                }
                if (orbes[e].GetComponentInChildren<TextMeshPro>().text.Equals("B"))
                {
                    MandarPreguntas(bancoDePreguntas[2][i], bancoDePreguntas[1][i], bancoDePreguntas[3][i]);
                }
                if (orbes[e].GetComponentInChildren<TextMeshPro>().text.Equals("C"))
                {
                    MandarPreguntas(bancoDePreguntas[3][i], bancoDePreguntas[2][i], bancoDePreguntas[1][i]);
                }
            }
        }
    }

    private void MandarPreguntas(string a, string b, string c) {
        GUiaCollider.GetComponent<GuiaController>().mandarA(a);
        GUiaCollider.GetComponent<GuiaController>().mandarB(b);
        GUiaCollider.GetComponent<GuiaController>().mandarC(c);
    }

    private void CreacionMatriz() {
        bancoDePreguntas = new string[5][];
        bancoDePreguntas[0] = preguntas;
        bancoDePreguntas[1] = respuestasCorrectas;
        bancoDePreguntas[2] = respuestasIncorrectas1;
        bancoDePreguntas[3] = respuestasIncorrectas2;
        bancoDePreguntas[4] = usadas;

    }

    private void MandarLaPregunta() 
    {
        Resultados.GetComponent<TextMeshPro>().text += pregunta;
    }

    private void OnDestroy()
    {
        SaveData();

    }

    private void SaveData()
    {
        for (int i = 0; i < usadas.Length; i++)
        {
            PlayerPrefs.SetString(UsadasPrefsName[i], usadas[i]);
        }

        
    }
    private void LoadData()
    {
        for (int i = 0; i < UsadasPrefsName.Length; i++)
        {
            usadas[i] = PlayerPrefs.GetString(UsadasPrefsName[i]);
        }
        
    }
    private void OnEnable()
    {
        Eventos.eve.EscribirPregunta.AddListener(MandarLaPregunta);
    }
}
