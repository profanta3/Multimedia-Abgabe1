using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaSpielerVerhalten : MonoBehaviour
{
    private SpielerVerhalten _SpielerVerhalten;
    // Start is called before the first frame update
    void Start()
    {
        _SpielerVerhalten = GameObject.FindGameObjectWithTag("Player").GetComponent<SpielerVerhalten>();

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
            Debug.Log("forward button pressed");
            _SpielerVerhalten.zMove = 1;
        }
        if (vb.VirtualButtonName == "RightBtn")
        {
            Debug.Log("right button pressed");
            _SpielerVerhalten.xMove = 1;
        }
        if (vb.VirtualButtonName == "LeftBtn")
        {
            Debug.Log("left button pressed");
            _SpielerVerhalten.xMove = -1;
        }
        if (vb.VirtualButtonName == "BackBtn")
        {
            _SpielerVerhalten.zMove = -1;
            Debug.Log("back button pressed");
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released");
        
        _SpielerVerhalten.xMove = 0;
        _SpielerVerhalten.zMove = 0;
    }
}
