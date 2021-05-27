using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteMenu : MonoBehaviour
{
    [SerializeField] private AudioClip somBotao;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = somBotao;
    }

    public void Jogo()
    {
        audioSource.Play();
        SceneManager.LoadScene("GabrielTeste1");
    }

    public void Menu()
    {
        audioSource.Play();
        SceneManager.LoadScene("GabrielMenu1");
    }
}
