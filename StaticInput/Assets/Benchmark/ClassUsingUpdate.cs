using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUsingUpdate : MonoBehaviour
{
    KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        key = (KeyCode)Random.Range(0, (int)KeyCode.Joystick8Button9);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            Debug.Log("Jump");
        }
    }
}
