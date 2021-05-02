using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToupeiraView : View
{
    private void OnMouseDown()
    {
        app.Notificar(Notificacao.TOUPEIRA_ACERTADA, this);
    }
}
