using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class coin : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private int countpoint = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "coin")
        {
            countpoint++;
            scoreText.text = "Score: " + countpoint;
            Destroy(other.gameObject);
        }
    }

}
