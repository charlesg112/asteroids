public interface PersistentStateRepository
{
    public void SavePeristentState(PersistentState state);

    public PersistentState RetrievePersistentState();
}
