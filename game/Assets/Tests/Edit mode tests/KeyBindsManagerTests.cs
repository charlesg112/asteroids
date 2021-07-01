using Assets.Tests;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindsManagerTests
{
    [Test]
    public void GivenValidKeyBindsList_WhenConvertingToDictionary_ShouldContainValidKeyBinds()
    {
        // Arrange
        List<KeyBind> keyBindsList = Helpers.GetMockKeyBindsList();

        // Act
        Dictionary<UserAction, KeyCode> keyBindsDictionary = KeyBindsManager.GetKeyBindDictionaryFromList(keyBindsList);

        // Assert
        foreach(KeyBind bind in keyBindsList)
        {
            Assert.AreEqual(bind, new KeyBind(bind.UserAction, keyBindsDictionary[bind.UserAction]));
        }
    }
}
