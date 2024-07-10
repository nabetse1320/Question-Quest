using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoFinal : MonoBehaviour
{
    public float tiempoEntreChar;
    [SerializeField, TextArea(4, 5)] private string[] lineasDialogo;
    [SerializeField] private GameObject viñeta;
    [SerializeField] private GameObject viñeta2;
    private int LineIndex;
    private bool activeDialog;
    private void Update()
    {
        if (activeDialog && Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1) && activeDialog)
        {
            if (!activeDialog)
            {
                EmpezarDialogo();
            }
            else if (viñeta.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex] || viñeta2.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex])
            {
                NextDialogLine();
                if (LineIndex == lineasDialogo.Length)
                {
                    Eventos.eve.EscribirPregunta?.Invoke();

                }

            }
        }
    }

    private void EmpezarDialogo()
    {
        Eventos.eve.IniciarDialogo.RemoveListener(EmpezarDialogo);
        Eventos.eve.PausarPersonaje.Invoke();
        activeDialog = true;
        viñeta.SetActive(true);
        viñeta.GetComponentInChildren<Animator>().SetBool("abrir", true);
        LineIndex = 0;
        StartCoroutine(mostrarLinea());

    }
    private void NextDialogLine()
    {
        LineIndex++;
        if (LineIndex < lineasDialogo.Length)
        {
            if (viñeta.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex - 1])
            {
                StartCoroutine(ocultar());
                viñeta2.SetActive(true);
                viñeta2.GetComponentInChildren<Animator>().SetBool("abrir", true);
                StartCoroutine(mostrarLinea2());
            }
            if (viñeta2.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex - 1])
            {
                StartCoroutine(ocultar2());
                viñeta.SetActive(true);
                viñeta.GetComponentInChildren<Animator>().SetBool("abrir", true);
                StartCoroutine(mostrarLinea());
                

            }
        }
        else
        {
            StartCoroutine(ocultar2());
            StartCoroutine(ocultar());
            Eventos.eve.enemigoSeva.Invoke();
            Eventos.eve.PlaySecuense.Invoke();
            activeDialog = false;

        }
    }

    private void OnEnable()
    {
        Eventos.eve.IniciarDialogo.AddListener(EmpezarDialogo);
    }

    private IEnumerator mostrarLinea()
    {
        viñeta.GetComponentInChildren<TextMeshPro>().text = string.Empty;
        foreach (char line in lineasDialogo[LineIndex])
        {
            viñeta.GetComponentInChildren<TextMeshPro>().text += line;
            yield return new WaitForSecondsRealtime(tiempoEntreChar);
        }
    }

    private IEnumerator mostrarLinea2()
    {
        viñeta2.GetComponentInChildren<TextMeshPro>().text = string.Empty;
        foreach (char line in lineasDialogo[LineIndex])
        {
            viñeta2.GetComponentInChildren<TextMeshPro>().text += line;
            yield return new WaitForSecondsRealtime(tiempoEntreChar);
        }
    }
    private IEnumerator ocultar()
    {
        viñeta.GetComponentInChildren<Animator>().SetBool("abrir", false);
        yield return new WaitForSeconds(0.5f);
        viñeta.SetActive(false);
    }
    private IEnumerator ocultar2()
    {
        viñeta2.GetComponentInChildren<Animator>().SetBool("abrir", false);
        yield return new WaitForSeconds(0.5f);
        viñeta2.SetActive(false);
    }
}
