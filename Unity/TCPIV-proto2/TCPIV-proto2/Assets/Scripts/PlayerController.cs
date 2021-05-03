using System;

public class PlayerController
{
    public Player model { get; private set; }
    public PlayerView view { get; private set; }

    public PlayerController(Player model, PlayerView view)
    {
        this.model = model;
        this.view = view;

        this.model.OnPositionChanged += OnPositionChanged;
    }

    private void OnPositionChanged(Vector3 position)
    {
        Vector3 pos = this.model.posicao;

        this.view.SetPosition(new UnityEngine.Vector3(pos.x, pos.y, pos.z));
    }

    private void SetPosition(Vector3 position)
    {
        this.model.posicao = position;
    }
}