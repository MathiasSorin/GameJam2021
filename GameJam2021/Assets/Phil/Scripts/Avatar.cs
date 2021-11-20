using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    public GameObject objectPosition;
    //Transform objectPos;
    // Start is called before the first frame update
    void Start()
    {
         Transform objectPos = objectPosition.GetComponent<Transform>();
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
