using UnityEngine;

public class ToupeiraController
{
    public ToupeiraModel model { get; private set; }
    public ToupeiraView view { get; private set; }

    public ToupeiraController(ToupeiraModel model, ToupeiraView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Acertar()
    {
//        if (this.model.podeSerAcertada &&)
    }
}
