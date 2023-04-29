using UnityEngine;
using UnityEngine.UI;

public class KeyConfig : MonoBehaviour
{
    public Button jumpButton;
    public Button leftButton;
    public Button rightButton;

    private KeyCode jumpKey;
    private KeyCode leftKey;
    private KeyCode rightKey;

    private void Start()
    {
        // Chargez les touches associées à chaque action depuis les PlayerPrefs (ou une autre source persistante)
        jumpKey = (KeyCode)PlayerPrefs.GetInt("JumpKey", (int)KeyCode.Space);
        leftKey = (KeyCode)PlayerPrefs.GetInt("LeftKey", (int)KeyCode.LeftArrow);
        rightKey = (KeyCode)PlayerPrefs.GetInt("RightKey", (int)KeyCode.RightArrow);

        // Mettez à jour le texte des boutons avec les touches actuellement assignées
        jumpButton.GetComponentInChildren<Text>().text = jumpKey.ToString();
        leftButton.GetComponentInChildren<Text>().text = leftKey.ToString();
        rightButton.GetComponentInChildren<Text>().text = rightKey.ToString();
    }

    public void SetJumpKey()
    {
        if (Input.anyKeyDown)
        {
            jumpKey = GetKeyCodeFromInput();
            jumpButton.GetComponentInChildren<Text>().text = jumpKey.ToString();
            PlayerPrefs.SetInt("JumpKey", (int)jumpKey);
        }
    }

    public void SetLeftKey()
    {
        if (Input.anyKeyDown)
        {
            leftKey = GetKeyCodeFromInput();
            leftButton.GetComponentInChildren<Text>().text = leftKey.ToString();
            PlayerPrefs.SetInt("LeftKey", (int)leftKey);
        }
    }

    public void SetRightKey()
    {
        if (Input.anyKeyDown)
        {
            rightKey = GetKeyCodeFromInput();
            rightButton.GetComponentInChildren<Text>().text = rightKey.ToString();
            PlayerPrefs.SetInt("RightKey", (int)rightKey);
        }
    }

    private KeyCode GetKeyCodeFromInput()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(keyCode))
            {
                return keyCode;
            }
        }
        return KeyCode.None;
    }
}
