using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;
using System.Text;       // Para manejo de StringBuilder
 
public class ManageScrollBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Button boton;
    public TMP_Text myText;
    public TMP_Text myText2;
    public TMP_Text cartel1;
    public TMP_Text cartel2;
    int omega = 0;
    int alpha = 0;
    public GameObject gameObject;
    
    public TMP_Text tmpText;
    public TMP_Text tmpText2;
    public TMP_Text tmpText3;

    public SerialController serialController;
    public float scrollSpeed = 0.2f; // Ajusta la velocidad de scroll.
    public float elementWidth = 0.1f; // El tamaño del "elemento" que se quiere centrar, en términos de valor normalizado (0 a 1).
     public TMP_Text tmpText1; // Asigna aquí el componente TMP_Text en el inspector
    private float targetPosition; // Posición del scrollbar que se debe centrar.
    private bool estaSonando = false;
    [SerializeField] private List<string> songNames;
    [SerializeField] private List<Sprite> songPanels;
    [SerializeField] private List<AudioClip> songs;
    [SerializeField] private AudioSource audioSource; // Componente AudioSource
    public Vector2 targetSize = new Vector2(300, 300); // Tamaño objetivo.
    public float resizeSpeed = 2.0f; // Velocidad de redimensionamiento.
    public bool isScore = false;
    public Vector2 initialSize = new Vector2(250, 250); // Tamaño objetivo.
    public int score = 0;
    bool jugando = false;
    
    void Start()
    {   
        
        
        tmpText.text = "";
        tmpText2.text = "";
        tmpText3.text = "";
        
       
    }
 
    void Update()
    {   
   
        string code = serialController.ReadSerialMessage();
        Debug.Log(code);
 
     
        // Detecta la flecha derecha
      
 
         if (code.Contains( "F"))
        {   
        
            if(Int32.Parse(myText.text) > Int32.Parse(myText2.text)){
                cartel1.text = "Ganaste";
                cartel1.faceColor = Color.green;
                cartel2.text = "Perdiste";
                cartel2.faceColor = Color.red;                
                score = Int32.Parse(myText.text);
                WriteScoreToFile(score);
 
 
            }
            if(Int32.Parse(myText.text) < Int32.Parse(myText2.text)){
                cartel1.text = "Perdiste";
                cartel1.faceColor = Color.red;
                cartel2.text = "Ganaste";
                cartel2.faceColor = Color.green;
                score = Int32.Parse(myText2.text);
                 WriteScoreToFile(score);
 
            }
            if(myText.text == myText2.text){
                cartel1.text = "Empate";
                cartel2.text = "Empate";
                score = Int32.Parse(myText.text);
                WriteScoreToFile(score);
            }
                audioSource.volume = 0.5f;
                
                 Invoke("ChangeScene", 10f);
        }
 
     
       /* if(code.Contains("=")){
        PlaySelectedSong();
 
        }*/
 
      
        if(jugando){
           
        }
         
        if(jugando == false){
            if(code.Contains("7")){
              
                tmpText.text = "score";
                tmpText.text2 = "player 1";
                tmpText.text3 = "player 2";
                boton.onClick.Invoke();
                leerArchivo();
                Destroy(gameObject);
        
                isScore = true;
                jugando = true;
            }
 
               // Detecta la flecha izquierda
            if (code.Contains( "4"))
            {
                if(alpha!= 0 ){
                alpha--;
            }else{
                alpha = 9;
            }
                MoveLeft();
            }
 
             if (code.Contains( "6"))
            {   
                if(alpha != 9 ){
                alpha++;
            }else{
                alpha = 0;
             }
            
        MoveRight();
        }
        }
    
  
 
        if(isScore == true){
                if(code.Contains( "?")){
            
                code = code.Substring(1);
                
                myText.text = code;
                }       
 
                if(code.Contains( "}")){
            
                code = code.Substring(1);
                
                myText2.text = code;
                }       
            
                 if(code.Contains("=") && !estaSonando){
                
                    PlaySelectedSong();
                
                    estaSonando = true;
                }   
                
            
        }
 
        tmpText1.text = songNames[alpha];
        boton.image.sprite = songPanels[alpha];
    }
 
    void MoveRight()
    {
        // Mueve a la derecha y ajusta la posición del scrollbar
     
        if(omega != 9 ){
            omega++;
        }else{
            omega = 0;
        }
      
       
    }
 
    void MoveLeft()
    {
        // Mueve a la izquierda y ajusta la posición del scrollbar
           if(omega != 0 ){
            omega--;
        }
        else{
        omega = 9;
        }
       
    }
 
      void ChangeScene()
    {
        SceneManager.LoadScene("MENUPRINCIPAL");
    }
 
    
    
 
        void PlaySelectedSong()
        {
            audioSource.clip = songs[alpha];
            audioSource.Play();
        
        }
        //falta el fade y parar la cancion
 
 
 
    void WriteScoreToFile(int score){
    string filePath = Application.dataPath + "//txt//Puntajes.txt";
    
    // Asegurarte de que el directorio existe
    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath));
 
    List<int> scores = new List<int>();
    
    // Leer puntajes existentes
    if (System.IO.File.Exists(filePath))
    {
        string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            if (int.TryParse(line, out int existingScore))
            {
                scores.Add(existingScore);
            }
        }
    }
 
    // Añadir el nuevo puntaje
    scores.Add(score);
    
    // Ordenar los puntajes de mayor a menor
    scores.Sort((a, b) => b.CompareTo(a));
    
    // Escribir los puntajes ordenados de nuevo al archivo
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false)) // false para sobrescribir
    {
        foreach (int s in scores)
        {
            file.WriteLine(s);
        }
    }
}
void leerArchivo(){
      string code = serialController.ReadSerialMessage();
        string filePath = Application.dataPath + "//txt//" + songNames[alpha] + ".txt";
        
        if (System.IO.File.Exists(filePath))
        {   
            string llll="";
            string[] lines = System.IO.File.ReadAllLines(filePath); // Lee todas las líneas del archivo
            if (lines.Length > 0)
            {
         
 
               
                //StringBuilder secuencia = new StringBuilder();
                for (int i = 0; i < lines.Length/2; i++) // Comienza en 1 para saltar el BPM
                {
                     llll+=lines[i];
                
                    //SendDataToArduino( lines[i]);
                    //secuencia.Append(lines[i]); // Agrega cada letra al string
                }
                
                  Debug.Log(llll);
                  SendDataArduino(llll);
                 
                // Enviar BPM y secuencia al Arduino
                //SendDataToArduino( secuencia.ToString());*/
              
            }
            else
            {
                Debug.LogError("El archivo está vacío");
            }
            Thread.Sleep(1000);
            llll="";
            lines = System.IO.File.ReadAllLines(filePath); // Lee todas las líneas del archivo
            if (lines.Length > 0)
            {
         
 
               
                //StringBuilder secuencia = new StringBuilder();
                for (int i = (lines.Length/2); i < lines.Length; i++) // Comienza en 1 para saltar el BPM
                {
                     llll+=lines[i];
                
                    //SendDataToArduino( lines[i]);
                    //secuencia.Append(lines[i]); // Agrega cada letra al string
                }
                
                  Debug.Log(llll);
                  SendDataArduino(llll);
                 
                // Enviar BPM y secuencia al Arduino
                //SendDataToArduino( secuencia.ToString());*/
              
            }
            else
            {
                Debug.LogError("El archivo está vacío");
            }
        }
        else
        {
            Debug.LogError("Archivo no encontrado: " + filePath);
        }
}
 
  void SendDataArduino( string data)
    {
        /*
        if (serialPort != null && serialPort.IsOpen)
        {
            string message = data ;  // Formato: "BPM,secuencia\n"
            serialController.SendSerialMessage(data);
            Debug.Log("Mensaje enviado al Arduino: " + (byte)message[0]);
            
        }
        else
        {
            Debug.LogError("Puerto serial no está abierto");
        }
        */  
           
            serialController.SendSerialMessage(data);
            Debug.Log("Mensaje enviado a Arduino "+data);
             
    }
 
    bool comprobarCancion (string igual){
        if(igual.Contains("=")){
            return true;
        } else if (!igual.Contains("=")){
            return false;
        }
 
        return false;
    }
}
 