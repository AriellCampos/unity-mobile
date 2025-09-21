using UnityEngine;

public class CicloDeVida : MonoBehaviour
{
    // Chamado primeiro, antes do Start()
    // Usado para inicializar vari�veis e carregar recursos
    void Awake()
    {
        Debug.Log("Awake() -> Inicializa o objeto, chamado antes do Start.");
    }

    // Chamado logo ap�s o Awake, quando o objeto � ativado
    // Usado para preparar o objeto sempre que ele � reativado
    void OnEnable()
    {
        Debug.Log("OnEnable() -> Chamado quando o objeto � ativado.");
    }

    // Chamado uma �nica vez, logo no in�cio do jogo
    // Usado para configura��es iniciais
    void Start()
    {
        Debug.Log("Start() -> Executa uma vez no in�cio do jogo.");
    }

    // Chamado v�rias vezes por segundo (um por frame)
    // Usado para l�gicas do jogo que mudam constantemente
    void Update()
    {
        Debug.Log("Update() -> Executa a cada frame (l�gica do jogo).");
    }

    // Chamado v�rias vezes, mas em intervalos fixos de tempo
    // Usado para f�sica (movimentos, colis�es)
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate() -> Executa em intervalos fixos (f�sica).");
    }

    // Chamado ap�s todos os Updates() terem sido executados
    // Usado para ajustar a c�mera ou a��es que precisam ocorrer depois
    void LateUpdate()
    {
        Debug.Log("LateUpdate() -> Executa ap�s o Update (ex: seguir c�mera).");
    }

    // Chamado quando o objeto � desativado na cena
    // Usado para pausar sons, parar efeitos, limpar dados tempor�rios
    void OnDisable()
    {
        Debug.Log("OnDisable() -> Objeto foi desativado.");
    }

    // Chamado quando o objeto � destru�do
    // Usado para salvar dados ou liberar recursos
    void OnDestroy()
    {
        Debug.Log("OnDestroy() -> Objeto foi destru�do.");
    }

    //Destruir um objeto - OBS N�o � parte do ciclo de vida da UNITY
    void Destroy()
    {
        Destroy(gameObject);
    }
}
