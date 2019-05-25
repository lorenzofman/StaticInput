using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUsingInputController : MonoBehaviour
{
    KeyCode key;
    // Start is called before the first frame update
    void Start()
    {
        key = (KeyCode)Random.Range(0, (int)KeyCode.Joystick8Button9);
        InputController.Instance.RegisterTrackKey(key, KeyInteraction.KeyDown, Jump);
    }
    private void Jump()
    {
        Debug.Log("Jump");
    }
}
