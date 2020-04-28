using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [Tooltip("The center of the circle")] [SerializeField] Transform rorationCenter;

    [Tooltip("Radius from the center")] [SerializeField] float rotationRadius = 2f;

    [Tooltip("Movment speed in meters per second")] [SerializeField] float speed = 1f;


    float posX = 0f;
    float posY = 0f;
    float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            posX = rorationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = rorationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector3(posX, posY, transform.position.z);
            angle += Time.deltaTime * speed;

            if (angle >= 360f)
            {
                angle = 0f;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            posX = rorationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = rorationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector3(posX, posY, transform.position.z);
            angle -= Time.deltaTime * speed;

            if (angle >= 360f)
            {
                angle = 0f;
            }
        }
    }
}
