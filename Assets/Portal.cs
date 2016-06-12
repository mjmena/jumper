using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    public string scene;

    public void OnTriggerEnter(Collider c)
    {
        Debug.Log("Loading Scene: " + scene);

        SceneManager.LoadSceneAsync(scene);

    }
}
