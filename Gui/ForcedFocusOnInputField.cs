using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForcedFocusOnInputField : MonoBehaviour
{
    InputField field;
	
	void Start () {
        field = gameObject.GetComponent<InputField>();
	}
	
	void Update () {
        if (!field.isFocused)
            field.Select();
	}
}
