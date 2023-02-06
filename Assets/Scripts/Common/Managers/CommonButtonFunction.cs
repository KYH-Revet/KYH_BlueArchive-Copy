using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonButtonFunction : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip buttonClickSound;

    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    public static void UI_On(GameObject ui)
    {
        ui.SetActive(true);
    }
    public static void UI_Off(GameObject ui)
    {
        ui.SetActive(false);
    }

    public void Btn_LoadScene(string name)
    {
        SceneHistory.LoadScene(new SceneHistory.SceneName(name, name));
    }

    public void PlayButtonClickSound()
    {
        audioSource.clip = buttonClickSound;
        audioSource.Play();
    }
}
