using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Sprite[] comics;
    Image comic;
    string path_Comic = "Sprites\\LoadingComic";

    void Awake()
    {
        SetComic();
    }

    void Start()
    {
        LoadScene();
    }

    void SetComic()
    {
        //Get Component
        comic = GetComponent<Image>();

        //Get Comic sprties
        comics = Resources.LoadAll<Sprite>(path_Comic);

        //Set comic image
        if (comic != null && comics != null)
        {
            //Set random comic
            int idx = Random.Range(0, comics.Length);
            comic.sprite = comics[idx];
        }
    }

    void LoadScene()
    {
        SceneHistory.LoadPeekScene();
    }

}
