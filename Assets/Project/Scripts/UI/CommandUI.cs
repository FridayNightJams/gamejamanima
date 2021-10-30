using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CommandUI : MonoBehaviour
{
    [SerializeField] private Command command;
    [SerializeField] private Action.Delegate methodCast;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI title;

    public void Use()
    {
        if (command.methodCast == null) return;
        command.Use(methodCast);
    }

    public void SetCommand(Command value)
    {
        title.text = "";

        if (value.id.Equals("-1")) return;

        command = CommandData.Instance().Find(value.id);

        title.text = value.description;

        if (command.methodCast.Equals("")) return;
        this.gameObject.AddComponent(Type.GetType(command.methodCast));
    }

    public Command GetCommand()
    {
        return command;
    }

    public void SetMethodCast(Action.Delegate cast)
    {
        this.methodCast = cast;
    }
}