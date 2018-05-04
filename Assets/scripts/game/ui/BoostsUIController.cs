using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BoostsUIController : UIBase
{
    [SerializeField]
    Button m_showMenuBtn;

    [SerializeField]
    Button m_showAdvertBtn;

    [SerializeField]
    Button m_closeBoostsBtn;

    [SerializeField]
    Button m_buyTwoTimesBoost;

    const string BOOST_BUTTON_ADVERT_ID = "boostAdvert";

    protected override void Awake()
    {
        Advertisement.Initialize("PorkCorp");

        m_showAdvertBtn.onClick.AddListener(OnShowAdvert);
        m_closeBoostsBtn.onClick.AddListener(OnHideBoostsMenu);
        m_buyTwoTimesBoost.onClick.AddListener(OnBuyBoost);

        this.gameObject.SetActive(false);
    }

    public void OnHideBoostsMenu()
    {
        OnSetUI(false);
    }

    public void OnShowAdvert()
    {
        if(!Advertisement.IsReady())
        {
            Debug.Log("Advert isn't ready. Not running...");
            return;
        }

        Debug.Log("Running advert");
        ShowOptions options = new ShowOptions();
        options.resultCallback = OnFinishedAdvert;
        Advertisement.Show(BOOST_BUTTON_ADVERT_ID, options);
    }

    private void OnFinishedAdvert(ShowResult result)
    {
        if(result == ShowResult.Finished)
        {
            Debug.Log("Finished Advert successfully");
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Editor advert");
#else
            Debug.Log("User skipped or ad failed");
#endif
        }
    }

    public void OnBuyBoost()
    {
        //if (false)
        //{
        //    Debug.Log("Unable to buy boost. Don't have enough special currency");
        //    return;
        //}
        throw new NotImplementedException();
    }
}
