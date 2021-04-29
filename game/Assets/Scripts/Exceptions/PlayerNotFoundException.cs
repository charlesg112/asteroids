using System;

public class PlayerNotFoundException : Exception
{
    public PlayerNotFoundException(string from) : base($"Player not found. Method called : {from}")
    {
    }
}
