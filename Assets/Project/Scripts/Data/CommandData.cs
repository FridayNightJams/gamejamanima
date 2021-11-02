using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CommandData : MonoBehaviour
{
    [SerializeField] private List<Command> commands;
    [SerializeField] private List<Command> build;

    private static CommandData instance = null;
    public static CommandData Instance() { return instance; }
    private void Awake() => instance = this;

    private void Start()
    {
        CriarCommandos();
    }

    public Command Find(string id)
    {
        return commands.Find(i => i.id.Equals(id));
    }

    public void AdicionarCommand(string id, Action<Command> callback)
    {
        Command cmd = commands.Find(i => i.id.Equals(id));
        if (cmd == null) return;
        build.Add(cmd);
        callback(cmd);
    }

    public List<Command> GetBuild()
    {
        return build;
    }

    public List<Command> GetCommands()
    {
        return commands;
    }

    private void CriarCommandos()
    {
        Command m1 = new Command();
        m1.id = "MoverDireita";
        m1.position = new Vector3(1, 0, 0);
        m1.descricao = "<color=green>MoverDireita();</color>";
        commands.Add(m1);

        Command m2 = new Command();
        m2.id = "MoverEsquerda";
        m2.position = new Vector3(-1, 0, 0);
        m2.descricao = "<color=green>MoverEsquerda();</color>";
        commands.Add(m2);

        Command m3 = new Command();
        m3.id = "MoverCima";
        m3.position = new Vector3(0, 0, 1);
        m3.descricao = "<color=green>MoverCima();</color>";
        commands.Add(m3);

        Command m4 = new Command();
        m4.id = "MoverBaixo";
        m4.position = new Vector3(0, 0, -1);
        m4.descricao = "<color=green>MoverBaixo();</color>";
        commands.Add(m4);

        Command i1 = new Command();
        i1.id = "Pegar";
        i1.titulo = "<color=blue>se</color> Distancia(robo <= lixo && robo.carregaLixo == false) <color=blue>entao</color>";
        i1.descricao = "\t<color=green>PegarLixo();</color>";
        commands.Add(i1);

        Command i2 = new Command();
        i2.id = "Soltar";
        i2.titulo = "<color=blue>se</color> Distancia(robo <= lixeira && robo.carregaLixo == true) <color=blue>entao</color>";
        i2.descricao = "\t<color=green>SoltarLixo();</color>";
        commands.Add(i2);
    }

}
