using _Character;
using CSVData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour
{
    public Text text_CLv;

    public Image img_Profile;
    public Image img_RoleIcon;

    public Image img_AttProperty;

    public void SetCharacter(int lv, Sprite profile, Type_Property type)
    {
        try
        {
            //Profile image
            img_Profile.sprite = profile;

            //Proerty color
            Debug.Log("Attack Property = " + type.ToString());
            switch (type)
            {
                case Type_Property.Explosion:
                    //폭발
                    Debug.Log("폭발");
                    img_AttProperty.color = Color.red;
                    break;
                case Type_Property.Penetrate:
                    //관통
                    Debug.Log("관통");
                    img_AttProperty.color = Color.yellow;
                    break;
                case Type_Property.Mystery:
                    //신비
                    Debug.Log("신비");
                    img_AttProperty.color = Color.cyan;
                    break;
            }

            //Role icon

            //Character level text
            string txt_lv = "Lv." + lv.ToString();
            text_CLv.text = txt_lv;
        }
        catch(NullReferenceException)
        {
            
        }
    }
}
