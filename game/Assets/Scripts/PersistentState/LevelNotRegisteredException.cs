using System;

public class LevelNotRegisteredException : Exception
{
    public LevelNotRegisteredException() { }

    public LevelNotRegisteredException(string context) : base($"Level Not Registered Exception : {context})") { }
}
