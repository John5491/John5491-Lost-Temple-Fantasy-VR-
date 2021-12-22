using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseShield : MonoBehaviour
{
    //public Camera playerCamera;
    public GameObject shield;
    public GameObject healthBarUI;
    public Slider slider;

    public bool useShield = true;
    public float shieldDepletionSpeed = 5f;
    public float shieldRecoverSpeed = 5f;
    public float shieldLevel = 50;
    public bool drawShieldMeter = true;
    public float shieldInternal;

    Image ShieldMeter;
    Image ShieldMeterBG;

    bool isShielding = false;
    float smoothRef;

    private void Start()
    {
        /*if (drawShieldMeter)
        {
            Canvas canvas = new GameObject("AutoMeter").AddComponent<Canvas>();
            canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.pixelPerfect = true;
            canvas.transform.SetParent(playerCamera.transform);
            canvas.transform.position = Vector3.zero;


            ShieldMeterBG = new GameObject("ShieldMeter").AddComponent<Image>();
            ShieldMeter = new GameObject("Meter").AddComponent<Image>();
            ShieldMeter.transform.SetParent(ShieldMeterBG.transform);
            ShieldMeterBG.transform.SetParent(canvas.transform);
            ShieldMeterBG.transform.position = Vector3.zero;
            ShieldMeterBG.rectTransform.anchorMax = new Vector2(0.5f, 0);
            ShieldMeterBG.rectTransform.anchorMin = new Vector2(0.5f, 0);
            ShieldMeterBG.rectTransform.anchoredPosition = new Vector2(0, 15);
            ShieldMeterBG.rectTransform.sizeDelta = new Vector2(250, 6);
            ShieldMeterBG.color = new Color(0, 0, 0, 0);
            ShieldMeter.rectTransform.sizeDelta = new Vector2(250, 6);
            ShieldMeter.color = new Color(0, 0, 0, 0);


        }*/

        shieldInternal = shieldLevel;
    }

    private void Update()
    {
        if (useShield)
        {
            isShielding = shield.activeSelf && shieldInternal > 0;
            if (isShielding)
            {
                shieldInternal -= (shieldDepletionSpeed * 2) * Time.deltaTime;
                if (drawShieldMeter)
                {
                    /*ShieldMeterBG.color = Vector4.MoveTowards(ShieldMeterBG.color, new Vector4(0, 0, 0, 0.5f), 0.15f);
                    ShieldMeter.color = Vector4.MoveTowards(ShieldMeter.color, new Vector4(1, 1, 1, 1), 0.15f);*/
                    healthBarUI.SetActive(true);
                }
            }
            else if ((!shield.activeSelf && shieldInternal < shieldLevel))
            {
                shieldInternal += shieldRecoverSpeed * Time.deltaTime;
            }
            if (drawShieldMeter)
            {
                if (shieldInternal == shieldLevel)
                {
                    /*ShieldMeterBG.color = Vector4.MoveTowards(ShieldMeterBG.color, new Vector4(0, 0, 0, 0), 0.15f);
                    ShieldMeter.color = Vector4.MoveTowards(ShieldMeter.color, new Vector4(1, 1, 1, 0), 0.15f);*/
                    healthBarUI.SetActive(false);
                }
                /*float x = Mathf.Clamp(Mathf.SmoothDamp(ShieldMeter.transform.localScale.x, (shieldInternal / shieldLevel) * ShieldMeterBG.transform.localScale.x, ref smoothRef, (1) * Time.deltaTime, 1), 0.001f, ShieldMeterBG.transform.localScale.x);
                ShieldMeter.transform.localScale = new Vector3(x, 1, 1);*/
                slider.value = shieldInternal / shieldLevel;
            }
            shieldInternal = Mathf.Clamp(shieldInternal, 0, shieldLevel);
        }
        else { isShielding = shield.activeSelf; }
    }
}
