using System;
using System.Collections.Generic;
using UnityEngine;

public static class KeyBindsManager
{
    private static Dictionary<UserAction, KeyCode> KeyBinds;
    public static bool BindsAreLoaded { get; private set; } = false;
    public static KeyCode GetAssociatedKey(UserAction action)
    {
        return GetKeyBinds()[action];
    }
    public static void SetKeyBinds(Dictionary<UserAction, KeyCode> keyBinds)
    {
        KeyBinds = keyBinds;
        BindsAreLoaded = true;
    }
    public static void SetKeyBind(UserAction action, KeyCode keyCode)
    {
        if (IsKeyCodeNone(keyCode)) throw new KeyCodeIsNoneException();
        if (IsKeyCodeAlreadyUsedByAnotherBind(action, keyCode)) throw new KeyCodeAlreadyInUseException(keyCode);
        if (IsKeyCodeInvalid(keyCode)) throw new KeyCodeInvalidException(keyCode);
        GetKeyBinds()[action] = keyCode;
    }
    public static void SetKeyBind(KeyBind keyBind)
    {
        SetKeyBind(keyBind.UserAction, keyBind.KeyCode);
    }
    public static Dictionary<UserAction, KeyCode> GetKeyBinds()
    {
        if (!BindsAreLoaded || KeyBinds == null) LoadKeyBinds();
        return KeyBinds;
    }
    public static void LoadKeyBinds()
    {
        KeyBinds = GetKeyBindDictionaryFromList(PersistentStateManager.GetPersistentState().KeyBinds);
        BindsAreLoaded = true;
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

    internal static void SaveKeyBinds()
    {
        PersistentStateManager.SaveKeyBinds(GetKeyBindListFromDictionary(KeyBinds));
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
    public static bool IsKeyCodeNone(KeyCode bind)
    {
        return bind == KeyCode.None;
    }
    public static bool IsKeyCodeInvalid(KeyCode bind)
    {
        switch (bind)
        {
            case KeyCode.Return: return true;
            case KeyCode.Escape: return true;
            case KeyCode.None: return true;
            case KeyCode.Ampersand: return true;
            default: return false;
        }
    }
    public static bool IsKeyCodeAlreadyUsedByAnotherBind(UserAction userAction, KeyCode bind)
    {
        return KeyBinds.ContainsValue(bind);
    }
}
