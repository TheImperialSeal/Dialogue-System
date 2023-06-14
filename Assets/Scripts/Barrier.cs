using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if getting errors on this section, make sure the variable in the Ink project is of the right type

        bool bearState = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("bearStatus")).value;

        if (bearState == true)
        {
            Destroy(gameObject);
        }
    }
}
