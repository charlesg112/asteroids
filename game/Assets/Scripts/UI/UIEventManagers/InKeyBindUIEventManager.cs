using UnityEngine;

public class InKeyBindUIEventManager : UIEventManager<KeyBindingsState>
{
    private UserAction? highlightedAction;
    public override void onUIEvent(UIEventType eventType, UIComponent<KeyBindingsState> source)
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
        if (highlightedAction == null) return;
        UserAction userAction = GetSelectedComponent().BindedUserAction;
        try
        {
            KeyBindsManager.SetKeyBind(userAction, keyCode);
        }
        catch (KeyCodeIsNoneException) { }
        catch (KeyCodeInvalidException e)
        {
            Debug.Log($"KeyCodeInvalidException : {e}");
        }
        catch (KeyCodeAlreadyInUseException e)
        {
            Debug.Log($"KeyCodeAlreadyInUseException : {e}");
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

    protected override KeyBindingsState FetchCurrentState()
    {
        KeyBindingsState output = new KeyBindingsState();
        output.HighlightedUserAction = highlightedAction;
        output.CurrentKeyBinds = KeyBindsManager.GetKeyBinds();
        return output;
    }
}
