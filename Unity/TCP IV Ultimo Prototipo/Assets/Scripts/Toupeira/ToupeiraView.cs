using UnityEngine;

public class ToupeiraView : Elemento
{
    private Estado estado;
    private Vector3 movimento;
    private int dancaId;
    private float limite;
    private float timer;

    public void Start()
    {
        estado = Estado.Esperando;
        app.Notificar(Notificacao.Toupeira.Subindo, this);
    }

    private void Update()
    {
        switch (estado)
        {
            case Estado.Subindo:
                //transform.position += movimento;
                //if (transform.position.y >= limite)
                //{
                //  estado = Estado.Idle;
                //}
                break;

            case Estado.Idle:
                //Usar dancaId
                //Usar comportamento
                //Contar tempo até descer
                //if (timer >= timerMax) 
                //{
                //  Descer();
                //}
                break;

            case Estado.Descendo:
                //transform.position -= movimento;
                //if (transform.position.y <= -limite * 2)
                //{
                //    app.Notificar(Notificacao.Toupeira.Destruir, this);
                //}
                //Mover até determinado ponto e Destruir
                break;
        }
    }

    private void OnMouseDown()
    {
        app.Notificar(Notificacao.Toupeira.FoiAcertada, this);
    }

    public void Subir(float velocidade, float limite)
    {
        movimento = velocidade * Vector3.up * Time.deltaTime;
        this.limite = limite;
        estado = Estado.Subindo;
    }

    public void Idle(int[] dancasId)
    {
        dancaId = dancasId[Random.Range(0, dancasId.Length)];
        estado = Estado.Idle;
    }

    public void Descer()
    {
        movimento *= 2;
        estado = Estado.Descendo;
    }

    private enum Estado
    {
        Esperando,
        Subindo,
        Idle,
        Descendo
    }
}
