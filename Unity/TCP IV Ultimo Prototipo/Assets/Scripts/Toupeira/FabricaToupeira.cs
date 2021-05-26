using UnityEngine;

public static class FabricaToupeira
{
    public static void Criar(ToupeiraModel model, Toupeira toupeira, int bpm, GameObject buraco, AudioClip somAoSurgir, AudioClip somPancada, GameObject acertouEfeito)
    {
        model.Vida = toupeira.vida;
        model.Pontos = toupeira.pontos;
        model.PontosPowerUp = toupeira.pontosPowerUp;
        model.Raridade = toupeira.raridade;
        model.Velocidade = toupeira.velocidade;
        model.BpmFase = bpm;
        model.TemposNaTela = toupeira.temposNaTela / (bpm / 60f);
        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        model.Buraco = buraco;
        model.SomAoSurgir = somAoSurgir;
        model.SomPancada = somPancada;
        model.acertouEfeito = acertouEfeito;
    }
}
