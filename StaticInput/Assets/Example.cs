using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        InputController.Instance.RegisterTrackKey(KeyCode.Space, KeyInteraction.KeyDown, Jump);
    }
    private void Jump()
    {
        Debug.Log("Jump");
    }
    
}
