using UnityEngine;

public class StatementIF : MonoBehaviour
{
    protected string id = "-1";
    private CommandUI commandUI;

    private void Start()
    {
        if (!GetComponent<CommandUI>()) return;
        commandUI = GetComponent<CommandUI>();
        id = commandUI.GetCommand().id;
        if (commandUI.GetCommand().id.Equals("-1"))
        {
            Destroy(GetComponent<StatementIF>());
        }

        commandUI.SetMethodCast(Cast);
        commandUI.GetCommand().description = commandUI.GetCommand().description.Replace("[armor]", (10).ToString());
    }

    private void Cast()
    {
        Debug.Log("Read IF");
    }

}

