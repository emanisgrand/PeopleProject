
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Interaction : MonoBehaviour
{
    public static Vector3 hitPoint;
    public static event System.Action<Object> OnClick3D;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { Interact(); }
    }
    
    public void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, 100f);

            List<RaycastHit> hitList = hits.ToList();
            
            hitList = hitList.OrderBy(x 
                => Vector3.Distance(Camera.main.transform.position, x.point)).ToList();

            foreach (RaycastHit hit in hitList)
            {
                if (hit.collider.gameObject.GetComponent<Employee>() != null)
                {
                    OnClick3D?.Invoke(hit.collider.gameObject);
                    break;
                }
                
                if (hit.collider.gameObject.GetComponent<OfficeObject>() != null)
                {
                    OnClick3D?.Invoke(hit.collider.gameObject);
                    break;
                }
                
                if (hit.collider.gameObject.GetComponent<WalkableFloor>() != null)
                {
                    hitPoint = hit.point;   
                    OnClick3D?.Invoke(hit.collider.gameObject);
                    break;
                }
            }
        }
    }
}
