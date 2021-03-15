using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;



public class Calculator : MonoBehaviour
{

    public Button[] operationButtons;
    public static float num1, num2, result;
    string input;
    public static char operation;

    public static event Action OperationEvent;
    
    private void Awake()
    {
        operationButtons[0].onClick.AddListener(Add);
        operationButtons[1].onClick.AddListener(Sub);
        operationButtons[2].onClick.AddListener(Mult);
        operationButtons[3].onClick.AddListener(Div);
        operationButtons[4].onClick.AddListener(Result);
        operationButtons[5].onClick.AddListener(Cancel);
        operationButtons[6].onClick.AddListener(FloatEnter);
    }

    void Start()
    {
        num1 = num2 = 0.0f;
        input = "";
        GetComponent<Text>().text = "0";
        operation = '0';
    }

    private void Add()
    {
        operation = '+';
        num1 = AssignNumber(num1, input);
        OperationEvent?.Invoke();
        GetComponent<Text>().text = "0";
    }

    private void Sub()
    {
        operation = '-';
        num1 = AssignNumber(num1, input);
        OperationEvent?.Invoke();
        GetComponent<Text>().text = "0";
    }

    private void Mult()
    {
        operation = '*';
        num1 = AssignNumber(num1, input);
        OperationEvent?.Invoke();
        GetComponent<Text>().text = "0";
    }

    private void Div()
    {
        operation = '/';
        num1 = AssignNumber(num1, input);
        OperationEvent?.Invoke();
        GetComponent<Text>().text = "0";
    }

    private void Result()
    {
        if (operation == 'R' || operation == '0' || operation == 'C')
            return;

        num2 = AssignNumber(num2, input);
        switch (operation)
        {
            case '+':
                result = num1 + num2;
                goto default;
            case '-':
                result = num1 - num2;
                goto default;
            case '*':
                result = num1 * num2;
                goto default;
            case '/':
                result = num1 / num2;
                goto default;
            default:
                operation = 'R';
                break;
        }

        OperationEvent?.Invoke();
        num2 = 0;
        GetComponent<Text>().text = result.ToString();
    }

    private void Cancel()
    {
        num1 = num2 = result = 0.0f;
        operation = 'C';
        OperationEvent?.Invoke();
        GetComponent<Text>().text = "0";
    }

    float AssignNumber(float num, string value)
    {
        value = GetComponent<Text>().text;
        if (value.Any(ch => char.IsLetter(ch)))
            return 0.0f;

        if (value == "0" && num2 == 0)
            return num;
        else
        {
            num = float.Parse(value, CultureInfo.InvariantCulture);
            return num ;
        }
    }

    private void FloatEnter()
    {
        if (!GetComponent<Text>().text.Contains(".") && operation != 'R')
            GetComponent<Text>().text += ".";
    }
}
