using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;         // Para manejo de archivos
using System.Text;       // Para manejo de StringBuilder


public class MostrarPuntaje : MonoBehaviour
{       
    public Text puntaje;
    private string filePath = Application.dataPath + "//txt//Puntajes.txt";
    
    private string tabla;

    // Start is called before the first frame update
    void Start()
    {
      string[] lines = File.ReadAllLines(filePath); 
         for (int i = 0; i < lines.Length; i++) // Comienza en 1 para saltar el BPM
                {
                     tabla+=lines[i];
                     tabla+= "\n";
                }
            
        puntaje.text = tabla.ToString();		
        
        
    }

    // Update is called once per frame
    void Update()
    
    {
        
        
    }
}
