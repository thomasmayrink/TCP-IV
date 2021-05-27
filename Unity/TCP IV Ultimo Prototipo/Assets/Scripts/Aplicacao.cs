using UnityEngine;

public class Aplicacao : MonoBehaviour
{
    public JogadorModel jogadorModel { get; set; }
    public FaseModel faseModel { get; set; }
    public AudioSource musicaSource { get; set; }
    public AudioClip musica { get; set; }
    public Light luz { get; set; }

    private float timerMusica, timerMusicaMax;

    private void Awake()
    {
        jogadorModel = GetComponentInChildren<JogadorModel>();

        faseModel = GetComponentInChildren<FaseModel>();
        jogadorModel.Vidas = faseModel.JogadorVidas;
        jogadorModel.Pontos = 0;
        jogadorModel.PtsPowerUp = 0;

        musicaSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        musica = faseModel.Musicas[Random.Range(0, faseModel.Musicas.Length)];
        musicaSource.clip = musica;
        musicaSource.Play();

        timerMusicaMax = musica.length;


        luz = GameObject.FindGameObjectWithTag("Luz").GetComponent<Light>();
    }

    private void Update()
    {
        timerMusica += Time.deltaTime;
        if (timerMusica >= timerMusicaMax)
        {
            musica = faseModel.Musicas[Random.Range(0, faseModel.Musicas.Length)];
            musicaSource.clip = musica;
            musicaSource.Play();
            timerMusicaMax = musica.length;
            timerMusica = 0;

            Notificar(Notificacao.Fase.AumentarDificuldade, faseModel);
        }
    }

    private Controller[] Controllers
    {
        get
        {
            return GameObject.FindObjectsOfType<Controller>();
        }
    }

    public void Notificar(string evento_caminho, Object alvo, params object[] dados)
    {
        Controller[] controllers = Controllers;
        foreach(Controller c in controllers)
        {
            c.OnNotificacao(evento_caminho, alvo, dados);
        }
    }

    private void DebugApp(string txt)
    {
        Debug.Log(Utilidades.DebugComCor("App: " + txt, "white"));
    }
    public void DebugFase(string txt)
    {
        Debug.Log(Utilidades.DebugComCor("Fase: " + txt, "green"));
    }
    public void DebugToupeira(string txt)
    {
        Debug.Log(Utilidades.DebugComCor("Toupeira: " + txt, "yellow"));
    }
    public void DebugJogador(string txt)
    {
        Debug.Log(Utilidades.DebugComCor("Jogador: " + txt, "blue"));
    }
}
