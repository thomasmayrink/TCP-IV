using UnityEngine;

public static class FabricaToupeira
{
    public static void Criar(ToupeiraModel model, Toupeira toupeira, GameObject buraco)
    {
        model.Vida = toupeira.vida;
        model.Pontos = toupeira.pontos;
        model.Raridade = toupeira.raridade;
        model.Velocidade = toupeira.velocidade;
        model.TemposNaTela = toupeira.temposNaTela;
        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        model.Buraco = buraco;
        model.PodeSerAcertada = false;
        //model.EstaDescendo = false;

        model.SomAoSurgir = toupeira.somAoSurgir;
        model.SomPancada = toupeira.somPancada;
        //model.PosicaoInicial = posicao;
    }
}
