using UnityEngine;

public class ToupeiraView : Elemento
{
    private Animator animator;
    private Estado estado;
    private Vector3 movimento;
    private float limite;
    private Comportamento comportamento;
    private AudioSource audioSource;

    private float timerAnimacao;
    private float tempoNaTela;
    private float temposPorBatida;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

        app.Notificar(Notificacao.Toupeira.Surgindo, this);

        estado = Estado.Surgindo;
        animator.speed = app.faseModel.Bpm / 120.0f;        
    }

    private void Update()
    {
        switch (estado)
        {
            case Estado.Surgindo:
                if (transform.position.y >= limite)
                {
                    //estado = Estado.Idle;
                    app.Notificar(Notificacao.Toupeira.Idle, this);
                }
                gameObject.transform.position += movimento;
                break;

            case Estado.Idle:
                tempoNaTela += Time.deltaTime;

                if (animator.GetBool("Acertou"))
                {
                    timerAnimacao += Time.deltaTime;
                    if (timerAnimacao >= 0.25f)
                    {
                        animator.SetBool("Acertou", false);
                        timerAnimacao = 0;
                        app.Notificar(Notificacao.Toupeira.Idle, this);
                    }
                }

                if (animator.GetBool("Matou"))
                {
                    app.DebugToupeira("View: animatorGetBool " + animator.GetBool("Acertou"));
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.75f)
                    {
                        Descer();
                    }
                }

                switch (comportamento)
                {
                    case Comportamento.Doido:
                        if (tempoNaTela >= temposPorBatida * 4)
                        {
                            Descer();
                        }
                        break;

                    case Comportamento.Fofo:
                        if (tempoNaTela >= temposPorBatida * 4)
                        {
                            Descer();
                        }
                        break;

                    case Comportamento.PoucosAmigos:
                        break;

                    case Comportamento.Lider:
                        break;
                }
                break;

            case Estado.Descendo:

                transform.position -= movimento;
                if (transform.position.y <= -limite * 2)
                {
                    app.Notificar(Notificacao.Toupeira.Destruir, this);
                }
                break;
        }
    }

    private void OnMouseDown()
    {
        app.Notificar(Notificacao.Toupeira.FoiAcertada, this);
    }

    public void Surgir(float velocidade, float limite)
    {
        movimento = velocidade * Vector3.up * Time.deltaTime;
        this.limite = limite;
        estado = Estado.Surgindo;
    }

    public void Idle(int[] dancasId, Comportamento comportamento)
    {
        this.comportamento = comportamento;

        int dancaId = dancasId[Random.Range(0, dancasId.Length)];
        animator.SetInteger("DancaId", dancaId);
        estado = Estado.Idle;
    }

    public void SetTempoNaTela(float temposPorBatida)
    {
        this.temposPorBatida = temposPorBatida;
    }

    public void Acertar(string parametro, bool verdadeiro) 
    {
        animator.SetBool(parametro, verdadeiro);
    }

    public void Descer()
    {
        movimento *= 2;
        estado = Estado.Descendo;
        app.Notificar(Notificacao.Toupeira.Descendo, this);
    }

    public void TocarSom(AudioClip som)
    {
        audioSource.clip = som;
        audioSource.Play();
    }

    private enum Estado
    {
      //  Esperando,
        Surgindo,
        Idle,
        Descendo
    }
}
