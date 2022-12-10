using UnityEngine;

public class Page : MonoBehaviour
{
    [SerializeField] ErrorPage errorPage;

    [SerializeField] GameObject page;

    private void OnEnable()
    {
        GlobalEvents.OnInternetDisconect.AddListener(state =>
        {
            if (state == true) errorPage.OpenErrorPage(gameObject);
        });
    }

    private void OnDisable()
    {
        GlobalEvents.OnInternetDisconect.RemoveListener(state =>
        {
            if (state == true) errorPage.OpenErrorPage(gameObject);
        });
    }

    public void SetPage(GameObject openedPage) => page = openedPage;

    public void ReloadPage()
    {
        page.SetActive(false);
        page.SetActive(true);
    }
}