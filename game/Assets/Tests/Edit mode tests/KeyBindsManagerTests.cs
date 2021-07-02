using Assets.Tests;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeyBindsManagerTests
{
    [Test]
    public void GivenValidKeyBindsList_WhenConvertingToDictionary_ThenShouldContainValidKeyBinds()
    {
        // Arrange
        List<KeyBind> keyBindsList = Helpers.GetMockKeyBindsList();

        // Act
        Dictionary<UserAction, KeyCode> keyBindsDictionary = KeyBindsManager.GetKeyBindDictionaryFromList(keyBindsList);

        // Assert
        keyBindsList.ForEach(bind => Assert.AreEqual(bind, new KeyBind(bind.UserAction, keyBindsDictionary[bind.UserAction])));
    }

    [Test]
    public void GivenValidKeyBindsDictionary_WhenConvertingToList_ThenShouldContainValidKeyBinds()
    {
        // Arrange
        Dictionary<UserAction, KeyCode> keyBindsDictionary = Helpers.GetMockKeyBindsDictionary();

        // Act
        List<KeyBind> keyBindsList = KeyBindsManager.GetKeyBindListFromDictionary(keyBindsDictionary);

        // Assert
        foreach (KeyValuePair<UserAction, KeyCode> keyValuePair in keyBindsDictionary)
        {
            Assert.AreEqual(new KeyBind(keyValuePair.Key, keyValuePair.Value), keyBindsList.Find(keyBind => keyBind.UserAction == keyValuePair.Key));
        }
    }

    [Test]
    public void GivenSavedKeyBinds_WhenGettingKeyBinds_ThenShouldLoadValidKeyBinds()
    {
        // Arrange
        List<KeyBind> keyBindsList = Helpers.GetMockKeyBindsList();
        Dictionary<UserAction, KeyCode> expectedKeyBinds = Helpers.GetMockKeyBindsDictionary();
        PersistentStateManager.SetPersistentState(new PersistentState(null, keyBindsList));
        PersistentStateManager.SetSavePath($"{Directory.GetCurrentDirectory()}/keybindstests.txt");
        PersistentStateManager.SaveState();

        // Act
        KeyBindsManager.LoadKeyBinds();
        Dictionary<UserAction, KeyCode> actualKeyBinds = KeyBindsManager.GetKeyBinds();

        // Assert
        Assert.AreEqual(expectedKeyBinds, actualKeyBinds);
    }

    [Test]
    public void GivenValidKeyBinds_WhenGettingKeyBindFromUserAction_ThenShouldReturnValidKeyBinds()
    {
        // Arrange
        Dictionary<UserAction, KeyCode> expectedKeyBinds = Helpers.GetMockKeyBindsDictionary();
        KeyBindsManager.SetKeyBinds(expectedKeyBinds);

        // Assert
        foreach (KeyValuePair<UserAction, KeyCode> keyValuePair in expectedKeyBinds)
        {
            Assert.AreEqual(KeyBindsManager.GetAssociatedKey(keyValuePair.Key), keyValuePair.Value);
        }
    }
    [Test]
    public void GivenValidKeyBinds_WhenSettingSingleKeyBind_ThenShouldSetValidKeyBinds()
    {
        // Arrange
        Dictionary<UserAction, KeyCode> defaultKeyBinds = Helpers.GetMockKeyBindsDictionary();
        KeyBindsManager.SetKeyBinds(defaultKeyBinds);
        KeyBind expectedKeyBind = new KeyBind(UserAction.BasicAttack, KeyCode.Alpha6);

        // Act
        KeyBindsManager.SetKeyBind(expectedKeyBind);

        // Assert
        KeyBind actualKeyBind = new KeyBind(expectedKeyBind.UserAction, KeyBindsManager.GetKeyBinds()[expectedKeyBind.UserAction]);
        Assert.AreEqual(expectedKeyBind, actualKeyBind);
    }
}
