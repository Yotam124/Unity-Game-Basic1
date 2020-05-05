using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    Vector3 po;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            po.y = other.gameObject.transform.position.y;
            if (po.y > this.transform.position.y)
            {
                Vector3 movementVector = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
                transform.position = movementVector;
            }
            else
            {
                Vector3 movementVector = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
                transform.position = movementVector;
            }
           
            
        }
    }
}
