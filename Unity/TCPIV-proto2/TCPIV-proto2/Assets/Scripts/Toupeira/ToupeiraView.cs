public class ToupeiraView : Elemento
{
    private void OnMouseDown()
    {
        app.Notificar(Notificacao.ToupeiraAcertada, this);
    }
}
