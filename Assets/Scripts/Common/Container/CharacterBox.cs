using _Character;
using CSVData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour
{
    public Image img_Profile;
    public Image img_AttProperty;
    public Image img_RoleIcon;
    public Text text_CLv;
    
    public void SetCharacter(Character_Profile info)
    {
        try
        {
            //Profile image
            img_Profile.sprite = info.sprite_Profile;

            //Proerty color
            switch (info.info.tProperty_Att)
            {
                case Type_Property.Explosion:
                    //폭발
                    img_AttProperty.color = Color.red;
                    break;
                case Type_Property.Penetrate:
                    //관통
                    img_AttProperty.color = Color.yellow;
                    break;
                case Type_Property.Mystery:
                    //신비
                    img_AttProperty.color = Color.cyan;
                    break;
            }

            //Role icon

            //Character level text
            string lv = "Lv." + info.level.ToString();
        }
        catch(NullReferenceException)
        {
            
        }
    }
}
