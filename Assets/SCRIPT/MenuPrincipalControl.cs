using UnityEngine;
using UnityEngine.UI;
using System.Threading;
//using System.IO.Ports;

public class MenuPrincipalControl: MonoBehaviour
{

    //SerialPort serialPort = new SerialPort ("COM3", 9600);// en COM3, va el COM donde esta conectada la placa de Unity
    public Button startButton;

     public SerialController serialController;


    void Start(){
     

    }


    void Update()
    {
        string code = serialController.ReadSerialMessage();
        Debug.Log(code);
        
         if ( code.Contains( "7"))
        {
                Debug.Log("Pedro estuvo aqui");
                startButton.onClick.Invoke();

        }
       
    

    }

  
}
