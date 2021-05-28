using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TesteMenu : MonoBehaviour
{
    [SerializeField] private AudioClip somBotaoConfirmar, somBotaoVoltar;
    private AudioSource audioSource;

    [SerializeField] private GameObject menu, 
                                        load,
                                        menuPrincipal, 
                                        menuFases, 
                                        menuOpcoes;

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
        StartCoroutine(LoadParalelo(cenaId));
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

    #region MENU_PRINCIPAL
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
            menuOpcoes.SetActive(false);
        }
        catch { }
        menuPrincipal.SetActive(true);
    }
    #endregion

    #region MENU_FASES
    public void MenuFases()
    {
        SomBtnConfirmar();
        menuPrincipal.SetActive(false);
        menuFases.SetActive(true);
    }
    public void CarregarFase(int cenaId)
    {
        Load(cenaId);
    }
    #endregion

    #region MENU_OPCOES
    public void MenuOpcoes()
    {
        SomBtnConfirmar();
        menuPrincipal.SetActive(false);
        menuOpcoes.SetActive(true);
    }
    #endregion

    #region MOSTRAR_PONTOS
    public void MostrarPontos()
    {
        foreach(Text t in txtGameOverPontos)
        {
            t.text = "Você fez " + "x" + " pontos!";
        }
    }
    #endregion

    #region JOGAR_NOVAMENTE (LEMBRAR DE PASSAR A FASE CERTA)
    public void JogarNovamente()
    {
        Load(1);
    }
    #endregion

    #region VOLTAR_MENU_PRINCIPAL
    public void VoltarAoMenu()
    {
        Load(0);
    }
    #endregion
}
