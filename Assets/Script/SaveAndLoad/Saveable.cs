using UnityEngine;

public interface Saveable{
	object CaptureState();
	void RestoreState(object state);
}
