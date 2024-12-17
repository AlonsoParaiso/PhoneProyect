using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdDisplayManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public static AdDisplayManager instance;
    public string unityAdsId;
    public int androidID, appleID;
    public bool test = true;
    public string adType = "Banner_Android";
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(adType, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log(error);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        SceneManager.LoadScene("Play");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }
    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }



    // Start is called before the first frame update
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (!Advertisement.isInitialized)
        {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR || UNITY_ANDROID 
            Advertisement.Initialize(adType, test, this);
#elif UNITY_IOS
            Advertisement.Initielize(appleID.ToString(), test, this);
#endif
        }
    }

    public void ShowAD()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(adType, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
