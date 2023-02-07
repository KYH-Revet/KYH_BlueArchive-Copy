using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour
{
    [Header("UpperLine - Account")]
    public Text text_Lv;
    public Text text_Nickname;
    public Text text_Exp;
    public Slider slider_ExpSlider;

    [Header("UpperLine - Money")]
    public Text text_AP;
    public Text text_Credit;
    public Text text_Cash;

    [Header("UnderLine - Text")]
    public Text text_Time;

    //Unity Functions
    void Awake()
    {
        //Account
        CSVData.User cur_User = SignManager.user_Data;

        //Account
        UIFunctions.UpdateText(text_Lv, cur_User.accountLv.ToString());
        UIFunctions.UpdateText(text_Nickname, cur_User.nickname.ToString());
        UIFunctions.UpdateText(text_Exp, cur_User.accountExp.ToString() + "/" + CalcMaxExp());

        //Money
        UIFunctions.UpdateText(text_AP, cur_User.ap + "/" + CalcMaxAP());
        UIFunctions.UpdateText(text_Credit, cur_User.credit);
        UIFunctions.UpdateText(text_Cash, cur_User.cash);
    }

    void Update()
    {
        UpdateTime();
    }

    //Class Functions
    public void UpdateSlider(Slider target, float value)    //Slider Update
    {
        target.value = value;
    }
    public void UpdateTime()
    {
        text_Time.text = DateTime.Now.ToString("tt hh : mm");
    }
    public string CalcMaxExp()
    {
        //Max exp : Basic(1000) + Increase(100) * Lv
        string maxExp = (1000 + 100 * SignManager.user_Data.accountLv).ToString();
        return maxExp;
    }
    public string CalcMaxAP()
    {
        //Max ap : 1Lv = 62, 80Lv = 220
        string maxAp = (60 + 2 * SignManager.user_Data.accountLv).ToString();
        return maxAp;
    }    
}
