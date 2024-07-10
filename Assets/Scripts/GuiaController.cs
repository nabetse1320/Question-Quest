using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GuiaController : MonoBehaviour
{
    Vector2 globalScale;
    private string a = "";
    private string b = "";
    private string c = "";
    public TextMeshPro textMeshPro;
    [TextArea]
    public string textoIn;
    void Start()
    {
        globalScale = GetComponentInParent<BoxCollider2D>().transform.lossyScale;
    }
    private void Update()
    {
        questions();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<Animator>().SetBool("abrir",true);
            GetComponentInParent<BoxCollider2D>().transform.transform.localScale = globalScale;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<Animator>().SetBool("abrir", false);
        }
    }

    public void mandarA(string t) { 
        a = t;
    }

    public void mandarB(string t)
    {
        b = t;
    }

    public void mandarC(string t)
    {
        c = t;
    }


    private void questions() {
        string formula = textoIn + "A: "+a+ "\n"+"\nB: " +b+ "\n"+"\nC: " +c;
        textMeshPro.text = formula;
        
        
    }
}
