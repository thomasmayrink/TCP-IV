using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FabricaArmadilha
{
    public static void Criar(ArmadilhaModel model, Armadilha armadilha, int bpm, GameObject acertouEfeito)
    {
        model.Dano = armadilha.dano;
        model.Raridade = armadilha.raridade;
        model.TemposNaTela = armadilha.temposNaTela / (bpm / 60f);
        //model.TemposNaTela = armadilha.temposNaTela;
        model.TipoDeArmadilha = armadilha.tipoDeAmadilha;
        model.SomAoSurgir = armadilha.somAoSurgir;
        model.SomPancada = armadilha.somPancada;
        model.AcertouEfeito = acertouEfeito;
    }
}
