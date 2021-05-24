using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FabricaArmadilha
{ 
    public static void Criar(ArmadilhaModel model, Armadilha armadilha)
    {
        model.DanoAoClicar = armadilha.danoAoClicar;
        model.Raridade = armadilha.raridade;
        model.TemposNaTela = armadilha.temposNaTela;
        model.TipoDeArmadilha = armadilha.tipoDeAmadilha;
    }
}
