using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Quaternion newRotation;
    // Start is called before the first frame update
    void Start()
    {
        newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            newRotation.y = -90;
            transform.rotation = newRotation;
        }       
    }
}
