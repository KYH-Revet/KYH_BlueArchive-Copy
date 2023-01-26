using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SignUp : MonoBehaviour
{
    public Text debug_Text;

    [Header("Step")]
    [SerializeField] GameObject panel_Step1;
    [SerializeField] GameObject panel_Step2;

    [Header("SignUp Input Field")]
    [SerializeField] InputField text_id;
    [SerializeField] InputField text_password;
    [SerializeField] InputField text_nickname;

    string id, password, nickname;

    //Button Functions
    public void Btn_ReturnLogin()
    {
        OffPanel();
    }
    public void Btn_NextStep()
    {
        //Set String
        SetId(text_id.text);
        SetPassword(text_password.text);

        //id overlap check
        if (!User.IDOverlapCheck(id))
        { 
            debug_Text.text = "중복된 ID 입니다.";
            return; 
        }

        //Reset debug text
        debug_Text.text = "";

        //Next step (1 >> 2)
        panel_Step1.SetActive(false);
        panel_Step2.SetActive(true);
    }

    public void Btn_PreviousStep()
    {
        //Reset String
        SetId("");
        SetPassword("");
        SetNickName("");
        debug_Text.text = "";

        //Previous step (2 >> 1)
        panel_Step1.SetActive(true);
        panel_Step2.SetActive(false);
    }

    public void Btn_SignUp()
    {
        //Set Nickname
        SetNickName(text_nickname.text);

        //Sign up
        if (!SignManager.SignUp(id, password, nickname))
            debug_Text.text = "회원가입에 실패했습니다. 다시 시도해주세요.";

        OffPanel();
    }

    //Class Functions    
    void SetId(string s)
    {
        text_id.text = s;
        id = s;
    }
    void SetPassword(string s)
    {
        text_password.text = s;
        password = s;
    }
    void SetNickName(string s)
    {
        text_nickname.text = s;
        nickname = s;
    }
    void OffPanel()
    {
        SetId("");
        SetPassword("");
        SetNickName("");
        gameObject.SetActive(false);
    }
}
