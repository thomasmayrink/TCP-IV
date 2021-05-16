using UnityEngine;

public static class FabricaToupeira
{
    public static void Criar(ToupeiraModel model, Toupeira toupeira, GameObject buraco) // Vector3 posicao)
    {
        //model.Velocidade = toupeira.velocidade;
        model.Vida = toupeira.vida;
        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        model.Buraco = buraco;
//        model.PosicaoInicial = posicao;
    }
}
