using System;
using UnityEngine;
using System.Diagnostics;

public class InKeyBindEventManager : UIEventManager
{
    private UserAction? highlightedAction;
    public override void onUIEvent(UIEventType eventType, UIComponent source)
    {
        switch (eventType) 
        {
            case UIEventType.KeyBindButtonClicked:
                HandleKeyBindButtonClicked(source as KeyBinderComponent);
                break;
        }
        UpdateGameState();
    }
    public override void onUIEvent(UIEventType eventType, KeyCode keyCode)
    {
        UnityEngine.Debug.Log($"KEYDOWN : {keyCode}");
        HandleKeyDown(keyCode);
        UpdateGameState();
    }

    private void HandleKeyBindButtonClicked(KeyBinderComponent eventSource)
    {
        UnityEngine.Debug.Log($"Pressed on useraction : {eventSource.GetBindedUserAction()}. Current useraction : {highlightedAction}");
        if (highlightedAction == eventSource.BindedUserAction) highlightedAction = null;
        else highlightedAction = eventSource.BindedUserAction;
    }
    private void HandleKeyDown(KeyCode keyCode)
    {
        if (highlightedAction != null)
        {
            UserAction userAction = GetSelectedComponent().BindedUserAction;
            KeyBindsManager.SetKeyBind(userAction, keyCode);
        }
    }

    private KeyBinderComponent GetSelectedComponent()
    {
        return UIComponents.Find(c =>
        {
            KeyBinderComponent component = c as KeyBinderComponent;
            return component.GetBindedUserAction() == highlightedAction;
        }) as KeyBinderComponent;
    }

    protected override GameState FetchGameState()
    {
        GameState output = new GameState();
        output.HighlightedUserAction = highlightedAction;
        output.CurrentKeyBinds = KeyBindsManager.GetKeyBinds();
        return output;
    }
}
