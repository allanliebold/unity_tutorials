using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IPlayerEvents
{
    private Image foregroundImage;
    private int targetValue;
    private int actualValue;

    void IPlayerEvents.OnPlayerHurt (int newHealth) {
        if (newHealth < 0) {
            newHealth = 0;
        } else if (newHealth > 100) {
            newHealth = 100;
        }
        targetValue = newHealth;
    }

    void IPlayerEvents.OnPlayerReachedExit (GameObject exit)
    {
    }

    void Update ()
    {
        if (actualValue < targetValue)
        {
            actualValue++;
        } else if (actualValue > targetValue)
        {
            actualValue--;
        }

        if (foregroundImage != null)
        {
            foregroundImage.fillAmount = actualValue / 100f;
        }
    }

    void Awake ()
    {
        foregroundImage = gameObject.GetComponent<Image> ();
    }

    private void Start ()
    {
        actualValue = 100;
        targetValue = 100;
    }
}
