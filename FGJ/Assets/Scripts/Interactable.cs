using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.tag = "Interactable";
    }

    virtual public void Interact()
    {
        Debug.LogError("Interact not overwritten");
    }

}
