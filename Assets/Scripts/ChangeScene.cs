using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void LoadScene(int i) {
        switch (i) {
            case 1:
                SceneManager.LoadScene("Level_2");
                break;
            case 2:
                SceneManager.LoadScene("Level_3");
                Debug.Log("Hola?");
                break;
            case 3:
                SceneManager.LoadScene("Level_1");
                break;
        }
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
