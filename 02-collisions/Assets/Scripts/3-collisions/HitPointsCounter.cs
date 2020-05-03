using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitPointsCounter : MonoBehaviour
{
    private TextMeshPro textField;
    private int number = 3;
    void Start()
    {
        textField = GetComponent<TextMeshPro>();
        if (!textField)
            throw new MissingComponentException("Object must contain a TextMeshPro field!");
    }

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int newNumber)
    {
        this.number = newNumber;
        this.textField.text = newNumber.ToString();
    }
}
