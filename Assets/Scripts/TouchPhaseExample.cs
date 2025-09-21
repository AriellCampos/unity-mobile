//Attach this script to an empty GameObject
//Create some UI Text by going to Create>UI>Text.
//Drag this GameObject into the Text field to the Inspector window of your GameObject.

using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
using TMPro;


public class TouchPhaseExample : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    //public Text m_Text; OLD LEGACY
    public TextMeshProUGUI m_Text;

    string message;

    void Update()
    {
        // Atualize o texto na tela dependendo do TouchPhase atual e da dire��o atual vector 
        m_Text.text = "Touch : " + message + "in direction" + direction;

        // Rastreie um �nico toque como um controle de dire��o. 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Lidar com movimentos dos dedos com base no TouchPhasee
            switch (touch.phase)
            {
                //Quando um toque for detectado pela primeira vez, altere a mensagem e registre a posi��o inicial
                case TouchPhase.Began:
                    // Registre a posi��o de toque inicial.
                    startPos = touch.position;
                    message = "Begun ";
                    break;

                //Determina se o toque � um toque em movimento
                case TouchPhase.Moved:
                    // Determina a dire��o comparando a posi��o de toque atual com a inicial
                    direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Stationary:
                    Debug.Log("Touch Stationary at: " + touch.position);
                    //Executar a��es para um toque estacion�rio
                    break;

                case TouchPhase.Ended:
                    // Informar que o toque terminou quando ele terminar
                    message = "Ending ";
                    break;

                case TouchPhase.Canceled:
                    Debug.Log("Touch Canceled!");
                    // Lidar com canceled touches
                    break;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Debug.Log("Touch Canceled (simulado)");
        //}
    }
}
