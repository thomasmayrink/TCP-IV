using UnityEngine;

public class CriarToupeira
{
    public CriarToupeira(Toupeira toupeira, ToupeiraModel model, Vector3 posicao)
    {
        model.Velocidade = toupeira.velocidade;
        model.Vida = toupeira.vida;
        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        model.PosicaoInicial = posicao;
    }
}
