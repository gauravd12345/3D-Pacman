using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public TMP_InputField scoreText;

    public GameObject inputField;

    public bool powerPellet = false;

    public int score = 0;
    

    void Start() {

    }

    // Update is called once per frame
    public void OnCollision(Collision collision) {
        if (collision.gameObject.name == "Food") {
            // Destroy(collision.gameObject);
            score += 10;
            scoreText.text = "Score: " + score;
        }

        if (collision.gameObject.name == "Ghost") {
            if (powerPellet) {
                score += 200;
                scoreText.text = "Score: " + score;
            }
        }

        if (collision.gameObject.name == "Powerup") {
            // Destroy(collision.gameObject);
            score += 50;
            scoreText.text = "Score: " + score;
        }
    }
}
