using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtils : MonoBehaviour
{
    public static void ReloadScene()
    {
        var activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }

    public static void LoadScene(string name) => SceneManager.LoadScene(name);
    public static void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);

}   