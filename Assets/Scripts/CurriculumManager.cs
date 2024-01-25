using UnityEngine;

public class CurriculumManager : MonoBehaviour
{
    private string emailAddress = "sergireb2010@hotmail.com";
    private string subject = "Quiero contratarte";

    public void SubmitMailToHireUp()
    {
        string emailOrder = "mailto:" + emailAddress + "?subject=" + subject;
        Application.OpenURL(emailOrder);
    }
}
