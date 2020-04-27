using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public Rigidbody2D body2d;
    [Tooltip("The range of the left angle where the arm get pushed")] 
        [SerializeField] float leftPushRange = -0.3f;
    [Tooltip("The range of the right angle where the arm get pushed")] 
        [SerializeField] float rightPushRange = 0.3f;
    [Tooltip("This is the speed limit and the arm speed. The arm is pushed to this speed when it is below the velocityThreshold")]
        [SerializeField] float velocityThreshold = 120f;

    // Start is called before the first frame update
    void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z > 0
             && transform.rotation.z < rightPushRange
             && (body2d.angularVelocity > 0)
             && body2d.angularVelocity < velocityThreshold)
        {
            body2d.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0
            && transform.rotation.z > leftPushRange
            && (body2d.angularVelocity < 0)
            && body2d.angularVelocity > velocityThreshold * -1)
        {
            body2d.angularVelocity = velocityThreshold * -1;
        }
    }
}
