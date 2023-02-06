using Newtonsoft.Json;
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

    void Awake()
    {
        //Account
        CSVData.User cur_User = SignManager.user_Data;

        //Account
        UpdateText(text_Lv, cur_User.accountLv.ToString());
        UpdateText(text_Nickname, cur_User.nickname.ToString());
        UpdateText(text_Exp, cur_User.accountExp.ToString() + "/" + CalcMaxExp());

        //Money
        UpdateText(text_AP, cur_User.ap + "/" + CalcMaxAP());
        UpdateText(text_Credit, cur_User.credit);
        UpdateText(text_Cash, cur_User.cash);
    }

    //Class Functions
    public void UpdateText(Text target, string value)       //Text Update
    {
        target.text = value;
    }
    public void UpdateText(Text target, int value)       //Text Update with comma
    {
        List<int> nums = new List<int>();
        while(value > 0)
        {
            nums.Add(value % 10);
            value /= 10;
        }
        string str = "";
        
        //Insert comma ','
        for(int i = 1; i <= nums.Count ; i++)
        {
            //Index from back
            str += nums[nums.Count - i].ToString();

            //Comma
            if(i % 3 == 0)
                str += ",";
        }
    }
    public void UpdateSlider(Slider target, float value)    //Slider Update
    {
        target.value = value;
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
