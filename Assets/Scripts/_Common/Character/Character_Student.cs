using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Character;
using CSVData;

public class Character_Student : Character
{
    CSVData.User_Character user_Cha;
    public CSVData.User_Character user_Character { get { return user_Cha; } }   //cId, cLv, cExp
    Character_Info cha_Info;
    public Character_Info character_Info { get { return cha_Info; } }

    Character_Stat cha_Stat;
    public Character_Stat character_Stat { get { return cha_Stat; } }

    void Start()
    {
        
    }


    void Set_User_Character()
    {

    }
    void Set_Character_Info()
    {

    }
}
