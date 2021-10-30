[System.Serializable]
public class Command : Action
{
    public long maxStacks;

    public Command()
    {
        this.id = "-1";
    }

    public override void Use(Delegate Method)
    {
        if (Method == null) return;
        Method();
    }
}
