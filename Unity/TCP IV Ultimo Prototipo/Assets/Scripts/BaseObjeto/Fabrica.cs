using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fabrica
{
    public static void Toupeira(ToupeiraModel model,
                                Toupeira toupeira, 
                                float bpm, 
                                GameObject buraco, 
                                AudioClip somAoSurgir,
                                AudioClip somPancada, 
                                AudioClip somDano, 
                               // AudioClip somFugiu, 
                                GameObject acertouEfeito)
    {
        Criar(model, bpm, buraco, somAoSurgir, somPancada, somDano, acertouEfeito);
        model.Vida = toupeira.vida;
        model.Pontos = toupeira.pontos;
        model.PontosPowerUp = toupeira.pontosPowerUp;
        model.PontosTimer = toupeira.pontosTimer;
        model.Velocidade = toupeira.velocidade;
        model.Dano = toupeira.dano;
        model.Raridade = toupeira.raridade;
        model.TemposNaTela = toupeira.temposNaTela / (bpm / 60f);

        model.DancasId = toupeira.dancasId;
        model.Comportamento = toupeira.comportamento;
        //model.SomFugiu = somFugiu;
    }
    public static void Armadilha(ArmadilhaModel model,
                                 Armadilha armadilha,
                                 float bpm, 
                                 GameObject buraco, 
                                 AudioClip somAoSurgir,
                                 AudioClip somPancada,
                                 AudioClip somDano, 
                                 GameObject acertouEfeito)
    {
        Criar(model, bpm, buraco, somAoSurgir, somPancada, somDano, acertouEfeito);

        model.Vida = armadilha.vida;
        model.Pontos = armadilha.pontos;
        model.PontosPowerUp = armadilha.pontosPowerUp;
        model.PontosTimer = armadilha.pontosTimer;
        model.Velocidade = armadilha.velocidade;
        model.Dano = armadilha.dano;
        model.Raridade = armadilha.raridade;
        model.TemposNaTela = armadilha.temposNaTela / (bpm / 60f);

        model.TipoDeArmadilha = armadilha.tipoDeAmadilha;
    }

    private static void Criar(BaseObjetoModel model, float bpm, GameObject buraco, AudioClip somAoSurgir, AudioClip somPancada, AudioClip somDano, GameObject acertouEfeito)
    {
        model.BpmFase = bpm;
        model.Buraco = buraco;
        model.SomAoSurgir = somAoSurgir;
        model.SomPancada = somPancada;
        model.SomDano = somDano;
        model.AcertouEfeito = acertouEfeito;
    }
}
