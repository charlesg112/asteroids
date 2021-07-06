using System.Collections.Generic;
using UnityEngine;

public abstract class UIEventManager<T> : MonoBehaviour, EventListener, UIEventListener<T>
{
    public List<UIComponent<T>> UIComponents;
    public UIEventBus<T> UIEventBus;
    public EventBus EventBus;
    protected static T State;

    public void Unsubscribe(UIComponent<T> component)
    {
        UIComponents.Remove(component);
    }
    
    public void Subscribe(UIComponent<T> component)
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
    public abstract void onUIEvent(UIEventType eventType, UIComponent<T> source);
    public abstract void onUIEvent(UIEventType eventType, KeyCode keyCode);
    protected void UpdateGameState()
    {
        T currentState = FetchCurrentState();
        if (!State.Equals(currentState))
        {
            State = currentState;
            RenderAllComponentsIfRequired();
        }
    }
    protected abstract T FetchCurrentState();

    protected void RenderAllComponents()
    {
        foreach (UIComponent<T> component in UIComponents)
        {
            component.Render(State);
        }
    }
    protected void RenderAllComponentsIfRequired()
    {
        foreach (UIComponent<T> component in UIComponents)
        {
            component.RenderIfRequired(State);
        }
    }
}
