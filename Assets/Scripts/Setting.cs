using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public VerticalLayoutGroup settingMenu;
    RectTransform settingIcon;

    private void Start()
    {
        settingIcon = this.transform.GetChild(0).GetComponent<RectTransform>();
    }

    bool isAppear = false;
    public void SettingBtn()
    {
        if (!isAppear)
            isAppear = true;
            
        else if (isAppear)
            isAppear = false;

        StartCoroutine(SettingCoroutine(isAppear));
    }

    IEnumerator SettingCoroutine(bool _isAppear)
    {
        float timer = 0;

        while (timer < 1)
        {
            float[] z = new float[2];
            float[] spacing = { 0, 0 };
            float[] top = { 0, 0 };

            if (_isAppear)
            {
                z[0] = 0f; z[1] = 180f;
                spacing[0] = -200f; spacing[1] = -385f;
                top[0] = 0f; top[1] = 550f;
            }
            else if (!_isAppear)
            {
                z[0] = 180f; z[1] = 0f;
                spacing[0] = -385f; spacing[1] = -200f;
                top[0] = 550f; top[1] = 0f;
            }

            timer += 0.05f;
            settingIcon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(z[0], z[1], timer));

            settingMenu.spacing = (int)Mathf.Lerp(spacing[0], spacing[1], timer);
            settingMenu.padding.top = (int)Mathf.Lerp(top[0], top[1], timer);
            yield return new WaitForSeconds(0.01f);
        }
        
    }
}
