using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoFinal : MonoBehaviour
{
    public float tiempoEntreChar;
    [SerializeField, TextArea(4, 5)] private string[] lineasDialogo;
    [SerializeField] private GameObject vi�eta;
    [SerializeField] private GameObject vi�eta2;
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
            else if (vi�eta.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex] || vi�eta2.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex])
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
        vi�eta.SetActive(true);
        vi�eta.GetComponentInChildren<Animator>().SetBool("abrir", true);
        LineIndex = 0;
        StartCoroutine(mostrarLinea());

    }
    private void NextDialogLine()
    {
        LineIndex++;
        if (LineIndex < lineasDialogo.Length)
        {
            if (vi�eta.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex - 1])
            {
                StartCoroutine(ocultar());
                vi�eta2.SetActive(true);
                vi�eta2.GetComponentInChildren<Animator>().SetBool("abrir", true);
                StartCoroutine(mostrarLinea2());
            }
            if (vi�eta2.GetComponentInChildren<TextMeshPro>().text == lineasDialogo[LineIndex - 1])
            {
                StartCoroutine(ocultar2());
                vi�eta.SetActive(true);
                vi�eta.GetComponentInChildren<Animator>().SetBool("abrir", true);
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
        vi�eta.GetComponentInChildren<TextMeshPro>().text = string.Empty;
        foreach (char line in lineasDialogo[LineIndex])
        {
            vi�eta.GetComponentInChildren<TextMeshPro>().text += line;
            yield return new WaitForSecondsRealtime(tiempoEntreChar);
        }
    }

    private IEnumerator mostrarLinea2()
    {
        vi�eta2.GetComponentInChildren<TextMeshPro>().text = string.Empty;
        foreach (char line in lineasDialogo[LineIndex])
        {
            vi�eta2.GetComponentInChildren<TextMeshPro>().text += line;
            yield return new WaitForSecondsRealtime(tiempoEntreChar);
        }
    }
    private IEnumerator ocultar()
    {
        vi�eta.GetComponentInChildren<Animator>().SetBool("abrir", false);
        yield return new WaitForSeconds(0.5f);
        vi�eta.SetActive(false);
    }
    private IEnumerator ocultar2()
    {
        vi�eta2.GetComponentInChildren<Animator>().SetBool("abrir", false);
        yield return new WaitForSeconds(0.5f);
        vi�eta2.SetActive(false);
    }
}
