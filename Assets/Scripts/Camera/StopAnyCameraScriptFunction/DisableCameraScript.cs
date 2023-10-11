using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCameraScript : MonoBehaviour
{
    [SerializeField] DisableSmoothFunction disableSmoothFunctionScript;
    public bool isStop;
    // Update is called once per frame
    void Update()
    {
        if(isStop)
        {
            disableSmoothFunctionScript.DisableOtherCameraScriptFunction();
        }
        else
        {
            disableSmoothFunctionScript.EnableOtherCameraScriptFunction();
        }
    }
}
