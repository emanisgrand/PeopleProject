
using UnityEngine;

enum DoorState { Open, Animating, Closed }

public class AnimateDoor : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;

    float duration = 0.5f;
    
    DoorState doorstate = DoorState.Closed;
    
    Quaternion closedDoor;
    Quaternion openDoor;

    private void Awake()
    {
        closedDoor = transform.rotation;
        openDoor = closedDoor * Quaternion.Euler(0, -100, 0);
    }

  void OnTriggerEnter(Collider other) 
  {
      if (other.CompareTag("Player") && doorstate != DoorState.Animating)
      {
          StartCoroutine(DoorEnum (doorstate==DoorState.Open?DoorState.Closed:DoorState.Open));
      }
  }

  System.Collections.IEnumerator DoorEnum( DoorState nextState)
  {
      float time = 0.0f;
      Quaternion startingState;
      startingState = (nextState == DoorState.Open) ? closedDoor : openDoor;
      Quaternion endingState;
      endingState = (nextState == DoorState.Open) ? openDoor : closedDoor;
      
      while (time <= duration)
      {
          float t = time / duration;
          
          transform.rotation = Quaternion.Slerp(
              closedDoor, 
              openDoor,
              curve.Evaluate(t));

          time += Time.deltaTime;
          yield return null;
      }
  }
  
}
