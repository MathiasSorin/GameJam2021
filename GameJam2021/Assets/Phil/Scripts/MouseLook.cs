using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform playerBody;

    public float mouseSensitivity = 20f;

    float xRotation = 0f;
    public float range = 300f;
   
    
    void Start()
    {
        //playerBody.rotation = playerBody.rotation;
        Cursor.lockState = CursorLockMode.Locked;

        
    }

    
    void Update()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            var x = hit.transform.gameObject.GetComponent<IPickupable>();
            
            if( x != null)
            {
                x.DetectPickup(gameObject);
            }


        }
       

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        Debug.DrawRay(transform.position, transform.forward * range, Color.red);
    }

    
}
