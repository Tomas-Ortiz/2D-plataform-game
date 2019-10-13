using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    public GameObject Menu;
    public GameObject SettingsPanel;

    private Animator menuAnim;  //animaciones del menú
    private Animator settingsPanelAnim;

    private void Awake()    //solo se llama una vez, al momento de inicializar el objeto
    {
        menuAnim = Menu.GetComponent<Animator>();
        settingsPanelAnim = SettingsPanel.GetComponent<Animator>();
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
        //sacar el menu principal y traer menu de opciones
        menuAnim.SetBool("Close", true);    // parametros para activar las animaciones
        settingsPanelAnim.SetBool("Open", true);
    }

    public void PlayScene() {

        SceneManager.LoadScene("Escenario"); //se cargfa el primer escenario, con 3 vidas
        vidas.lives = 3;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Volver()
    {
        SceneManager.LoadScene("Menu"); //vuelve a cargar el menú
    }

       void Update()
    {
        
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }
}
