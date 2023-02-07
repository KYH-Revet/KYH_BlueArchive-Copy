using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountInfoScene : MonoBehaviour
{
    [Header("Account")]
    public Text text_Nickname;
    public Text text_Lv;
    public Text text_UID;

    [Header("Progress")]
    public Text text_StudentCount;

    [Header("Rank")]
    public Text text_HighRank;
    public Text text_CurRank;

    [Header("PopUp UI")]
    public GameObject ui_ModifyNickname;

    //Unity Functions
    void Awake()
    {
        CSVData.User user = SignManager.user_Data;

        //Account
        UIFunctions.UpdateText(text_Nickname,   user.nickname);
        UIFunctions.UpdateText(text_Lv,         user.accountLv);
        UIFunctions.UpdateText(text_UID,        user.uId);
        
        //Progress
        UIFunctions.UpdateText(text_StudentCount, PossessionStudentCount().ToString());

        //Rank
        UIFunctions.UpdateText(text_Nickname,   user.nickname);
        UIFunctions.UpdateText(text_Nickname,   user.nickname);
    }

    //Class Fucntions
    int PossessionStudentCount()
    {
        int amount = 0;
        User_Character.Debug_User_Character(SignManager.user_Data);
        Dictionary<int, CSVData.User_Character> user_cha = SignManager.user_Characters;
        for (int cid = 0; cid < Dictionary_CharacterInfo.Instance().dictionary_size; cid++)
        {
            if (!user_cha.ContainsKey(cid))
                continue;

            if (user_cha[cid].possesion)
                    amount++;
        }
        return amount;
    }

    //Button Functions
    public void Btn_ModifyNickName()
    {
        SignManager.Modyfy_Nickname(text_Nickname.text);
    }
}
