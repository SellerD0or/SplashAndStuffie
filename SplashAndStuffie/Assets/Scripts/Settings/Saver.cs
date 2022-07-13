using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Saver : MonoBehaviour
{
  //  private  SaveableEducation _saveableEducation;
    private readonly string _filePath;
    public Saver()
    {
        _filePath = Application.streamingAssetsPath + "/Save.json";
    }
    public  void FinishEducation(SaveableEducation data)
    {
        //_saveableEducation.IsEducationEnd = true;
        Save(data);
    } 
    public  void StartEducation(SaveableEducation data)
    {
       // _saveableEducation.IsEducationEnd = false;
        Save(data);
    }
      public  void Save(SaveableEducation data)
    {
     //   var json = JsonUtility.ToJson(data);
       // using (var writter = new StreamWriter(_filePath))
       // {
      //       writter.WriteLine(json);
       // }
      File.WriteAllText(Application.streamingAssetsPath + "/SaveableEducation.json", JsonUtility.ToJson(data));
    }
}
