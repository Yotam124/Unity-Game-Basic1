using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerHitWall : MonoBehaviour
{
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Destroy(other.gameObject);
        }
    }
}