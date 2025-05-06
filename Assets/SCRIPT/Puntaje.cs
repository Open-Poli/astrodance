using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Puntaje : MonoBehaviour {
	
	public SerialController serialController;
	public TMP_Text myText;

	public string code;
	
	
	 void Start(){
		
		Thread.Sleep(2000);
        myText.text = "";

    }

	
	// Update is called once per frame
	 void Update() {
		  
		      
		     string code = serialController.ReadSerialMessage();
				
				if(!code.Contains( "¡")){
				myText.text = code;
				}		
			
		myText.color = new Color (251f,175f,1f);


	}


}
