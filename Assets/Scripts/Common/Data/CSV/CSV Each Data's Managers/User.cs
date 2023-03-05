using System.Collections.Generic;
using UnityEngine;

public class User
{
    //File path
    static string path = "CSV/User";
    public static string _path { get { return path; } }
    //CSV File Keys
    static string[] keys = { "ID", "PASSWORD", "UID", "NICKNAME", "ACCOUNTLV", "ACCOUNTEXP", "AP", "CREDIT", "CASH" };
    
    //CSV Functions
    /// <summary>
    /// Read User csv data with UID (if UID is -1, it mean that reading data fails)
    /// </summary>
    /// <param name="uId"></param>
    /// <returns></returns>
    public static CSVData.User Read_User(int uId)
    {
        //Variables for read user data
        CSVData.User uData = new CSVData.User();
        uData.uId = -1;

        //Read csv file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null) return uData;

        //Search user with user id
        int user_Idx = uData.uId;
        for (int i = 0; i < data.Count; i++)
            if ((int)data[i]["UID"] == uId)
                user_Idx = i;

        //Not found user
        if (user_Idx == -1) return uData;

        //Input data
        //uData.id        =       data[user_Idx][keys[0]].ToString();   //Security
        //uData.password  =       data[user_Idx][keys[1]].ToString();   //Security
        uData.uId       = (int) data[user_Idx][keys[2]];
        uData.nickname  =       data[user_Idx][keys[3]].ToString();
        uData.accountLv = (int) data[user_Idx][keys[4]];
        uData.accountExp= (int) data[user_Idx][keys[5]];
        uData.ap        = (int) data[user_Idx][keys[6]];
        uData.credit    = (int) data[user_Idx][keys[7]];
        uData.cash      = (int) data[user_Idx][keys[8]];
        return uData;
    }
    /// <summary>
    /// It overlap return false, It not overlap return true
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool IDOverlapCheck(string id)
    {
        Debug.Log("OverlapCheck] " + id);
        //Read csv file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if(data == null) { Debug.LogError("data is null!"); return false; }

        for(int line = 0; line < data.Count; line++)
        {
            Debug.Log(data[line]["ID"].ToString() + " ?= " + id);
            if (data[line]["ID"].ToString() == id)
                return false;
        }
        return true;
    }
    public static bool Write_Add_User(CSVData.User newUser)
    {
        //Read file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null) return false;

        //Set Keys
        List<string[]> allData = new List<string[]>() { keys };
        
        //Set Values
        for(int idx_Data = 0; idx_Data <= data.Count; idx_Data++)
        {
            if (idx_Data >= data.Count)
            {
                //New Data
                allData.Add(StringArr_User(newUser));
                break;
            }

            //Old data
            string[] newData = new string[keys.Length];   //Id, Password, UId, Nickname, AccountLv, AccountExp
            for(int idx_Keys = 0; idx_Keys < keys.Length; idx_Keys++)
                newData[idx_Keys] = data[idx_Data][keys[idx_Keys]].ToString();

            //Add string[] data
            allData.Add(newData);
        }

        //Create User_Character csv file
        if (!User_Character.Write_Add_User_Character(newUser.uId))
            return false;

        //Create User csv data
        CSVWriter.Write(path, allData);
        Debug.Log("새로운 유저 추가 성공");
        return true;
    }
    public static bool Write_Modify_User(CSVData.User modified_Data)
    {
        //Read file
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null) { Debug.LogError("Write_Modify_User(), data is null"); return false; };

        //Set Keys
        List<string[]> allData = new List<string[]>() { keys };

        //Set Values
        for (int line = 0; line < data.Count; line++)
        {
            string[] newData = new string[keys.Length];   //Id, Password, UId, Nickname, AccountLv, AccountExp

            if ((int)data[line]["UID"] == modified_Data.uId)   //Modify target
            {
                newData = StringArr_User(modified_Data);
            }
            else                                        //Old data
            {
                for (int idx_Keys = 0; idx_Keys < keys.Length; idx_Keys++)
                    newData[idx_Keys] = data[line][keys[idx_Keys]].ToString();
            }

            //Add string[] data
            allData.Add(newData);
        }

        //Modify csv file
        CSVWriter.Write(path, allData);
        return true;
    }

    //Class Sub Functions
    static string[] StringArr_User(CSVData.User newUser)
    {
        string[] newData = new string[keys.Length];

        newData[0] = newUser.id;                    //Id
        newData[1] = newUser.password;              //Password
        newData[2] = newUser.uId.ToString();        //UId
        newData[3] = newUser.nickname;              //Nickname
        newData[4] = newUser.accountLv.ToString();  //AccountLv
        newData[5] = newUser.accountExp.ToString(); //AccountExp
        newData[6] = newUser.accountExp.ToString(); //AP
        newData[7] = newUser.accountExp.ToString(); //Credit
        newData[8] = newUser.accountExp.ToString(); //Cash

        return newData;
    }
    
    //Debug Functions
    public static void Debug_User(CSVData.User uData)
    {
        Debug.Log("User]");
        Debug.Log("uId : "+ uData.uId + "\tNickname : " + uData.nickname +
            "\tAccountLv : " + uData.accountLv + "\tAccountExp : " + uData.accountExp +
            "\tAP : " + uData.ap + "\tCredit : " + uData.credit + "\tCash : " + uData.cash);
    }
    public static void Debug_User(int uId)
    {
        Debug_User(Read_User(uId));
    }

    //Add new key and default value in CSV file
    public static void NewKey()
    {
        //New Data
        int newDataNum = 0;
        string[] newValue = new string[newDataNum];

        //User.csv
        List<Dictionary<string, object>> data = CSVReader.Read(path);
        if (data == null || data.Count <= 0) { /*Debug.Log("데이터 없음");*/ return; }

        //Rewrite CSV File
        List<string[]> update = new List<string[]>() { keys };
        for (int line = 0; line < data.Count; line++)
        {
            string[] values = new string[keys.Length];
            int originalSize = keys.Length - newValue.Length;
            //Original Data
            for (int keyIdx = 0; keyIdx < originalSize; keyIdx++)
                values[keyIdx] = data[line][keys[keyIdx]].ToString();

            //New data
            for (int newIdx = 0; newIdx < newValue.Length; newIdx++)
                values[originalSize + newIdx] = newValue[newIdx];

            update.Add(values);
        }

        //Write csv
        CSVWriter.Write(path, update);
    }

}
