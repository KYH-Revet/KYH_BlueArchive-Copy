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
            //�ߺ��˻�
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i]["ID"].ToString() == id)
                {
                    Debug.LogError("�ߺ��� ID �Դϴ�.");
                    return false;
                }
                if (data[i]["NICKNAME"].ToString() == nickname)
                {
                    Debug.LogError("�ߺ��� �г��� �Դϴ�.");
                    return false;
                }

                //Increase the max user index
                maxUId = ((int)data[i]["UID"] > maxUId) ? (int)data[i]["UID"] : maxUId;
            }
        }

        //ȸ�� ����
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
                    Debug.Log("�α��� ���� UID ���� : " + data[i]["UID"].ToString());
                    user.SetUID((int)data[i]["UID"]);
                    return user.Read_User();
                }
            }
        }

        Debug.Log("��ϵ��� ���� ID �Դϴ�.");
        return false;
    }
}
