#include <ArrayList.h>

#include <Adafruit_NeoPixel.h>

#define pin_tira_principal 12 //pin tira led principal
#define cant_leds_tira_principal 60 //cant total leds tira principal 60
#define cant_leds_flechas 31 //cant total leds flechas 31

#define pin_flecha_azul1 11
#define pin_flecha_roja1 10
#define pin_flecha_naranja1 9
#define pin_flecha_verde1 8

#define pin_flecha_azul2 5
#define pin_flecha_roja2 7
#define pin_flecha_naranja2 4
#define pin_flecha_verde2 6

#define pinArriba1 43
#define pinDerecha1 45
#define pinIzquierda1 47
#define pinAbajo1 49

#define pinArriba2 31
#define pinDerecha2 33
#define pinIzquierda2 35
#define pinAbajo2 37

Adafruit_NeoPixel tira_principal(cant_leds_tira_principal, pin_tira_principal, NEO_GRB + NEO_KHZ800);

Adafruit_NeoPixel flecha_azul1(cant_leds_flechas, pin_flecha_azul1, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel flecha_roja1(cant_leds_flechas, pin_flecha_roja1, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel flecha_naranja1(cant_leds_flechas, pin_flecha_naranja1, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel flecha_verde1(cant_leds_flechas, pin_flecha_verde1, NEO_GRB + NEO_KHZ800);

Adafruit_NeoPixel flecha_azul2(cant_leds_flechas, pin_flecha_azul2, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel flecha_roja2(cant_leds_flechas, pin_flecha_roja2, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel flecha_naranja2(cant_leds_flechas, pin_flecha_naranja2, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel flecha_verde2(cant_leds_flechas, pin_flecha_verde2, NEO_GRB + NEO_KHZ800);

uint32_t N = tira_principal.Color (255,0,60);
uint32_t A = tira_principal.Color (0,255,60);
uint32_t V = tira_principal.Color (0,100,255);
uint32_t R = tira_principal.Color (255,0,0);
uint32_t ES = tira_principal.Color (0,0,0);

uint32_t NF = tira_principal.Color (255,60,0);
uint32_t AF = tira_principal.Color (0,60,255);
uint32_t VF = tira_principal.Color (0,255,100);
uint32_t RF = tira_principal.Color (255,0,0);

//parte flechas inicio
/*
void prenderFlechas(uint32_t color){
  if(color==A){
    for(int i = 0; i<cant_leds_flechas; i++){
      flecha_azul.setPixelColor(i, AF);
      delay(100);
      flecha_azul.show(); 
    }
      flecha_azul.fill(ES, 0, cant_leds_flechas);;
      flecha_azul.show();
  }else if(color==R){
    for(int i = 0; i<cant_leds_flechas; i++){
      flecha_roja.setPixelColor(i, RF);
      delay(100);
      flecha_roja.show(); 
    }
      flecha_roja.fill(ES, 0, cant_leds_flechas);;
      flecha_roja.show();
  }else if(color==N){
    for(int i = 0; i<cant_leds_flechas; i++){
      flecha_naranja.setPixelColor(i, NF);
      delay(100);
      flecha_naranja.show(); 
    }
      flecha_naranja.fill(ES, 0, cant_leds_flechas);;
      flecha_naranja.show();
  }else{
    for(int i = 0; i<cant_leds_flechas; i++){
      flecha_verde.setPixelColor(i, VF);
      delay(100);
      flecha_verde.show(); 
    }
      flecha_verde.fill(ES, 0, cant_leds_flechas);;
      flecha_verde.show();
  }
}
*/
    //parte flechas fin

void setup() {
  tira_principal.begin();
  tira_principal.show();
  tira_principal.setBrightness(127);

  flecha_azul1.begin();
  flecha_azul1.show();
  flecha_azul1.setBrightness(127);
  flecha_roja1.begin();
  flecha_roja1.show();
  flecha_roja1.setBrightness(127);
  flecha_naranja1.begin();
  flecha_naranja1.show();
  flecha_naranja1.setBrightness(127);
  flecha_verde1.begin();
  flecha_verde1.show();
  flecha_verde1.setBrightness(127);

  flecha_azul2.begin();
  flecha_azul2.show();
  flecha_azul2.setBrightness(127);
  flecha_roja2.begin();
  flecha_roja2.show();
  flecha_roja2.setBrightness(127);
  flecha_naranja2.begin();
  flecha_naranja2.show();
  flecha_naranja2.setBrightness(127);
  flecha_verde2.begin();
  flecha_verde2.show();
  flecha_verde2.setBrightness(127);

  pinMode(pinArriba1, INPUT_PULLUP);
  pinMode(pinDerecha1, INPUT_PULLUP);
  pinMode(pinIzquierda1, INPUT_PULLUP);
  pinMode(pinAbajo1, INPUT_PULLUP);

  pinMode(pinArriba2, INPUT_PULLUP);
  pinMode(pinDerecha2, INPUT_PULLUP);
  pinMode(pinIzquierda2, INPUT_PULLUP);
  pinMode(pinAbajo2, INPUT_PULLUP);

  Serial.begin(9600);

  tira_principal.setPixelColor(0, R);
  tira_principal.show();
  R = tira_principal.getPixelColor(0);

  tira_principal.setPixelColor(0, A);
  tira_principal.show();
  A = tira_principal.getPixelColor(0);

  tira_principal.setPixelColor(0, V);
  tira_principal.show();
  V = tira_principal.getPixelColor(0);

  tira_principal.setPixelColor(0, N);
  tira_principal.show();
  N = tira_principal.getPixelColor(0);


  tira_principal.setPixelColor(0, RF);
  tira_principal.show();
  RF = tira_principal.getPixelColor(0);

  tira_principal.setPixelColor(0, AF);
  tira_principal.show();
  AF = tira_principal.getPixelColor(0);

  tira_principal.setPixelColor(0, VF);
  tira_principal.show();
  VF = tira_principal.getPixelColor(0);

  tira_principal.setPixelColor(0, NF);
  tira_principal.show();
  NF = tira_principal.getPixelColor(0);

  tira_principal.begin();
  tira_principal.show();
}
void empezarJuego(int velocidad){
  int puntajeJugador1 = 0;
  int puntajeJugador2 = 0;
  int inicio = 0;
  
  ArrayList<uint32_t>secuenciaLeds;
  for (int i=0;i<20;i++){
    secuenciaLeds.add(R);
    secuenciaLeds.add(A);
    secuenciaLeds.add(V);
    secuenciaLeds.add(R);
    secuenciaLeds.add(N);
    secuenciaLeds.add(R);
    secuenciaLeds.add(A);
    secuenciaLeds.add(N);
    secuenciaLeds.add(R);
    secuenciaLeds.add(V);
  }
  //  A,N,R,V,ES,A,N,ES,R,V,A,R,N,V,ES,A,N,R,V,ES,N,A,ES,V,R,N,R,A,V,ES,R,A,N,ES,V,R,V,N, A, ES,V, N, A, R, ES,V, A, R, N, ES,ES, A, N, R, V,ES, N, A, V, R,A, R, ES, N, V,A, V, R, ES, N,ES, R,A, N, V,N, ES, R, A, V,N, V, R, ES, A,ES, V, A, N, R,V, N, ES, R, A,V, R, ES, A, N, R, ES, N, A, V
  for(int i = 0; i < 61; i++){
    secuenciaLeds.add(ES);
  }

  unsigned long int millisant=0;
  unsigned long int millisflechasant=0;
  unsigned long int millischequeoant=0;
  
  bool activaFlechaAzul=false;
  bool activaFlechaRoja=false;
  bool activaFlechaNaranja=false;
  bool activaFlechaVerde=false;

  int posicionFlechaAzul=0;
  int posicionFlechaRoja=0;
  int posicionFlechaNaranja=0;
  int posicionFlechaVerde=0;

  bool esperandoFlechaAzul1=false;
  bool esperandoFlechaRoja1=false;
  bool esperandoFlechaNaranja1=false;
  bool esperandoFlechaVerde1=false;

  bool esperandoFlechaAzul2=false;
  bool esperandoFlechaRoja2=false;
  bool esperandoFlechaNaranja2=false;
  bool esperandoFlechaVerde2=false;

  int n=0;
  while(n < secuenciaLeds.size())
  {
    Serial.println(puntajeJugador1);
    Serial.println(puntajeJugador2);
    if (millis()-millisant>velocidad)
    {
      if(n>60){
        inicio = n-60;
      }
      tira_principal.fill(ES, 0, cant_leds_tira_principal-1);
      
      for(int i = n; i>=0; i--){
        tira_principal.setPixelColor(n-i, secuenciaLeds.get(i)); 
      }
      tira_principal.show();
      n++;

      //inicio activacion flechas
      if(tira_principal.getPixelColor(59)==A){
        activaFlechaAzul=true;

        esperandoFlechaAzul1=true;

        posicionFlechaAzul=0;

        esperandoFlechaAzul2=true;
      }else if(tira_principal.getPixelColor(59)==R){
        activaFlechaRoja=true;

        esperandoFlechaRoja1=true;

        posicionFlechaRoja=0;

        esperandoFlechaRoja2=true;
      }else if(tira_principal.getPixelColor(59)==N){
        activaFlechaNaranja=true;

        esperandoFlechaNaranja1=true;

        posicionFlechaNaranja=0;

        esperandoFlechaNaranja2=true;
      }else if(tira_principal.getPixelColor(59)==V){
        activaFlechaVerde=true;

        esperandoFlechaVerde1=true;

        posicionFlechaVerde=0;

        esperandoFlechaVerde2=true;
      }
      millisant=millis();
    }
    //fin activacion flechas


    //inicio encender flechas
    if (millis()-millisflechasant>velocidad/31)
    {
      millisflechasant=millis();
      if(activaFlechaAzul){
        flecha_azul1.setPixelColor(posicionFlechaAzul, AF);
        flecha_azul1.show();
        flecha_azul2.setPixelColor(posicionFlechaAzul, AF);
        flecha_azul2.show();
        if(posicionFlechaAzul>cant_leds_flechas)
        {
          flecha_azul1.fill(ES, 0, cant_leds_flechas);
          flecha_azul1.show();
          flecha_azul2.fill(ES, 0, cant_leds_flechas);
          flecha_azul2.show();
          activaFlechaAzul=false;
          esperandoFlechaAzul1=false;
          esperandoFlechaAzul2=false;
        }
        posicionFlechaAzul++;
      }
      if(activaFlechaRoja){
        flecha_roja1.setPixelColor(posicionFlechaRoja, RF);
        flecha_roja1.show(); 
        flecha_roja2.setPixelColor(posicionFlechaRoja, RF);
        flecha_roja2.show(); 
        if(posicionFlechaRoja>cant_leds_flechas)
        {
          flecha_roja1.fill(ES, 0, cant_leds_flechas);;
          flecha_roja1.show();
          flecha_roja2.fill(ES, 0, cant_leds_flechas);;
          flecha_roja2.show();
          activaFlechaRoja=false;
          esperandoFlechaRoja1=false;
          esperandoFlechaRoja2=false;
        }
        posicionFlechaRoja++;
        
      }
      if(activaFlechaNaranja){
        flecha_naranja1.setPixelColor(posicionFlechaNaranja, NF);
        flecha_naranja1.show(); 
        flecha_naranja2.setPixelColor(posicionFlechaNaranja, NF);
        flecha_naranja2.show(); 
        if(posicionFlechaNaranja>cant_leds_flechas)
        {
          flecha_naranja1.fill(ES, 0, cant_leds_flechas);;
          flecha_naranja1.show();
          flecha_naranja2.fill(ES, 0, cant_leds_flechas);;
          flecha_naranja2.show();
          activaFlechaNaranja=false;
          esperandoFlechaNaranja1=false;
          esperandoFlechaNaranja2=false;
        }
        posicionFlechaNaranja++;
      }
      if(activaFlechaVerde){
        flecha_verde1.setPixelColor(posicionFlechaVerde, VF);
        flecha_verde1.show(); 
        flecha_verde2.setPixelColor(posicionFlechaVerde, VF);
        flecha_verde2.show(); 
        if(posicionFlechaVerde>cant_leds_flechas)
        {
          flecha_verde1.fill(ES, 0, cant_leds_flechas);;
          flecha_verde1.show();
          flecha_verde2.fill(ES, 0, cant_leds_flechas);;
          flecha_verde2.show();
          activaFlechaVerde=false;
          esperandoFlechaVerde1=false;
          esperandoFlechaVerde2=false;
        }
        posicionFlechaVerde++;
      }
    }
    //fin encender flechas


    if (millis()-millischequeoant>100)
    {
      millischequeoant=millis();
      if((digitalRead(pinIzquierda1)==LOW) && esperandoFlechaAzul1){
        puntajeJugador1++;
        esperandoFlechaAzul1=false;
      }

      if((digitalRead(pinIzquierda2)==LOW) && esperandoFlechaAzul2){
        puntajeJugador2++;
        esperandoFlechaAzul2=false;
      }

      if((digitalRead(pinAbajo1)==LOW) && esperandoFlechaRoja1){
        puntajeJugador1++;
        esperandoFlechaRoja1=false;
      }

      if((digitalRead(pinAbajo2)==LOW) && esperandoFlechaRoja2){
        puntajeJugador2++;
        esperandoFlechaRoja2=false;
      }

      if((digitalRead(pinArriba1)==LOW) && esperandoFlechaNaranja1){
        puntajeJugador1++;
        esperandoFlechaNaranja1=false;
      }

      if((digitalRead(pinArriba2)==LOW) && esperandoFlechaNaranja2){
        puntajeJugador2++;
        esperandoFlechaNaranja2=false;
      }

      if((digitalRead(pinDerecha1)==LOW) && esperandoFlechaVerde1){
        puntajeJugador1++;
        esperandoFlechaVerde1=false;
      }

      if((digitalRead(pinDerecha2)==LOW) && esperandoFlechaVerde2){
        puntajeJugador2++;
        esperandoFlechaVerde2=false;
      }

    }
  }
  
}

void loop() {
  empezarJuego(600);
  
}

