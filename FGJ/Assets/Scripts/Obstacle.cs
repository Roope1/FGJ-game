using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position += transform.rotation * new Vector3(0, 0, 1f);

        if (transform.position.z > 35f)
        {
            Destroy(gameObject);
        }
    }
}
