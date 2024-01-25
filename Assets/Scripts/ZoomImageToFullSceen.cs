using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomImageToFullSceen : MonoBehaviour
{
    private bool isFullscreen;
    private RectTransform rectTransform;
    private Vector2 initialSize;
    private Vector3 initialPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void ToggleFullscreenButtonSizeRectTransform(Canvas canvas)
    {
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();

        if (!isFullscreen)
        {

            initialPosition = rectTransform.position;
            initialSize = rectTransform.sizeDelta;

            rectTransform.sizeDelta = canvasRectTransform.sizeDelta;
            rectTransform.position = canvasRectTransform.position;
        }
        else
        {
            rectTransform.sizeDelta = initialSize;
            rectTransform.position = initialPosition;
        }
        isFullscreen = !isFullscreen;
    }
}
