using System;
using System.Collections.Generic;
using UnityEngine;

public class UIEventManager : MonoBehaviour, EventListener, UIEventListener
{
    static List<UIComponent> UIComponents = new List<UIComponent>();
    private static UIReducer Reducer = new UIReducer();

    public static void Unsubscribe(UIComponent component)
    {
        UIComponents.Remove(component);
    }

    private static GameState gameState;
    
    public static void Subscribe(UIComponent component)
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

    void EventListener.onEvent(EventType eventType, GameObject source, int arg)
    {
        UpdateGameState();
    }
    void UIEventListener.onUIEvent(UIEventType eventType, UIComponent source)
    {
        Reducer.Reduce(eventType);
    }
    private void UpdateGameState()
    {
        GameState currentGameState = FetchGameState();
        if (gameState != currentGameState)
        {
            gameState = currentGameState;
            RenderAllComponentsIfRequired();
        }
    }
    private static GameState FetchGameState()
    {
        GameState gameState = new GameState();
        gameState.MaximumNumberOfBulletsInstances = GameInfo.GetMaximumBulletsInstantiated();
        return gameState;
    }
    private static void RenderAllComponents()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.Render(gameState);
        }
    }
    private static void RenderAllComponentsIfRequired()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.RenderIfRequired(gameState);
        }
    }
}
