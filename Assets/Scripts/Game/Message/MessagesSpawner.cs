using UnityEngine;
using System.Collections;

public class MessagesSpawner : MonoBehaviour
{
    [SerializeField] MessageDescriptionPanel descriptionPanel;

    [SerializeField] MessagePresenter messagePresenter;

    [SerializeField] Transform bag;

    [SerializeField] float spawnDelay;

    private void OnEnable() => SpawnMessages();

    void ClearBag()
    {
        foreach (Transform child in bag) Destroy(child.gameObject);
    }

    public void SpawnMessages()
    {
        ClearBag();
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        for (int i = 0; i < MessageList.messages.Count; i++)
        {
            MessageList.messages[i].index = i;

            messagePresenter.GetMessageData(MessageList.messages[i]);
            messagePresenter.GetDescriptionPanel(descriptionPanel);

            if (MessageList.messages[i].isRead == true) messagePresenter.ChangeColor(new Color32(255, 255, 255, 107));
            else messagePresenter.ChangeColor(new Color32(115, 116, 187, 107));

            Instantiate(messagePresenter, bag);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}