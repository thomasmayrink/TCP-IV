using UnityEngine;

public abstract class BaseObjetoView : Elemento
{
    protected AudioSource audioSource;
    protected CapsuleCollider col;
    protected Estado estado;

    protected float tempoNaTela, tempoMax;
    
    protected float limite;
    protected Vector3 movimento;

    protected bool desceu;

    public void TocarSom(AudioClip clip)
    {
        if (audioSource.enabled)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
    public void Surgir(float velocidade, float limite)
    {
        movimento = velocidade * Vector3.up * Time.deltaTime;
        this.limite = limite;
    }
    public void Acertar(GameObject acertouEfeito)
    {
        var efeito = Instantiate(acertouEfeito, gameObject.transform.position, Quaternion.identity);
        efeito.transform.parent = gameObject.transform;
    }

    protected enum Estado
    {
        Surgindo,
        Idle,
        Descendo
    }
}
