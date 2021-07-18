public class MenuState
{
    public PersistentState PersistentState;

    public override bool Equals(object obj)
    {
        MenuState other = (MenuState) obj;
        if (other is null) return false;
        if (this.PersistentState != other.PersistentState) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return 948635478 + PersistentState.GetHashCode();
    }
}
