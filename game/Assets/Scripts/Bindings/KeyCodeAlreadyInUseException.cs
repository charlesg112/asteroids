using System;
using UnityEngine;

public class KeyCodeAlreadyInUseException : Exception
{
    public KeyCodeAlreadyInUseException() : base() { }
    public KeyCodeAlreadyInUseException(KeyCode keyCode) : base($"'{keyCode}' is already in use") { }
}
