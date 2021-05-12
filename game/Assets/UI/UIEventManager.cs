using System.Collections.Generic;
using UnityEngine;

public class UIEventManager : MonoBehaviour, EventListener
{
    static List<UIComponent> UIComponents = new List<UIComponent>();
    private static GameStateDTO gameStateDTO;
    
    public static void Subscribe(UIComponent component)
    {
        UIComponents.Add(component);
        LoadGameState();
        RenderAllComponentsIfRequired();
    } 
    void Start()
    {   
        EventBus.SubsrcribeAsUIEventManager(this);
        LoadGameState();
        RenderAllComponents();
    }
    void EventListener.onEvent(EventType eventType, GameObject source, int arg)
    {
        LoadGameState();
        RenderAllComponentsIfRequired();
    }
    private static void LoadGameState()
    {
        gameStateDTO = new GameStateDTO();
        gameStateDTO.MaximumNumberOfBulletsInstances = GameInfo.GetMaximumBulletsInstantiated();
    }
    private static void RenderAllComponents()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.Render(gameStateDTO);
        }
    }
    private static void RenderAllComponentsIfRequired()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.RenderIfRequired(gameStateDTO);
        }
    }
}
