using UnityEngine;

public static class FabricaToupeira
{
    public static void Criar(ToupeiraModel model, Toupeira toupeira, Vector3 posicao)
    {
        model.Velocidade = toupeira.velocidade;
        model.Vida = toupeira.vida;
        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        model.PosicaoInicial = posicao;
    }
}
