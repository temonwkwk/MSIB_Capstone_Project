using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[ExecuteInEditMode]
public class CinemachineBrainTimelineBinder : MonoBehaviour
{
    void Start()
    {
        var mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No main camera available to get Cinemachine brain from.");
            return;
        }

        var brain = mainCamera.GetComponent<CinemachineBrain>();
        var director = GetComponent<PlayableDirector>();
        var timeline = director.playableAsset as TimelineAsset;

        if (timeline == null)
        {
            return;
        }

        var cinemachineTracks = timeline
            .GetOutputTracks()
            .Select(track => track as CinemachineTrack)
            .Where(track => track != null);

        foreach (var track in cinemachineTracks)
        {
            director.SetGenericBinding(track, brain);
        }
    }
}