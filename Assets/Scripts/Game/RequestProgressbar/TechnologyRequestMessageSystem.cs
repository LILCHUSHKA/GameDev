using UnityEngine;

public class TechnologyRequestMessageSystem : MonoBehaviour
{
    private void Start() =>
        GlobalEvents.OnEngineUpdate.AddListener(SendMessage);

    void SendMessage() => 
        MessageList.AddMessage("Engine", 
            "Hi boss, engine update completed successfully. Now you can start creating new masterpieces.", 
            "Manager");
}