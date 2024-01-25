using TMPro;
using UnityEngine;

public class ChangeTextBtn : MonoBehaviour
{
    [SerializeField] TMP_Text textArea;

    public void ChangeTxtBtn()
    {

        textArea.text = gameObject.GetComponentInChildren<TMP_Text>().text;

    }
}
