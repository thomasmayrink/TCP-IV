using UnityEngine;

public class ArmadilhaView : BaseObjetoView
{
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        col = gameObject.GetComponent<CapsuleCollider>();

        app.Notificar(Notificacao.Armadilha.Surgindo, this);
        estado = Estado.Surgindo;
        desceu = false;
    }

    private void Update()
    {
        tempoNaTela += Time.deltaTime;

        switch (estado)
        {
            case Estado.Surgindo:
                if (transform.position.y <= limite)
                {
                    gameObject.transform.position += movimento;
                }
                else
                {
                    gameObject.transform.position = new Vector3(transform.position.x, limite, transform.position.z);
                    app.Notificar(Notificacao.Armadilha.Idle, this);
                }
                break;

            case Estado.Idle:
                if (tempoNaTela >= tempoMax)
                {
                    Descer();
                }
                break;

                //COLOCAR POR AQUI A QUESTÃO DAS VARIAÇÕES. CADA TIPO DE ARMADILHA PODE MANDAR UMA NOTIFICAÇÃO DIFERENTE. O MESMO COM AS TOUPEIRAS, TALVEZ OUTRA CLASSE NAS NOTIFICAÇÕES

            case Estado.Descendo:
                transform.position -= movimento;
                if (transform.position.y <= -limite && !desceu)
                {
                    col.enabled = false;
                    desceu = true;
                    app.Notificar(Notificacao.Armadilha.Desceu, this);
                }
                break;
        }
    }

    private void OnMouseDown()
    {
        col.enabled = false;
        app.Notificar(Notificacao.Armadilha.FoiAcertada, this);
    }

    public void Idle(float tempoMax)
    {
        this.tempoMax = tempoMax;

        estado = Estado.Idle;
        col.enabled = true;
    }
    public void Acertou(GameObject acertouEfeito)
    {
        Acertar(acertouEfeito);
    }

    public void Descer()
    {
        estado = Estado.Descendo;
    }
}
