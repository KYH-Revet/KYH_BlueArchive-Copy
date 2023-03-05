using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip buttonClickSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //GameObject On/Off
    public static void UI_On(GameObject ui)
    {
        ui.SetActive(true);
    }
    public static void UI_Off(GameObject ui)
    {
        ui.SetActive(false);
    }

    //Button Functions
    public void Btn_LoadScene(string name)
    {
        SceneHistory.LoadScene(name);
    }
    public void Btn_PrevScene()
    {
        SceneHistory.LoadPrevScene();
    }
    public void Btn_LobbyScene()
    {
        SceneHistory.LoadLobbyScene();
    }
    public void Btn_LoadSceneWithLoadingScene(string name)
    {
        SceneHistory.LoadSceneWithLoadingScene(name);
    }

    //Text Functions
    public static void UpdateText(Text target, string value)    //Text Update
    {
        target.text = value;
    }
    public static void UpdateText(Text target, int value)       //Text Update with comma
    {
        //Integer to string(Reverse)
        List<int> nums = new List<int>();
        if (value == 0)
        {
            nums.Add(0);
        }
        else
        {
            while (value > 0)
            {
                nums.Add(value % 10);
                value /= 10;
            }
        }

        //Return value
        string str = "";

        //Insert comma ','
        for (int i = 1; i <= nums.Count; i++)
        {
            //Index from back (nums.Count-1 ~ 0)
            int cur_Idx = nums.Count - i;
            
            //Add number
            str += nums[cur_Idx].ToString();

            //Comma
            if (i != nums.Count && (cur_Idx) % 3 == 0)
                str += ",";
        }

        target.text = str;
    }

    //Audio
    public void PlayAudioOnButtonClickSound()
    {
        audioSource.clip = buttonClickSound;
        audioSource.Play();
    }
}
