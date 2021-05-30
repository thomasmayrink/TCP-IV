using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TesteMenu : Elemento
{
    [SerializeField] private AudioClip somBotaoConfirmar, somBotaoVoltar;
    private AudioSource audioSource;

    [SerializeField] private GameObject menu, 
                                        load,
                                        menuPrincipal, 
                                        menuFases, 
                                        menuRanking,
                                        menuOpcoes,
                                        menuPause,
                                        btnPause;

    [SerializeField] private Slider barraCarregamento;
    [SerializeField] private Text txtCarregamento;
    [SerializeField] private Text[] txtGameOverPontos;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        try
        {
            MostrarPontos();
        }
        catch { }
    }
    private void SomBtnConfirmar()
    {
        audioSource.clip = somBotaoConfirmar;
        audioSource.Play();
    }
    private void SomBtnVoltar()
    {
        audioSource.clip = somBotaoVoltar;
        audioSource.Play();
    }
    private void Load(int cenaId)
    {
        if (cenaId >= 0)
        {
            StartCoroutine(LoadParalelo(cenaId));
        }
        else
        {
            StartCoroutine(LoadParalelo());
        }
    }
    IEnumerator LoadParalelo(int cenaId)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(cenaId);
        
        load.SetActive(true);

        while (!op.isDone)
        {
            float progresso = Mathf.Clamp01(op.progress / .9f);
            barraCarregamento.value = progresso;
            txtCarregamento.text = ((int)(progresso * 100)) + "%";

            yield return null;
        }
    }
    IEnumerator LoadParalelo()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.sceneCountInBuildSettings - 1);

        while (!op.isDone)
        {
            yield return null;
        }
    }

    public void BtnVoltar()
    {
        SomBtnVoltar();
        try
        {
            menuFases.SetActive(false);
        }
        catch { }
        try
        {
            menuRanking.SetActive(false);
        }
        catch { }
        try
        {
            menuOpcoes.SetActive(false);
        }
        catch { }
        menuPrincipal.SetActive(true);
    }
    public void MenuFases()
    {
        SomBtnConfirmar();
        menuPrincipal.SetActive(false);
        menuFases.SetActive(true);
    }
    public void CarregarFase(int cenaId)
    {
        TesteDados.UltimaFaseId = cenaId;
        Load(cenaId);
    }
    public void MenuRanking()
    {
        SomBtnConfirmar();
        menuPrincipal.SetActive(false);
        menuRanking.SetActive(true);
    }
    public void MenuOpcoes()
    {
        SomBtnConfirmar();
        menuPrincipal.SetActive(false);
        menuOpcoes.SetActive(true);
    }
    public void MenuPause(bool ativar)
    {
        if (ativar)
        {
            TesteDados.JogoPausado = true;
            btnPause.SetActive(false);
            app.musicaSource.Pause();
            SomBtnConfirmar();
            Time.timeScale = 0f;
        }
        else
        {
            TesteDados.JogoPausado = false;
            if (TesteDados.PowerUp3)
            {
                Time.timeScale = 0.1f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            SomBtnVoltar();
            app.musicaSource.Play();
            btnPause.SetActive(true);
        }
        menuPause.SetActive(ativar);
    }
    public void GameOver()
    {
        TesteDados.JogoPausado = false;
        TesteDados.PowerUp3 = false;

        Time.timeScale = 1f;
        Load(-1);
    }
    public void MostrarPontos()
    {
        foreach(Text t in txtGameOverPontos)
        {
            t.text = "Você fez " + TesteDados.PontosUltimaFase + " pontos!";
        }
    }
    public void JogarNovamente()
    {
        TesteDados.JogoPausado = false;
        TesteDados.PowerUp3 = false;

        SomBtnConfirmar();
        Load(TesteDados.UltimaFaseId);
    }
    public void VoltarAoMenu()
    {
        TesteDados.JogoPausado = false;
        TesteDados.PowerUp3 = false;
        Time.timeScale = 1f;
        SomBtnConfirmar();
        Load(0);
    }
}
