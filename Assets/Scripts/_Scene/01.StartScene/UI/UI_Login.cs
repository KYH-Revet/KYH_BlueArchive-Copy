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
            debug_Text.text = "��ϵ��� �ʴ� ID Ȥ�� Ʋ�� ��й�ȣ�Դϴ�.";
        else
        {
            debug_Text.text = "�α���";
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
