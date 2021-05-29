using UnityEngine;

public class ToupeiraView : BaseObjetoView
{
    private Animator animator;

    private bool rodando;

    private float timerAnimacao, timerAnimacaoMax;
    private Comportamento comportamento;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        col = gameObject.GetComponent<CapsuleCollider>();

        rodando = true;

        app.Notificar(Notificacao.Toupeira.Surgindo, this);
        estado = Estado.Surgindo;
        desceu = false;
    }
    private void Update()
    {
        if (rodando)
        {
            tempoNaTela += Time.deltaTime;
            timerAnimacao += Time.deltaTime;

            switch (estado)
            {
                case Estado.Surgindo:
                    if (animator.GetBool("Matou"))
                    {
                        Descer();
                    }
                    if (transform.position.y <= limite)
                    {
                        gameObject.transform.position += movimento;
                    }
                    else
                    {
                        gameObject.transform.position = new Vector3(transform.position.x, limite, transform.position.z);
                        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Subindo"))
                        {
                            app.Notificar(Notificacao.Toupeira.Idle, this);
                        }
                        else if (timerAnimacao >= timerAnimacaoMax * 0.5f)
                        {
                            app.Notificar(Notificacao.Toupeira.Idle, this, false);
                        }
                    }
                    break;

                case Estado.Idle:
                    if (animator.GetBool("Acertou"))
                    {
                        if (timerAnimacao >= timerAnimacaoMax * 0.3f)
                        {
                            animator.SetBool("Acertou", false);
                            app.Notificar(Notificacao.Toupeira.Idle, this);
                        }
                    }
                    if (animator.GetBool("Matou"))
                    {
                        if (timerAnimacao >= timerAnimacaoMax * 0.5f)
                        {
                            Descer();
                        }
                    }
                    if (tempoNaTela >= tempoMax)
                    {
                        Descer();
                    }
                    else
                    {
                        SeComportar();
                    }
                    break;

                case Estado.Descendo:
                    transform.position -= movimento;
                    if (transform.position.y <= -limite * 0.75f && !desceu)
                    {
                        col.enabled = false;
                        desceu = true;
                        app.Notificar(Notificacao.Toupeira.Desceu, this);
                    }
                    break;
            }
        }
    }
    private void SeComportar()
    {
        switch (comportamento)
        {
            case Comportamento.PoucosAmigos:
                //Subir, esperar tempo aleatório, pedir a posicao das outras toupeiras e trocar de lugar com 1
                break;

            case Comportamento.Lider:
                //Subir, descer, pedir os buracos livres e repete
                break;
        }
    }
    private void OnMouseDown()
    {
        col.enabled = false;
        app.Notificar(Notificacao.Toupeira.FoiAcertada, this);
    }

    public void Idle(float bpm, int[] dancasId, Comportamento comportamento, float tempoMax)
    {
        animator.speed = bpm / 120f;

        int dancaId = dancasId[Random.Range(0, dancasId.Length)];
        animator.SetInteger("DancaId", dancaId);

        this.comportamento = comportamento;
        this.tempoMax = tempoMax;
        timerAnimacaoMax = 120f / bpm;

        estado = Estado.Idle;
        col.enabled = true;
    }
    public void Acertou(string parametro, GameObject acertouEfeito)
    {
        animator.SetBool(parametro, true);
        timerAnimacao = 0;
        Acertar(acertouEfeito);
    }
    public void Matou(GameObject acertouEfeito)
    {
        Acertar(acertouEfeito);
        Descer();
    }
    public void Descer()
    {
        animator.SetBool("Desceu", true);
        estado = Estado.Descendo;
    }
    public void Rodando(bool rodando)
    {
        this.rodando = rodando;
    }
}
