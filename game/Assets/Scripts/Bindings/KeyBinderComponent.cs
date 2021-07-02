using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinderComponent : UIComponent
{
    public UserAction BindedUserAction;
    public Image Highlight;
    public TextMeshProUGUI Input;

    private bool isHighlighted;
    private KeyCode bindedTo;
    public override bool IsUpdateRequired(GameState gameState)
    {
        return isHighlighted != ShouldBeHighlighted(gameState) ||
            bindedTo != gameState.CurrentKeyBinds[BindedUserAction];
    }

    public override void Render(GameState gameState)
    {
        SetDisplayValues(gameState);
        SetButtonHighlight(gameState);
        SetButtonDisplayedKeyCode(gameState);
    }

    private void SetDisplayValues(GameState gameState)
    {
        isHighlighted = ShouldBeHighlighted(gameState);
        bindedTo = gameState.CurrentKeyBinds[BindedUserAction];
    }

    private void SetButtonHighlight(GameState gameState)
    {
        if (ShouldBeHighlighted(gameState)) Highlight.enabled = true;
        else Highlight.enabled = false;
    }
    private void SetButtonDisplayedKeyCode(GameState gameState)
    {
        Input.text = bindedTo.ToString();
    }
    private bool ShouldBeHighlighted(GameState gameState)
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
