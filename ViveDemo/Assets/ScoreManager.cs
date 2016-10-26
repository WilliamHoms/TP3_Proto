using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int lives = 100;
	public int money = 20;

    public Text moneyText;
    public Text lifeText;

    public void Loselife(int l = 1){
		lives -= 1;
		if (lives <= 0) {
			GameOver ();
		}
	}

	public void GameOver(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

    void Update() {
        moneyText.text = ("Money: " + money.ToString());
        lifeText.text = ("Life: " + lives.ToString());

    }

}


