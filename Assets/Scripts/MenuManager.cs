using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("Jeu"); 
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits"); 
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu"); 
    }


    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Quitter le jeu");
    }
}
