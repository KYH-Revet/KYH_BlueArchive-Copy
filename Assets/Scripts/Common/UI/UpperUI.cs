using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperUI : MonoBehaviour
{
    public Text text_AP;
    public Text text_Credit;
    public Text text_Cash;

    public static string sceneName = "";

    private void Awake()
    {
        if (DataInitialize.login)
        {
            CSVData.User user = SignManager.user_Data;
            UIFunctions.UpdateText(text_AP,     user.ap.ToString());
            UIFunctions.UpdateText(text_Credit, user.credit.ToString());
            UIFunctions.UpdateText(text_Cash,   user.cash.ToString());
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
