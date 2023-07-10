using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CSVData;
using System;
using _Character;

public class CharacterBoxContainer : MonoBehaviour
{
    public GameObject box;
    public List<GameObject> boxs = new List<GameObject>();

    void Awake()
    {
        Dictionary_CharacterInfo dic_ChaInfo = Dictionary_CharacterInfo.Instance();
        
        for (int i = 0; i < dic_ChaInfo.dictionary_size; i++)
        {
            CSVData.User_Character cur_Character = SignManager.user_Characters[i];
            if (cur_Character.possesion)
            {
                //Name
                string cha_name = dic_ChaInfo.dictionary_CharacterInfo[i].name;

                //Level
                int lv = cur_Character.cLv;

                //Sprites
                string path             = User_Character.path_SpriteFolder + cur_Character.cId + "\\" + cha_name + " ";
                Sprite sprite_Profile   = Resources.Load<Sprite>(path + "(profile)");
                Sprite sprite_Full      = Resources.Load<Sprite>(path + "(full)");

                //Property type
                Type_Property type = dic_ChaInfo.dictionary_CharacterInfo[i].tProperty_Att;
                Debug.Log("데이터 로딩 성공, 캐릭터 박스 생성 시작");

                //Instantiate Box
                CreateNewBox(cha_name, lv, sprite_Profile, sprite_Full, type);
            }
        }
    }

    void CreateNewBox(string name, int lv, Sprite profile, Sprite full, Type_Property type)
    {
        //Create Box
        GameObject newBox = Instantiate(box);
        CharacterBox cBox = newBox.GetComponent<CharacterBox>();

        //Set Detail
        cBox.SetCharacter(lv, profile, type);

        //Add to list
        newBox.transform.parent = transform;
        boxs.Add(newBox);

        //Debug
        Debug.Log("\"" + name + "\" Character Box 생성");
    }
}
