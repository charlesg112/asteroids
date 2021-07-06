using System.Collections.Generic;
using UnityEngine;

public abstract class UIEventManager: MonoBehaviour, EventListener, UIEventListener
{
    public List<UIComponent> UIComponents;
    protected static GameState GameState;

    public void Unsubscribe(UIComponent component)
    {
        UIComponents.Remove(component);
    }
    
    public void Subscribe(UIComponent component)
    {
        UIComponents.Add(component);
        RenderAllComponentsIfRequired();
    } 
    void Start()
    {   
        EventBus.SubsrcribeAsUIEventManager(this);
        UIEventBus.Subscribe(this);
        UpdateGameState();
    }

    public void onEvent(EventType eventType, GameObject source, int arg)
    {
        UpdateGameState();
    }
    public abstract void onUIEvent(UIEventType eventType, UIComponent source);
    public abstract void onUIEvent(UIEventType eventType, KeyCode keyCode);
    protected void UpdateGameState()
    {
        GameState currentGameState = FetchGameState();
        if (GameState != currentGameState)
        {
            GameState = currentGameState;
            RenderAllComponentsIfRequired();
        }
    }
    protected abstract GameState FetchGameState();

    protected void RenderAllComponents()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.Render(GameState);
        }
    }
    protected void RenderAllComponentsIfRequired()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.RenderIfRequired(GameState);
        }
    }
}
