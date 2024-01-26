using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingleDance : Interactable
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Interact()
    {
        Debug.Log("Interacted with Dingle");
        _anim.SetBool("Dance", !_anim.GetBool("Dance"));

    }

}
