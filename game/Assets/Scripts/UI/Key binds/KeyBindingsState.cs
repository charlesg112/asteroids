using System.Collections.Generic;
using UnityEngine;

public class KeyBindingsState
{
    public UserAction? HighlightedUserAction;
    public Dictionary<UserAction, KeyCode> CurrentKeyBinds;

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        int hashCode = -21890130;
        hashCode = hashCode * -1521134295 + HighlightedUserAction.GetHashCode();
        foreach (KeyValuePair<UserAction, KeyCode> keyValuePair in CurrentKeyBinds)
        {
            hashCode = 31 * hashCode + keyValuePair.Key.GetHashCode();
        }
        return hashCode;
    }
}
