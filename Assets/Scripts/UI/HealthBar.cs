using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthBar;
    private Image healthImage;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Gradient colorGradient;
    [SerializeField] private bool useGradient;
    private IHealthHandler healthHandler;
    private BasicStats stats;

    private void Start()
    {
        healthImage = healthBar.GetComponent<Image>();
        stats = GetComponent<BasicStats>();
        stats.onValueChanged.AddListener(RefreshBar);
        healthHandler = GetComponent<IHealthHandler>();
        RefreshBar();
    }
    public void RefreshBar()
    {
        float currHealth = healthHandler.GetCurrentHealth();
        float initialHealth = healthHandler.GetInitialHealth();
        float scale = currHealth / initialHealth;
        healthBar.localScale = new(scale, 1, 1);
        if (useGradient)
        {
            healthImage.color = colorGradient.Evaluate(scale);
        }
        if (healthText != null)
        {
            healthText.text = currHealth.AsRoundStr() + " / " + initialHealth.AsRoundStr();
        }
    }
}
