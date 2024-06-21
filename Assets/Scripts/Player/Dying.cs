using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    

public class Dying : MonoBehaviour
{
    // Start is called before the first frame update
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
