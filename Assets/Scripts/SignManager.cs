using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SignManager : MonoBehaviour
{
    public bool SignUp(string id, string password, string nickname)
    {
        User user = User.Instance();
        List<Dictionary<string, object>> data = CSVReader.Read(user._path);
        int maxUId = 0;

        //Exception Handling & Increase the max user index
        if (data == null) return false;
        if (data.Count > 0)
        {
            //중복검사
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i]["ID"].ToString() == id)
                {
                    Debug.LogError("중복된 ID 입니다.");
                    return false;
                }
                if (data[i]["NICKNAME"].ToString() == nickname)
                {
                    Debug.LogError("중복된 닉네임 입니다.");
                    return false;
                }

                //Increase the max user index
                maxUId = ((int)data[i]["UID"] > maxUId) ? (int)data[i]["UID"] : maxUId;
            }
        }

        //회원 가입
        CSVData.User newUser = new CSVData.User(id, password, maxUId + 1, nickname);

        //Write
        user.Write_Add_User(data, newUser);

        return true;
    }
    public bool SignIn(string id, string password)
    { 
        User user = User.Instance();
        List<Dictionary<string, object>> data = CSVReader.Read(user._path);
        if (data == null) return false;

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["ID"].ToString() == id)
            {
                if (data[i]["PASSWORD"].ToString() == password)
                {
                    Debug.Log("로그인 성공 UID 배정 : " + data[i]["UID"].ToString());
                    user.SetUID((int)data[i]["UID"]);
                    return user.Read_User();
                }
            }
        }

        Debug.Log("등록되지 않은 ID 입니다.");
        return false;
    }
}
