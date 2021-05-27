using UnityEngine;

public class TesteMusicas : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicas;
    private AudioSource audioSource;
    private float timerMusica;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicas[Random.Range(0, musicas.Length)];
        timerMusica = 0;
        audioSource.Play();
    }

    private void Update()
    {
        timerMusica += Time.deltaTime;
        if (timerMusica >= audioSource.clip.length)
        {
            timerMusica = 0;
            audioSource.clip = musicas[Random.Range(0, musicas.Length)];
            audioSource.Play();
        }
    }
}
