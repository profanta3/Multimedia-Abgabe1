using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaSpielerVerhalten : MonoBehaviour
{
    private SpielerController _SpielerController;
    // Start is called before the first frame update
    void Start()
    {
        _SpielerController = GameObject.FindGameObjectWithTag("Player").GetComponent<SpielerController>();

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbs[i].RegisterOnButtonReleased(OnButtonReleased);
        }

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "ForwardBtn")
        {
            _SpielerController.Move(Vector3.forward);
        }
        else if (vb.VirtualButtonName == "RightBtn")
        {
            _SpielerController.Move(Vector3.right);
        }
        else if (vb.VirtualButtonName == "LeftBtn")
        {
            _SpielerController.Move(Vector3.left);
        }
        else if (vb.VirtualButtonName == "BackBtn")
        {
            _SpielerController.Move(Vector3.back);
        }
        //Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released");
        _SpielerController.Move(Vector3.zero);
    }

    
}
