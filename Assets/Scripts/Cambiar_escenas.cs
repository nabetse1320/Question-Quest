using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiar_escenas : MonoBehaviour

{
    private Animator transitionAnimator;
    public GameObject hijo;
    public int Scenee;
    [SerializeField] private float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        Invoke("ActivarCanva", transitionTime);
        

    }

    // Update is called once per frame

    public void LoadNextScene(int Scene) {
        
        StartCoroutine(SceneLoad(Scene));

    }


    public void salir() 
    {
        StartCoroutine(cerrar());
    }


    public IEnumerator SceneLoad(int Scene) {
        hijo.SetActive(true);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Scene);
        
    }

    public IEnumerator cerrar()
    {
        
        hijo.SetActive(true);
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        Application.Quit();
    }

    private void ActivarCanva() {
        hijo.SetActive(false);
    }
}
