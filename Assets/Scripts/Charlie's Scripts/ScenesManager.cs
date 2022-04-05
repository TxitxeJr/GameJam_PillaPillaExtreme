using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ScenesManager : MonoBehaviour
{
    static ScenesManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      //programar condicion de victoria y derrota una vez tengamos las escenas  
    }
    public void ToGameScene()
    {
        SceneManager.LoadScene("Charlie's Scene");
    }


    public void Quit()
    {
        Application.Quit();
    }
















    /*
     private void loseCondition(){
        if(temporizador <=0 && kid.counter <= 4){
                escena de derrota.
            
            }
        
    }

    private void winCondition(){
        if( kid.counter == 4){
                escena de victoria.
            
            }
        
    }


    public void GameScene(){
        
        boton que lleva al juego
    
    
    }

    public void OptionsScene(){
        boton que lleve a opciones

    }

    public void MenuScene(){
        boton que lleve al menu

    }

    public void CreditScene(){
        boton que lleve a los creditos

    }
    */

}