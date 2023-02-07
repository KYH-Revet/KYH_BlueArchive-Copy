using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
    public Text debug_Text;

    [Header("Login Input Field")]
    [SerializeField] InputField text_id;
    [SerializeField] InputField text_password;

    [Header("")]
    [SerializeField] Text text_UId;

    public void Btn_Login()
    {
        if (!SignManager.Login(text_id.text, text_password.text))
            debug_Text.text = "등록되지 않는 ID 혹은 틀린 비밀번호입니다.";
        else
        {
            debug_Text.text = "로그인";
            text_UId.text = "UID : " + SignManager.user_Data.uId.ToString();
            gameObject.SetActive(false);
        }
    }
    public void Btn_SignUp(GameObject ui)
    {
        text_id.text = "";
        text_password.text = "";
        debug_Text.text = "";
        ui.SetActive(true);
    }
}
