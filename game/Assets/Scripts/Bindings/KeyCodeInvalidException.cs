using System;
using UnityEngine;

public class KeyCodeInvalidException : Exception
{
    public KeyCodeInvalidException() : base() { }
    public KeyCodeInvalidException(KeyCode keyCode) : base($"'{keyCode}' is not a valid key") { }
}
