using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBorder : BorderBase
{
    public MathOperation operation;
    public int value;

    [SerializeField] GameObject border;
    [SerializeField] TMPro.TMP_Text borderText;

    private void Awake()
    {
        TextSetter(operation, value, borderText, border);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            DoSomeMath(operation, value);

        }
    }
}
