using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

/// <summary>
/// Save Data (SceneName) in Stack
/// <para>Manage the functions that load the scene.</para>
/// </summary>
public class SceneHistory : MonoBehaviour
{
    static string lobby = "LobbyScene";
    static string loading = "LoadingScene";
    public static string lobbyName { get { return lobby; } }
    public static string LoadingName { get { return loading; } }

    //History of load scene
    public static Stack<string> history = new Stack<string>();

    //Unity Functions
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //Class Functions
    public static void LoadScene(string nextScene)
    {
        //Push data(next scene)
        history.Push(nextScene);

        LoadPeekScene();
    }
    public static void LoadPrevScene()
    {
        //Pop data(current scene)
        history.Pop();

        LoadPeekScene();
    }
    public static void LoadLobbyScene()
    {
        //Clear a data except lobby
        while(history.Count > 1)
            history.Pop();

        LoadPeekScene();
    }
    public static void LoadSceneWithLoadingScene(string sceneName)
    {
        history.Push(sceneName);

        Fade(loading);
    }
    public static void LoadPeekScene()
    {
        Fade(history.Peek());
    }
    private static void Fade(string name)
    {
        SceneLoadWithFade fade = FindObjectOfType<SceneLoadWithFade>();
        if (fade == null)    //Load scene without fade in/out
            SceneManager.LoadScene(name);
        else                //Load scene with fade in/out
            fade.StartLoadScene(name);
    }
}
