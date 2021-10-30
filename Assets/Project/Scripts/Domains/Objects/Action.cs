[System.Serializable]
public class Action
{
    public string id;
    public string name;
    public string description;
    public long cost;
    public float cooldown;
    
    public string methodCast;
    public delegate void Delegate();
    public virtual void Use(Delegate Method) { }
}

