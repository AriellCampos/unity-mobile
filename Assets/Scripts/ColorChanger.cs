using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Vari�veis
    public Color[] cores;   // lista de cores poss�veis
    private SpriteRenderer sr;
    private int index = 0;  // controla qual cor est� ativa

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Loop: inicializa lista de cores
        // cria 5 cores diferentes

        // Define manualmente as cores (RGB)
        //cores = new Color[3];
        //cores[0] = Color.red;    // vermelho
        //cores[1] = Color.green;  // verde
        //cores[2] = Color.blue;   // azul 

        cores = new Color[5];
        for (int i = 0; i < cores.Length; i++)
        {
            cores[i] = Random.ColorHSV(); // gera cor aleat�ria
        }

        sr.color = cores[index]; // come�a na primeira cor
    }

    void Update()
    {
        // Condicional: se apertar espa�o no PC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrocarCor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        { }
            // Condicional: se tocar na tela (mobile)
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TrocarCor();
        }
    }

    void TrocarCor()
    {
        // Muda para a pr�xima cor do array
        index++;

        if (index >= cores.Length) // condicional para voltar ao in�cio
            index = 0;

        sr.color = cores[index];
    }
}
