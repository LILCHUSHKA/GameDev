using UnityEngine;

public class PlanetCamera : MonoBehaviour
{
    [SerializeField] float slowTimeDistance, maxDistance, minDistance, scrollSpeed = 800;

    [SerializeField] Transform target;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * 600 * Time.deltaTime);
            transform.RotateAround(target.position, -Vector3.right, Input.GetAxis("Mouse Y") * 400 * Time.deltaTime);

            transform.LookAt(target);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            CheckTimeDistance();

            if (Vector3.Distance(transform.position, target.transform.position) <= minDistance)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > -0.1f)
                    scrollSpeed = 0;
                else scrollSpeed = 800;
            }

            if (Vector3.Distance(transform.position, target.transform.position) >= maxDistance)
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0.1f)
                    scrollSpeed = 0;
                else scrollSpeed = 800;
            }

            transform.position += transform.forward * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
    }

    void CheckTimeDistance()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= slowTimeDistance)
            target.GetComponent<CasualPlanetSpin>().SetSpinSpeed(2.5f);

        else target.GetComponent<CasualPlanetSpin>().SetSpinSpeed(30); //Normal speed = 30
    }
}