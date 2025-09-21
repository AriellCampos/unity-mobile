using UnityEngine;

public class TouchSpawn : MonoBehaviour
{
    // Lista de prefabs de objetos 2D que podem ser instanciados
    public GameObject[] objetos;
    private int indiceAtual = 0; // controla qual objeto da lista ser� instanciado

    // PARTE 2 - COLOCAR O SOM DA CABRA

    public AudioClip somRemocao; // Som a ser tocado ao remover
    private AudioSource audioSource;

    void Start()
    {
        // Pega (ou adiciona) o AudioSource no GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Verifica se h� ao menos um toque na tela
        if (Input.touchCount > 0)
        {
            // Pega as informa��es do primeiro toque
            Touch toque = Input.GetTouch(0);

            // Apenas quando o toque come�ou
            if (toque.phase == TouchPhase.Began)
            {
                // Converte a posi��o do toque na tela para o mundo 2D
                Vector2 posicao = Camera.main.ScreenToWorldPoint(toque.position);

                // Verifica se j� existe algum objeto nessa posi��o
                Collider2D hit = Physics2D.OverlapPoint(posicao);

                if (hit != null)
                {

                // Toca o som antes de remover
                if (somRemocao != null) audioSource.PlayOneShot(somRemocao);

                // Remove o objeto existente
                Destroy(hit.gameObject);
                }

                // Instancia um novo objeto da lista
                Instantiate(objetos[indiceAtual], posicao, Quaternion.identity);

                // Passa para o pr�ximo objeto na lista (ciclo)
                indiceAtual = (indiceAtual + 1) % objetos.Length;
            }
        }
    }
}
