using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneSwitch(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
