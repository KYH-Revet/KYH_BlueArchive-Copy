using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter
{
    static string path_Resources = "G:/KYH/_Study//_GitHub/Unity/KYH_BlueArchive-Copy/Assets/Resources/";
    static string comma = ",";

    public static void Write(string path, List<string[]> data)
    {
        //Set Path for write
        StreamWriter st_Writer = new StreamWriter(path_Resources + path + ".csv", false);
        for(int line = 0; line < data.Count; line++)
        {
            string newLine = "";
            //Load datas
            for(int cur_Data = 0; cur_Data < data[line].Length; cur_Data++)
            {
                //Write data in current line
                newLine += data[line][cur_Data];

                //if cur_Data+1 is not end then pluse ","
                if (cur_Data + 1 < data[line].Length) newLine += comma;
            }
            //Write new line("\n")
            st_Writer.WriteLine(newLine);            
        }

        //Writer close
        st_Writer.Flush();
        st_Writer.Close();
    }
}
