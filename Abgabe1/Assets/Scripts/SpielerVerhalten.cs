using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpielerVerhalten : MonoBehaviour
{
    //Movement
    public float movementSpeed = 8f;
    public float drehGeschwindigkeit = 10f;
    public Transform cameraPosition;

    public float xMove;
    public float zMove;

    //UI
    public Text text;
    private int score = 0;

    
    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");

        float winkel = xMove * drehGeschwindigkeit * Time.deltaTime;
        Vector3 targetDirection = new Vector3(Mathf.Sin(winkel), 0f, Mathf.Cos(winkel));
        
        transform.rotation = Quaternion.LookRotation(targetDirection) * transform.rotation;

        transform.position += transform.forward * zMove * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            score++;
            //Debug.Log("Score: " + score);
            text.text = Convert.ToString(score);
        }
    }
}
