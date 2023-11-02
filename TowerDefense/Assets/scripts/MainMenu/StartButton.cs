using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlaceOffering(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
