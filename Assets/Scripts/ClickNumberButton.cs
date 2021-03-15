using UnityEngine;
using UnityEngine.UI;

public class ClickNumberButton : MonoBehaviour
{
    public Text textField;
    public void OnButtonClicked()
    {
        if (Calculator.operation == 'R')
        {
            textField.text = gameObject.GetComponentInChildren<Text>().text;
            Calculator.operation = '0';
        } else
        {
            if (textField.text[0] == '0')
            {
                if (textField.text.Length >= 2)
                    textField.text += gameObject.GetComponentInChildren<Text>().text;
                else
                {
                    if (gameObject.GetComponentInChildren<Text>().text != "0")
                    {
                        if (textField.text.Length == 1)
                            textField.text = gameObject.GetComponentInChildren<Text>().text;
                        if (textField.text.Length > 1)
                            textField.text += gameObject.GetComponentInChildren<Text>().text;
                    }
                }
            }
            else
            {
                textField.text += gameObject.GetComponentInChildren<Text>().text;
            }
        }
    }


}
