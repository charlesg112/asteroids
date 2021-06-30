using System.Collections;
using System.IO;
using UnityEngine;

public static class PlayModeTestsHelpers
{
    public static IEnumerator WaitForNextSceneToLoad()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
    }

    public static PersistentState SetMockPersistentState()
    {
        PersistentState persistentState = Assets.Tests.Helpers.GetMockPersistentState();
        PersistentStateManager.SetSavePath($"{Directory.GetCurrentDirectory()}/tests.txt");
        PersistentStateManager.SetPersistentState(persistentState);
        return persistentState;
    }


}
