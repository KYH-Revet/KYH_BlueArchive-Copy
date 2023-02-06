using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadWithFade : MonoBehaviour
{
    public bool noFadeIn;
    /// <summary>Scene is next target</summary>
    [NonSerialized] public string targetScene;

    Animator animator;

    private void Awake()
    {
        //Get Component
        animator = GetComponent<Animator>();

        //Animation Play Fade IN\
        if(!noFadeIn)
            animator.SetTrigger("FadeIn");
    }

    //Class Function
    public void StartLoadScene(string name)
    {
        targetScene = name;
        animator.SetTrigger("FadeOut");
    }

    //Animation Event Function
    public void EndEventFade()
    {
        SceneManager.LoadScene(targetScene);
    }
}
