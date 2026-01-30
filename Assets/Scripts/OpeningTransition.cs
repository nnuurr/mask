using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningTransition : MonoBehaviour
{
    [SerializeField] private GameObject glass;
    [SerializeField] private CanvasGroup whitePanel;
    [SerializeField] private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(glass.activeSelf)
        {
            whitePanel.alpha += Time.deltaTime * 2;
            cam.backgroundColor = Color.white;
        }

        if (whitePanel.alpha >= 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
