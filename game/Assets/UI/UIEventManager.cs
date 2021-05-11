using System.Collections.Generic;
using UnityEngine;

public class UIEventManager : MonoBehaviour, EventListener
{
    static List<UIComponent> UIComponents = new List<UIComponent>();
    private GameStateDTO gameStateDTO;
    
    public static void Subscribe(UIComponent component)
    {
        UIComponents.Add(component);
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
    private void LoadGameState()
    {
        gameStateDTO = new GameStateDTO();
        gameStateDTO.MaximumNumberOfBulletsInstances = GameInfo.GetMaximumBulletsInstantiated();
    }
    private void RenderAllComponents()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.Render(this.gameStateDTO);
        }
    }
    private void RenderAllComponentsIfRequired()
    {
        foreach (UIComponent component in UIComponents)
        {
            component.RenderIfRequired(this.gameStateDTO);
        }
    }
}
