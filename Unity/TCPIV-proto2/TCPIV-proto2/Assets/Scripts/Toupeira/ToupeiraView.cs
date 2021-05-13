public class ToupeiraView : Elemento
{
    private void OnMouseDown()
    {
        app.Notificar(Notificacao.ToupeiraFoiAcertada, this);
    }
}
