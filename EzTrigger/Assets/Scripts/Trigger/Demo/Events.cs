using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    private void Start()
    {
    }
    public void OnEnter()
    {
        Debug.Log("Object Entered");
    }
    public void OnExit()
    {
        Debug.Log("Object Exited");

    }
    public void OnStay()
    {
        Debug.Log("Object Inside");
    
    }
}
