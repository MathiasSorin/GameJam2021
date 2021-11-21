using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch_to_Gameover : MonoBehaviour
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
            SceneManager.LoadScene("GameOver");

        }
    
}
