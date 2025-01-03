using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Image resultIcon;
    [SerializeField] private Color colorSuccess;
    [SerializeField] private Color colorFailed;
    [SerializeField] private Sprite spriteSuccess;
    [SerializeField] private Sprite spriteFailed;

    private const string POPUP = "Popup";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;

        Hide();
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        animator.SetTrigger(POPUP);

        background.color = colorSuccess;
        resultText.text = "DELIVERY\nSUCCESS";
        resultIcon.sprite = spriteSuccess;

        Show();
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        animator.SetTrigger(POPUP);

        background.color = colorFailed;
        resultText.text = "DELIVERY\nFAILED";
        resultIcon.sprite = spriteFailed;

        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
