using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class FileCheck : MonoBehaviour
{
    public Animator transition;
    [SerializeField]
    private float _transitionTime = 1f;
    private string _levelName;
    // Start is called before the first frame update
    void Start()
    {   
        string path = Application.persistentDataPath + "/player.save";
        if(File.Exists(path))
            _levelName = "Bedroom";
        else
            _levelName = "Selection";

        StartCoroutine(LoadLevel(_levelName));      
    }
    IEnumerator LoadLevel(string levelName){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
