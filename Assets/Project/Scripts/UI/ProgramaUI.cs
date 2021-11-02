using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ProgramaUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button buildButton;

    [SerializeField] private Transform content;

    [Header("Prefabs")]
    [SerializeField] private GameObject commandPrefab;
    [SerializeField] private GameObject commandIfPrefab;

    private void Start()
    {
        CriarBuild();
    }

    public void AdicionarComando(string id)
    {
        CommandData.Instance().AdicionarCommand(id, result =>{
            CriarBuild();
        });
    }

    private void CriarBuild()
    {
        ClearContent();
        GameObject prefab = null;
        foreach (Command c in CommandData.Instance().GetBuild())
        {
            prefab = commandPrefab;
            if (c.titulo != null && c.titulo.Length > 0) prefab = commandIfPrefab;

            GameObject line = Instantiate(prefab);
            line.GetComponent<CommandUI>().Criar(c);

            line.transform.SetParent(content);
            line.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private void ClearContent()
    {
        foreach (Transform t in content)
        {
            Destroy(t.gameObject);
        }
    }

}