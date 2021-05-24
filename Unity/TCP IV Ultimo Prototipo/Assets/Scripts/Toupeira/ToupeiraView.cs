using UnityEngine;

public class ToupeiraView : Elemento
{
    private Animator animator;
    private AudioSource audioSource;

    private Estado estado;

    private float limite;
    private Vector3 movimento;

    private float tempoNaTela;
    private float timerAnimacao;
    private float tempoMax;

    private Comportamento comportamento;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

        app.Notificar(Notificacao.Toupeira.Surgindo, this);
        estado = Estado.Surgindo;
    }

    private void Update()
    {
        switch (estado)
        {
            case Estado.Surgindo:
                if (transform.position.y <= limite)
                {
                    gameObject.transform.position += movimento;
                }
                else
                {
                    if(AnimacaoAcabou(0.8f))
                    {
                        app.Notificar(Notificacao.Toupeira.Idle, this);
                    }
                }
                break;

            case Estado.Idle:
                tempoNaTela += Time.deltaTime;

                if (animator.GetBool("Acertou"))
                {
                    timerAnimacao += Time.deltaTime;
                    if (timerAnimacao >= 0.5f)
                    {
                        animator.SetBool("Acertou", false);
                        timerAnimacao = 0;
                        app.Notificar(Notificacao.Toupeira.Idle, this);
                    }
                }
                if (animator.GetBool("Matou"))
                {
                    timerAnimacao += Time.deltaTime;
                    if (timerAnimacao >= 0.5f)
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
                if (transform.position.y <= -limite * 2)
                {
                    app.Notificar(Notificacao.Toupeira.Destruir, this);
                }
                break;
        }
    }

    private bool AnimacaoAcabou(float exitTime)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= exitTime)
        {
            return true;
        }
        else return false;
    }

    private void SeComportar()
    {
        switch (comportamento)
        {
            case Comportamento.Fofo:
                //Subir, esperar e descer
                break;

            case Comportamento.Doido:
                //Subir, esperar e descer
                break;

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
        app.Notificar(Notificacao.Toupeira.FoiAcertada, this);
    }

    private void FinalizarAnimacao()
    {

    }

    public void TocarSom(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Surgir(float velocidade, float limite)
    {
        movimento = velocidade * Vector3.up * Time.deltaTime;
        this.limite = limite;
    }

    public void Idle(int bpm, int[] dancasId, Comportamento comportamento, float tempoMax)
    {
        animator.speed = bpm / 120f;

        int dancaId = dancasId[Random.Range(0, dancasId.Length)];
        animator.SetInteger("DancaId", dancaId);

        this.comportamento = comportamento;
        this.tempoMax = tempoMax;
        
        estado = Estado.Idle;
    }

    public void Acertar(string parametro, bool verdadeiro)
    {
        animator.SetBool(parametro, verdadeiro);
    }

    public void Descer()
    {
        animator.SetBool("Desceu", true);
        movimento *= 0.75f;
        //movimento *= 2;
        estado = Estado.Descendo;
        app.Notificar(Notificacao.Toupeira.Descendo, this);
    }

    private enum Estado
    {
        Surgindo,
        Idle,
        Descendo
    }
}
