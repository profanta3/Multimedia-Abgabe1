using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Transform target;
    public float cameraDistance = 5f;
    public float cameraHight = 2f;
    public float motionSpeed = 0.5f;

    float timeCount = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0f, 0f,-1 * cameraDistance);
        
        //Kamera entfernung zum target
        transform.position = target.position + target.rotation * offset;
        
        //Kamera Höhe
        transform.position = new Vector3(transform.position.x, transform.position.y + cameraHight, transform.position.z);

        //Motion smoothing der camera rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position, Vector3.up), timeCount);
        timeCount += Time.deltaTime * motionSpeed;
    }
}
