using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteMenu : MonoBehaviour
{
    public void Jogo()
    {
        SceneManager.LoadScene("GabrielTeste1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("GabrielMenu1");
    }
}
