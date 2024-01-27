using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    private Rigidbody _sealRig;
    // Start is called before the first frame update
    void Start()
    {
        _sealRig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Move(Input.GetAxis("Horizontal"));
        }
    }

    private void Move(float input)
    {
        //_sealRig.AddForce(Vector3.left * input * _moveForce, ForceMode.Force);
        gameObject.transform.position += new Vector3(-input * _moveSpeed, 0, 0);
    }

}
