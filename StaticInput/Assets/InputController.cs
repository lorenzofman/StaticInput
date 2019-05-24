using System;
using System.Collections.Generic;
using UnityEngine;

public enum KeyInteraction {KeyUp, KeyDown, KeyStay}
public class InputController : Singleton<InputController>
{
    protected List<KeyInput> trackedKeys = new List<KeyInput>();

    public void RegisterTrackKey(KeyCode key, KeyInteraction interaction, Action callback)
    {
        KeyInput keyInput = trackedKeys.Find(x => x.keyCode == key && x.keyInteraction == interaction);
        if (keyInput == null)
        {
            trackedKeys.Add(new KeyInput(key, interaction, callback));
        }
        else
        {
            keyInput.callback += callback;
        }
    }

    public void DeregisterTrackKey(KeyCode key, KeyInteraction interaction, Action callback)
    {
        KeyInput keyInput = trackedKeys.Find(x => x.keyCode == key && x.keyInteraction == interaction);
        if (keyInput != null)
        {
            if (keyInput.callback.GetInvocationList().Length == 1)
            {
                trackedKeys.Remove(keyInput);
            }
            else
            {
                keyInput.callback -= callback;
            }
        }
    }

    private void Update()
    {
        foreach(KeyInput trackedKey in trackedKeys)
        {
            CheckKey(trackedKey);
        }
    }

    private void CheckKey(KeyInput key)
    {
        switch (key.keyInteraction)
        {
            case KeyInteraction.KeyUp:
                CheckKeyUp(key);
                break;
            case KeyInteraction.KeyDown:
                CheckKeyDown(key);
                break;
            case KeyInteraction.KeyStay:
                CheckKeyStay(key);
                break;
            default:
                break;
        }
    }

    private void CheckKeyDown(KeyInput key)
    {
        if(Input.GetKeyDown(key.keyCode))
        {
            key.callback();
        }
    }

    private void CheckKeyUp(KeyInput key)
    {
        if (Input.GetKeyUp(key.keyCode))
        {
            key.callback();
        }
    }

    private void CheckKeyStay(KeyInput key)
    {
        if (Input.GetKey(key.keyCode))
        {
            key.callback();
        }
    }


}
public class KeyInput
{
    public KeyCode keyCode;
    public KeyInteraction keyInteraction;
    public Action callback;
    public KeyInput(KeyCode keyCode, KeyInteraction keyInteraction, Action callback)
    {
        this.keyCode = keyCode;
        this.keyInteraction = keyInteraction;
        this.callback = callback;
    }
}
