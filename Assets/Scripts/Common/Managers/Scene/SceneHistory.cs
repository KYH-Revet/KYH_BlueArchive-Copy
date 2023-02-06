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

    //Scene Infomation Struct
    [System.Serializable]
    public struct SceneName
    {
        public string sceneName;
        public string sceneNameForUI;
        public SceneName(string sceneName, string sceneNameForUI)
        {
            this.sceneName = sceneName;
            this.sceneNameForUI = sceneNameForUI;
        }
    }
    
    //History of load scene
    public static Stack<SceneName> history = new Stack<SceneName>();

    //Unity Functions
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //Class Functions
    public static void LoadScene(SceneName nextScene)
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
    public static void LoadSceneWithLoadingScene(SceneName sceneName)
    {
        history.Push(sceneName);

        Fade(loading);
    }
    public static void LoadPeekScene()
    {
        Fade(history.Peek().sceneName);
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
