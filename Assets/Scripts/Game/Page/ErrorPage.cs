using UnityEngine;

public class ErrorPage : MonoBehaviour
{
    GameObject lastPage;

    private void OnEnable()
    {
        GlobalEvents.OnInternetDisconect.AddListener(state =>
        {
            if (state == false)
            {
                GlobalEvents.OnInternetDisconect.RemoveAllListeners();

                OpenLastPage();
            }
        });
    }

    private void OnDisable()
    {
        GlobalEvents.OnInternetDisconect.RemoveListener(state =>
        {
            if (state == false) OpenLastPage();
        });
    }

    public void OpenErrorPage(GameObject page)
    {
        lastPage = page;

        lastPage.SetActive(false);
        gameObject.SetActive(true);
    }

    void OpenLastPage()
    {
        gameObject.SetActive(false);
        lastPage.SetActive(true);
    }
}