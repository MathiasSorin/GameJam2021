using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Man_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Scr_ToiletTrigger toilet;
    public Scr_WindowTrigger window;

    public Scr_FireplaceTrigger fireplace;

    public Scr_BedTrigger bed;
    public Scr_GarageTrigger garage;
    public Scr_Drawer drawer;
    public Scr_DoorTrigger door;



    private void Update()
    {
        if (toilet.IsClogged && window.IsBarricaded && garage.AlarmOn == false && fireplace.OnFire && bed.ZombiesUnderBed == false && door.IsBlocked)
        {
            SceneManager.LoadScene("Win");
        }

    }
}
