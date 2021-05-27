using UnityEngine;

public class ArmadilhaView : BaseObjetoView
{
    private Estado estado;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        app.Notificar(Notificacao.Armadilha.Surgindo, this);
        estado = Estado.Surgindo;
    }

    private void Update()
    {
        switch (estado)
        {
            case Estado.Surgindo:
                break;

            case Estado.Idle:
                break;
        }
    }
}