using System;
using UnityEngine;

[Serializable]
public class KeyBind
{
    public UserAction UserAction;
    public KeyCode KeyCode;
    public KeyBind(UserAction userAction, KeyCode keyCode)
    {
        UserAction = userAction;
        KeyCode = keyCode;
    }
    public override bool Equals(object obj)
    {
        KeyBind other = obj as KeyBind;
        if (other == null)
        {
            return false;
        }
        return other.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        int hashCode = -468833911;
        hashCode = hashCode * -1521134295 + UserAction.ToString().GetHashCode();
        hashCode = hashCode * -1521134295 + KeyCode.GetHashCode();
        return hashCode;
    }
}
