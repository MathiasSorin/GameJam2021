using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switch : MonoBehaviour
{
    public float timeBeforeSwitchingScene;
    

    void Start()
    {
        Invoke("SceneSwitch", timeBeforeSwitchingScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SceneSwitch()
    {
        SceneManager.LoadScene("House_V2");

    }
}
