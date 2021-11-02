using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CommandUI : MonoBehaviour
{
    protected Command command;
    [SerializeField] private TextMeshProUGUI titulo;
    [SerializeField] private TextMeshProUGUI descricao;
    [SerializeField] private Button remover;

    private void Start()
    {
        remover.onClick.AddListener(() => RemoverCmd());
        remover.gameObject.SetActive(!GameManager.Instance().IsPlaying());
    }

    public void Criar(Command cmd)
    {
        command = cmd;
        descricao.text = cmd.descricao;
        if (titulo != null) titulo.text = cmd.titulo;
    }

    private void RemoverCmd()
    {
        CommandData.Instance().GetBuild().Remove(command);
        Destroy(gameObject);
    }

}