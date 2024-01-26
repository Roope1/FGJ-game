using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _interactionDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
            GameObject target = hit.collider.gameObject;
            if (target.CompareTag("Interactable"))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    target.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
