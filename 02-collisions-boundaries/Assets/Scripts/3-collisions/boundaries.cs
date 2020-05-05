using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour{

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate() {
        Vector3 po = transform.position;
        po.x = Mathf.Clamp(po.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        if (po.y < -6)
        {
            po.y = 6.586f;
            transform.position = po;
        }
        if (po.y > 6.59)
        {
            po.y = -6f;
            transform.position = po;
        }
        //po.y = Mathf.Clamp(po.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = po;
    }
}
