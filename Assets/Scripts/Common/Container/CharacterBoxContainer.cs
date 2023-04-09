using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CSVData;
using System;

public class CharacterBoxContainer : MonoBehaviour
{
    public GameObject box;
    public List<GameObject> boxs = new List<GameObject>();

    void Awake()
    {
        try
        {
            Dictionary_CharacterInfo dic_ChaInfo = Dictionary_CharacterInfo.Instance();
                        
            for (int i = 0; i < dic_ChaInfo.dictionary_size; i++)
            {
                CSVData.User_Character cur_Character = SignManager.user_Characters[i];

                string cha_name = dic_ChaInfo.dictionary_CharacterInfo[i].name;
                string path = User_Character.path_SpriteFolder + cha_name + "\\" + cha_name + " ";
                Sprite sprite_Profile = (Sprite)Resources.Load(path + "(profile)");
                Sprite sprite_Full = (Sprite)Resources.Load(path + "(full)");
                
                Character_Profile newProfile = new Character_Profile();
                
                CreateNewBox(newProfile);
            }
        }
        catch(NullReferenceException)
        {
            Debug.Log("Dictionary is NUll");
        }
    }

    void CreateNewBox(Character_Profile newProfile)
    {
        GameObject newBox = Instantiate(box);
        newBox.GetComponent<CharacterBox>().SetCharacter(newProfile);
        newBox.transform.parent = transform;
        boxs.Add(newBox);
    }
}
