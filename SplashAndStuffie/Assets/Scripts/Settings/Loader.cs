using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Loader : MonoBehaviour
{
     private readonly string _filePath;
    public Loader()
    {
        _filePath = Application.streamingAssetsPath + "/Save.json";
    }

    public SaveableEducation Load()
    {
       // string json = "";
       // using (var reader =new StreamReader(_filePath))
       // {
          //  string line;
            // while ((line = reader.ReadLine()) != null)
            // {
            //      json += line;
           //  }
          //   if (string.IsNullOrEmpty(json))
         //    {
     //            return new SaveableEducation();
       //      }
        //}
   //     return JsonUtility.FromJson<SaveableEducation>(json);
       return  JsonUtility.FromJson<SaveableEducation>(File.ReadAllText(Application.streamingAssetsPath + "/SaveableEducation.json")); 
    }
}
