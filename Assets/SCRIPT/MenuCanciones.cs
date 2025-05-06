
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Collections.Generic;
using System.Threading;


public class MenuCanciones : MonoBehaviour
{
    SerialPort serialPort = new SerialPort ("/dev/ttyUSB0", 9600);// en COM3, va el COM donde esta conectada la placa de Unity
    public Button luisMi;
    public Button beeGees;
    public Button redBone;
    private ArrayList buttons = new ArrayList();
    Vector3 coordenadas0 = new Vector3();
    public Transform miTransform;
  
    
 
    // Modifica esta variable según cuánto quieres incrementar el tamaño al presionar la flecha
    private int i = 1;
    private float incrementAmount = 10f;
 
    void Start() {
        
        coordenadas0 = miTransform.position;
      
    
        serialPort.Open();
        serialPort.ReadTimeout = 1;
        buttons.Add(beeGees);
        buttons.Add(luisMi);     
        buttons.Add(redBone);
    }
 
    void Update()
    {

        
            ((Button)buttons[i]).transform.SetPositionAndRotation(coordenadas0, new Quaternion());

            if(i==0){
                 ((Button)buttons[i]).transform.SetPositionAndRotation(coordenadas0, new Quaternion());
                 ((Button)buttons[i+2]).transform.SetPositionAndRotation(new Vector2(coordenadas0.x-170, coordenadas0.y-40), new Quaternion());
                ((Button)buttons[i+1]).transform.SetPositionAndRotation(new Vector2(coordenadas0.x+170, coordenadas0.y-40), new Quaternion());

            }
             if(i==1){
                 ((Button)buttons[i]).transform.SetPositionAndRotation(coordenadas0, new Quaternion());
                 ((Button)buttons[i-1]).transform.SetPositionAndRotation(new Vector2(coordenadas0.x-170, coordenadas0.y-40), new Quaternion());
                ((Button)buttons[i+1]).transform.SetPositionAndRotation(new Vector2(coordenadas0.x+170, coordenadas0.y-40), new Quaternion());

            }
             if(i==2){
                 ((Button)buttons[i]).transform.SetPositionAndRotation(coordenadas0, new Quaternion());
                 ((Button)buttons[i-1]).transform.SetPositionAndRotation(new Vector2(coordenadas0.x-170, coordenadas0.y-40), new Quaternion());
                ((Button)buttons[i-2]).transform.SetPositionAndRotation(new Vector2(coordenadas0.x+170, coordenadas0.y-40), new Quaternion());

            }

        
        serialPort.Open();
        serialPort.ReadTimeout = 1;
       
        if(serialPort.IsOpen){
         int serial = serialPort.ReadByte();
        Debug.Log(serial);
        if (Input.GetKeyDown(KeyCode.LeftArrow) && i>0)
        {
            ResizeButton2((Button)buttons[i]);
            i--;
            ResizeButton((Button)buttons[i]);
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && i<2 )
        {
            ResizeButton2((Button)buttons[i]);
            i++;
            ResizeButton((Button)buttons[i]);
        }else if(Input.GetKeyDown(KeyCode.RightArrow) && i==2){
            ResizeButton2((Button)buttons[i]);
            i=0;
            ResizeButton((Button)buttons[i]);
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && i==0){
            ResizeButton2((Button)buttons[i]);
            i=2;
            ResizeButton((Button)buttons[i]);
        } 
        else if ( serial == 7)
        {
            if (i == 1)
            {
                luisMi.onClick.Invoke();
                
            }
              if (i == 0)
            {
                beeGees.onClick.Invoke();
            }
              if (i == 2)
            {
                redBone.onClick.Invoke();
            }
        }
         
        }
                
 
     
 
        
 
 
    }
 
    void ResizeButton(Button button)
    {
        RectTransform rt = button.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x + incrementAmount, rt.sizeDelta.y + incrementAmount);
    }
 
    void ResizeButton2(Button button)
    {
        RectTransform rt = button.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x - incrementAmount, rt.sizeDelta.y - incrementAmount);
    }
}
 
 
 