using System.Collections.Generic;
using UnityEngine;

namespace Assets.Tests
{
    public static class Helpers
    {
        public static PersistentState GetMockPersistentState()
        {
            // LevelData
            LevelData levelData1 = new LevelData(0, "level 1", true, false, 100, 5, "scene_level_1");
            LevelData levelData2 = new LevelData(1, "level 2", false, false, 200, 5, "scene_level_2");
            List<LevelData> levelDataList = new List<LevelData>();
            levelDataList.Add(levelData1);
            levelDataList.Add(levelData2);

            // KeyBinds
            Dictionary<UserAction, KeyCode> keyBinds = KeyBindsManager.GetDefaultKeyBinds();

            // PeristentState
            PersistentState output = new PersistentState();
            output.LevelDataList = levelDataList;
            output.KeyBinds = KeyBindsManager.GetKeyBindListFromDictionary(keyBinds);

            return output;
        }

        public static Dictionary<UserAction, KeyCode> GetMockKeyBindsDictionary()
        {
            Dictionary<UserAction, KeyCode> output = new Dictionary<UserAction, KeyCode>();
            output.Add(UserAction.BasicAttack, KeyCode.Mouse0);
            output.Add(UserAction.MoveUp, KeyCode.W);
            output.Add(UserAction.MoveLeft, KeyCode.A);
            output.Add(UserAction.MoveDown, KeyCode.S);
            output.Add(UserAction.MoveRight, KeyCode.D);
            return output;
        }

        public static List<KeyBind> GetMockKeyBindsList()
        {
            List<KeyBind> output = new List<KeyBind>();
            output.Add(new KeyBind(UserAction.BasicAttack, KeyCode.Mouse0));
            output.Add(new KeyBind(UserAction.MoveUp, KeyCode.W));
            output.Add(new KeyBind(UserAction.MoveLeft, KeyCode.A));
            output.Add(new KeyBind(UserAction.MoveDown, KeyCode.S));
            output.Add(new KeyBind(UserAction.MoveRight, KeyCode.D));
            return output;
        }
    }
}
