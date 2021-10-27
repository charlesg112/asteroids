public class KeyBindSaveButton : UIComponent<KeyBindingsState>
{
    public override bool IsUpdateRequired(KeyBindingsState state)
    {
        return false;
    }

    public override void Render(KeyBindingsState state)
    {
        
    }

    public void SaveKeyBinds()
    {
        UIEventBus.Publish(UIEventType.SaveKeyBinds, this);
    }
}
