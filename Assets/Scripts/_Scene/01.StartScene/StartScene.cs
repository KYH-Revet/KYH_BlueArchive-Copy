using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [Header("UI")]
    public GameObject loginUI;
    public GameObject loadingUI;
    public GameObject touchToStartUI;
    
    bool entryLoading = false;  //Scene loading start, this variable is for don't start again coroutine function
    bool endLoading = false;    //Load end(async.progress >= 0.9), show up the touchToStartUI

    private void Update()
    {
        //Start loading into the lobby scene
        if (entryLoading) return;

        //Login complete start load scene
        if (DataInitialize.login)
        {
            //Debug.Log("Complete login] LobbyScene 로드");
            //Login UI Off / Sign on of started load scene
            loginUI.SetActive(false);
            entryLoading = true;

            //Load Scene
            //StartCoroutine("Loading");
            SceneHistory.LoadScene(SceneHistory.lobbyName);
        }
    }

    //Button Functions
    public void Btn_LoginUISetActive()
    {
        //It already activated
        if (loginUI.activeSelf) return;
        //DatatInitialize (Dictionary that character info it loaded yet or Login is done)
        if (!DataInitialize.load_Dictionary_CharacterInfo || DataInitialize.login) return;
        
        //Set active login UI
        loginUI.SetActive(true);
    }

    IEnumerator Loading()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("LobbyScene");
        async.allowSceneActivation = false;

        loadingUI.SetActive(true);

        DataInitialize.load_User_Character = SignManager.Load_User_Character();

        while (!async.isDone && DataInitialize.load_User_Character)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!endLoading)
                {
                    Debug.Log("로딩 끝");
                    loadingUI.SetActive(false);         //Loading ui off
                    touchToStartUI.SetActive(true);     //Touch to start ui on
                    endLoading = true;
                }
                else
                {
                    Debug.Log("Change next scene");
                    async.allowSceneActivation = true;  //Load Scene
                }
            }

            yield return null;
        }
    }
}

