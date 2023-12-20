using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    [SerializeField] private Blade blade;
    [SerializeField] private Spawner spawner;
    [SerializeField] public GameObject playButton;
    [SerializeField] private int score;


    private void Awake() {

       blade = FindObjectOfType<Blade>();
       spawner = FindObjectOfType<Spawner>(); 
    }

    public void NewGame()
    {
        playButton.SetActive(false);
        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        StartCoroutine(FindObjectOfType<Spawner>().Spawn());

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits){
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs){
            Destroy(bomb.gameObject);
        }
    }

    public void Explode()
    {
        playButton.SetActive(true);
        blade.enabled = false;
        spawner.enabled = false;

        ClearScene();

    }

}
