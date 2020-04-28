using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    [Tooltip("Speed of decrease and increase")] 
        [SerializeField] float speed = 2f;

    [Tooltip("Minimum size of the ball")]
        [SerializeField] float minBallScale = 2f;

    [Tooltip("Maximum size of the ball")]
        [SerializeField] float maxBallScale = 4f;

    float duration = 5f;
    public bool repeatable;

    Vector3 minScale;
    Vector3 maxScale;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        minScale = transform.localScale;
        while (repeatable)
        {
            minScale = new Vector3(minBallScale, minBallScale, minBallScale);
            maxScale = new Vector3(maxBallScale, maxBallScale, maxBallScale);
            yield return RepeatLerp(minScale, maxScale, duration);
            yield return RepeatLerp(maxScale, minScale, duration);
        }
    }

    IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
