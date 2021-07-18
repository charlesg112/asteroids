using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinderComponent : UIComponent<KeyBindingsState>
{
    public UserAction BindedUserAction;
    public Image Highlight;
    public TextMeshProUGUI Input;

    private bool isHighlighted;
    private KeyCode bindedTo;
    public override bool IsUpdateRequired(KeyBindingsState gameState)
    {
        return isHighlighted != ShouldBeHighlighted(gameState) ||
            bindedTo != gameState.CurrentKeyBinds[BindedUserAction];
    }

    public override void Render(KeyBindingsState gameState)
    {
        SetDisplayValues(gameState);
        SetButtonHighlight(gameState);
        SetButtonDisplayedKeyCode(gameState);
    }

    private void SetDisplayValues(KeyBindingsState gameState)
    {
        isHighlighted = ShouldBeHighlighted(gameState);
        bindedTo = gameState.CurrentKeyBinds[BindedUserAction];
    }

    private void SetButtonHighlight(KeyBindingsState gameState)
    {
        if (ShouldBeHighlighted(gameState)) Highlight.enabled = true;
        else Highlight.enabled = false;
    }
    private void SetButtonDisplayedKeyCode(KeyBindingsState gameState)
    {
        Input.text = bindedTo.ToString();
    }
    private bool ShouldBeHighlighted(KeyBindingsState gameState)
    {
        return gameState.HighlightedUserAction == BindedUserAction;
    }

    public void HandleClick()
    {
        UIEventBus.Publish(UIEventType.KeyBindButtonClicked, this);
    }

    public UserAction GetBindedUserAction()
    {
        return BindedUserAction;
    }
}
