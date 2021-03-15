using UnityEngine;
using UnityEngine.UI;

public class AdditionalText : MonoBehaviour
{
    public byte rCounter = 0;
    private void OnEnable()
    {
        Calculator.OperationEvent += OperationHappened;
    }

    private void OperationHappened()
    {
        if (Calculator.operation != 'R' && Calculator.operation != 'C')
        {
            GetComponent<Text>().text = $"{Calculator.num1}{Calculator.operation}";
            rCounter = 0;
        }
        else
        {
            if (Calculator.operation == 'R' && rCounter == 0)
            {
                rCounter++;
                GetComponent<Text>().text += $"{Calculator.num2}=";
            }
            if (Calculator.operation == 'C')
            {
                GetComponent<Text>().text = "";
                rCounter = 0;
            }
        }
    }
}
