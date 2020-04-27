using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Tooltip("Movement speed in meters per second")] [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Transform t = GetComponent<Transform>();
        t.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
