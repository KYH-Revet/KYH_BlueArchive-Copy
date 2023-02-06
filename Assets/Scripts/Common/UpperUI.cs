using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperUI : MonoBehaviour
{
    public Text txt_SceneName;
    public Text txt_AP;
    public Text txt_Credit;
    public Text txt_Cash;

    public static string sceneName = "";

    private void Awake()
    {
        txt_SceneName.text = SceneHistory.history.Peek().sceneNameForUI;

        if (DataInitialize.login)
        {
            CSVData.User user = SignManager.user_Data;        
            txt_AP.text = SignManager.user_Data.ap.ToString();
            txt_Credit.text = SignManager.user_Data.credit.ToString();
            txt_Cash.text = SignManager.user_Data.cash.ToString();
        }
    }

    public void Btn_LoadPrevScene()
    {
        DisableButtons();
        SceneHistory.LoadPrevScene();
    }
    public void Btn_LoadLobbyScene()
    {
        DisableButtons();
        SceneHistory.LoadLobbyScene();
    }
    public void InstantiateUI(GameObject prefab)
    {
        Instantiate(prefab);
    }

    void DisableButtons()
    {
        foreach (Button btn in transform.GetComponentsInChildren<Button>())
            btn.interactable = false;
    }    
}
