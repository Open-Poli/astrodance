using System.Collections;
using UnityEngine;
using System.IO.Ports;
using JetBrains.Annotations;

public class ObjetoCAer : MonoBehaviour
{
   
    public float tiempoEntreInstancias = 3f;
    public SerialPort serialPort = new SerialPort("/dev/ttyUSB0", 9600);

    void Start()
    {
   
        serialPort.ReadTimeout = 100;
      


        InvokeRepeating("GenerarInstanciaAleatoria", 0f, tiempoEntreInstancias);

    }

    void GenerarInstanciaAleatoria()
    {
          
        if (serialPort.IsOpen)
        {
            
                int indiceAleatorio = Random.Range(1, 4);
                if (indiceAleatorio == 1)
                {
                    serialPort.Write("1");
                }
                else if (indiceAleatorio == 2)
                {
                    serialPort.Write("2");
                }
                else if (indiceAleatorio == 3)
                {
                    serialPort.Write("3");
                }
                else if (indiceAleatorio == 4)
                {
                    serialPort.Write("4");
                }
            
        }
    }

}