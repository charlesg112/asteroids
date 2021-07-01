using System.Collections.Generic;
using UnityEngine;

public static class KeyBindsManager
{
    private static Dictionary<UserAction, KeyCode> KeyBinds;
    private static bool bindsAreLoaded = false;
    public static Dictionary<UserAction, KeyCode> GetKeyBinds()
    {
        if (!bindsAreLoaded) LoadKeyBinds();
        return KeyBinds;
    }
    private static void LoadKeyBinds()
    {
        KeyBinds = GetKeyBindDictionaryFromList(PersistentStateManager.GetPersistentState().KeyBinds);
        bindsAreLoaded = true;
    }
    public static Dictionary<UserAction, KeyCode> GetKeyBindDictionaryFromList(List<KeyBind> keyBinds)
    {
        Dictionary<UserAction, KeyCode> output = new Dictionary<UserAction, KeyCode>();
        foreach (KeyBind keyBind in keyBinds)
        {
            output.Add(keyBind.UserAction, keyBind.KeyCode);
        }
        return output;
    }
    public static List<KeyBind> GetKeyBindListFromDictionary(Dictionary<UserAction, KeyCode> keyBinds)
    {
        List<KeyBind> output = new List<KeyBind>();
        foreach (KeyValuePair< UserAction, KeyCode > keyBind in keyBinds)
        {
            output.Add(new KeyBind(keyBind.Key, keyBind.Value));
        }
        return output;
    }
    public static Dictionary<UserAction, KeyCode> GetDefaultKeyBinds()
    {
        Dictionary<UserAction, KeyCode> output = new Dictionary<UserAction, KeyCode>();
        output.Add(UserAction.BasicAttack, KeyCode.Mouse0);
        output.Add(UserAction.MoveUp, KeyCode.W);
        output.Add(UserAction.MoveLeft, KeyCode.A);
        output.Add(UserAction.MoveDown, KeyCode.S);
        output.Add(UserAction.MoveRight, KeyCode.D);
        return output;
    }
}
