using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject noHitText;
    [SerializeField] Canvas canvas;
    [SerializeField] Camera camera;

    // Combo
    [SerializeField] GameObject comboGameObject;
    [SerializeField] TMP_Text comboText;
    private bool comboEnabled = false;
    private int comboCounter = 0;
    [SerializeField] ITweenCombo tweenCombo;

    public void UpdateScore(int val)
    {
        if (comboCounter == 0)
        {
            score += val;
        }
        else if (comboCounter > 0)
        {
            score += val * comboCounter;
        }
        scoreText.text = "����: " + score.ToString();
    }

    public void InstantiateNoHitText()
    {
        Vector2 pos = new Vector2(Random.Range(5f, 5.5f), Random.Range(1f, 2f));
        var newText = Instantiate(noHitText, new Vector2(0,0), Quaternion.identity);
        newText.transform.SetParent(canvas.transform, false);
        ConvertWorldSpaceToCanvas(newText.GetComponent<RectTransform>(), pos);
        UpdateComboText(false);
    }

    public void UpdateComboText(bool hit)
    {
        if (!comboEnabled && hit)
        {
            comboCounter++;
            comboGameObject.SetActive(true);
            comboText.text = "׸���";
            comboEnabled = true;
            tweenCombo.PulseEffect();
        }
        else if (comboEnabled && hit)
        {
            comboCounter++;
            if (comboCounter > 5 && comboCounter < 10)
            {
                comboText.text = "�����! �" + comboCounter;
            }
            else if (comboCounter > 10 && comboCounter < 15)
            {
                comboText.text = "����������! �" + comboCounter;
            }
            else if (comboCounter > 15 && comboCounter < 25)
            {
                comboText.text = "���� �����! �" + comboCounter;
            }
            else if (comboCounter > 25 && comboCounter < 50)
            {
                comboText.text = "������ �����! �" + comboCounter;
            }
            else if (comboCounter > 50)
            {
                comboText.text = "0_0 �" + comboCounter;
            }
            tweenCombo.PulseEffect();
        }
        else if (comboEnabled && !hit)
        {
            comboCounter = 0;
            comboGameObject.SetActive(false);
            comboEnabled = false;
        }
    }

    private void ConvertWorldSpaceToCanvas(RectTransform UI_Element, Vector2 pos)
    {
        GameObject WorldObject;
        RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
        Vector2 ViewportPosition = camera.WorldToViewportPoint(pos);
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
        ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        UI_Element.position = WorldObject_ScreenPosition;
    }
}
