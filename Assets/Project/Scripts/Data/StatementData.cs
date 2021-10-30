using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandData : MonoBehaviour
{
    [SerializeField] private List<Command> commands;

    private static CommandData instance = null;
    public static CommandData Instance() { return instance; }
    void Awake() => instance = this;

    public Command Find(string id)
    {
        return commands.Find(i => i.id.Equals(id));
    }

}
