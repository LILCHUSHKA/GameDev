using UnityEngine;

public class CasualPlanetSpin : MonoBehaviour
{
    [SerializeField] GameTime gameTimeData;

    [SerializeField] float spinSpeed = 30; //Normal speed = 30f

    bool isNewDay, canReloadDay;

    void FixedUpdate() => RotatePlanet();

    void RotatePlanet()
    {
        transform.Rotate(-Vector3.up, spinSpeed * Time.deltaTime);

        if (transform.rotation.eulerAngles.y < 180 && isNewDay) HandleDate();
        if (transform.rotation.eulerAngles.y > 180 && canReloadDay)
        {
            isNewDay = true;
            canReloadDay = false;
        }
    }

    void HandleDate()
    {
        gameTimeData.ChangeDate();

        isNewDay = false;
        canReloadDay = true;
    }

    public void SetSpinSpeed(float newSpeed) => spinSpeed = newSpeed;
}