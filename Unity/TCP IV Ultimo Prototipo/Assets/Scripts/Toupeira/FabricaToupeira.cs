using UnityEngine;

public static class FabricaToupeira
{
    public static void Criar(ToupeiraModel model, Toupeira toupeira, float bpm, GameObject buraco, AudioClip somAoSurgir, AudioClip somPancada, GameObject acertouEfeito)
    {
        model.Vida = toupeira.vida;
        model.Pontos = toupeira.pontos;
        model.PontosPowerUp = toupeira.pontosPowerUp;
        model.Velocidade = toupeira.velocidade;
        model.Dano = toupeira.dano;
        model.Raridade = toupeira.raridade;
        model.TemposNaTela = toupeira.temposNaTela / (bpm / 60f);

        model.BpmFase = bpm;
        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        model.Buraco = buraco;
        model.SomAoSurgir = somAoSurgir;
        model.SomPancada = somPancada;
        model.AcertouEfeito = acertouEfeito;
    }
}
