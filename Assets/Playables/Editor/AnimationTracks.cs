using System;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEditor.UIElements;
using UnityEngine.Diagnostics;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

namespace AltSalt.Maestro.Animation
{
    public class AnimationTracks : EditorWindow
    {
        // [MenuItem("Tools/Maestro/Control Panel")]
        // public static void ShowWindow()
        // {
        //     var window = CreateInstance<AnimationTracks>();
        //     window.Show();
        // }
        //
        // private void OnEnable()
        // {
        //     titleContent = new GUIContent("Maestro Story Engine");
        //     RenderLayout();
        //     
        // }
        //
        // public void RenderLayout()
        // {
        //     Selection.objects = null;
        //     rootVisualElement.Clear();
        //     
        //     AssetDatabase.Refresh();
        //
        //     string stylesheetPath = "Assets/Playables/Editor/AnimationTracks.uss";
        //     
        //     var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(stylesheetPath);
        //     rootVisualElement.styleSheets.Add(styleSheet);
        //
        //     // Loads and clones our VisualTree (eg. our UXML structure) inside the root.
        //     var pageBuilderTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Playables/AnimationTracks_UXML.uxml");
        //     VisualElement pageBuilderStructure = pageBuilderTree.CloneTree();
        //     rootVisualElement.Add(pageBuilderStructure);
        //     
        //     var buttons = rootVisualElement.Query<Button>();
        //     buttons.ForEach(SetupButton);
        //
        //     SerializedObject childWindowSerialized = new SerializedObject(this);
        //     rootVisualElement.Bind(childWindowSerialized);
        //     
        //     // To be used for eventual horizontal mode
        //     //var labels = rootVisualElement.Query<Label>();
        //     //labels.ForEach(ChangeLabel);
        // }
        //
        // private static AnimationTracks _animationTracks;
        //
        // private static AnimationTracks animationTracks
        // {
        //     get => _animationTracks;
        //     set => _animationTracks = value;
        // }
        //
        // [SerializeField]
        // private bool selectCreatedObject;
        //
        //
        // enum EnableCondition
        // {
        //     TextSelected,
        //     RectTransformSelected,
        //     SpriteSelected,
        //     FloatVarPopulated,
        //     ColorVarPopulated
        // };
        //
        // enum ButtonNames
        // {
        //     TMProColorTrack,
        //     RectTransformPosTrack,
        //     SpriteColorTrack,
        //     TransformPositionTrack,
        //     RectTransformScaleTrack,
        //     RectTransformRotationTrack,
        // };
        //
        // enum UpdateWindowTriggers
        // {
        //     AllowBlankTracks,
        //     TargetFloatVariable,
        //     TargetColorVariable
        // };
        //
        //
        // private Button SetupButton(Button button)
        // {
        //     switch (button.name) {
        //         case nameof(ButtonNames.TMProColorTrack):
        //             button.clickable.clicked += () =>
        //             {
        //                 if (selectCreatedObject == true) {
        //                     Selection.objects = CreateTMProColorTrack();
        //                 }
        //                 else {
        //                     CreateTMProColorTrack();
        //                 }
        //
        //                 TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        //             };
        //             break;
        //         
        //         case nameof(ButtonNames.SpriteColorTrack):
        //             button.clickable.clicked += () =>
        //             {
        //                 if (selectCreatedObject == true) {
        //                     Selection.objects = CreateSpriteColorTrack();
        //                 }
        //                 else {
        //                     CreateSpriteColorTrack();
        //                 }
        //
        //                 TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        //             };
        //             break;
        //         
        //         case nameof(ButtonNames.TransformPositionTrack):
        //             button.clickable.clicked += () =>
        //             {
        //                 if (selectCreatedObject == true) {
        //                     Selection.objects = CreateTransformPositionTrack();
        //                 }
        //                 else {
        //                     CreateRectTransformPositionTrack();
        //                 }
        //
        //                 TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        //             };
        //             break;
        //         
        //
        //         case nameof(ButtonNames.RectTransformPosTrack):
        //             button.clickable.clicked += () =>
        //             {
        //                 if (selectCreatedObject == true) {
        //                     Selection.objects = CreateRectTransformPosTrack();
        //                 }
        //                 else {
        //                     CreateRectTransformPosTrack();
        //                 }
        //
        //                 TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        //             };
        //             break;
        //     }
        //
        //     return button;
        // }
        //
        // [MenuItem("Edit/AltSalt/Create Position Track", false, 0)]
        // public static void HotkeyCreatePositionTrack()
        // {
        //     bool selectCreatedObject = animationTracks.selectCreatedObject;
        //
        //     if(selectCreatedObject == true) {
        //         Selection.objects = CreateRectTransformPosTrack();
        //     } else {
        //         CreateRectTransformPosTrack();
        //     }
        //
        //     TimelineEditor.Refresh(RefreshReason.ContentsAddedOrRemoved);
        // }
        //
        // public static TrackAsset[] CreateTMProColorTrack()
        // {
        //     return TrackPlacement.TriggerCreateTrack(TimelineEditor.inspectedAsset, TimelineEditor.inspectedDirector, Selection.gameObjects, typeof(TMProColorTrack), typeof(TMP_Text), Selection.objects, TimelineEditor.selectedClips);
        // }
        //
        // public static TrackAsset[] CreateSpriteColorTrack()
        // {
        //     return TrackPlacement.TriggerCreateTrack(TimelineEditor.inspectedAsset, TimelineEditor.inspectedDirector, Selection.gameObjects, typeof(SpriteColorTrack), typeof(SpriteRenderer), Selection.objects, TimelineEditor.selectedClips);
        // }
        //
        // public static TrackAsset[] CreateRectTransformPosTrack()
        // {
        //     return TrackPlacement.TriggerCreateTrack(TimelineEditor.inspectedAsset, TimelineEditor.inspectedDirector, Selection.gameObjects, typeof(RectTransformPosTrack), typeof(RectTransform), Selection.objects, TimelineEditor.selectedClips);
        // }
        //
        // private static TrackAsset PopulateTrackAsset(PlayableDirector targetDirector, TrackAsset targetTrack, UnityEngine.Object targetObject)
        // {
        //     foreach (PlayableBinding playableBinding in targetTrack.outputs) {
        //
        //         switch (targetTrack.GetType().Name) {
        //
        //             case nameof(TMProColorTrack):
        //             case nameof(TMProCharSpacingTrack):
        //                 targetDirector.SetGenericBinding(playableBinding.sourceObject, ((GameObject)targetObject).GetComponent<TMP_Text>());
        //                 break;
        //
        //             case nameof(RectTransformPosTrack):
        //             case nameof(RectTransformScaleTrack):
        //             case nameof(RectTransformRotationTrack):
        //                 targetDirector.SetGenericBinding(playableBinding.sourceObject, ((GameObject)targetObject).GetComponent<RectTransform>());
        //                 break;
        //
        //             case nameof(SpriteColorTrack):
        //                 targetDirector.SetGenericBinding(playableBinding.sourceObject, ((GameObject)targetObject).GetComponent<SpriteRenderer>());
        //                 break;
        //
        //             case nameof(LerpFloatVarTrack):
        //                 targetDirector.SetGenericBinding(playableBinding.sourceObject, targetObject);
        //                 break;
        //
        //             case nameof(LerpColorVarTrack):
        //                 targetDirector.SetGenericBinding(playableBinding.sourceObject, targetObject);
        //                 break;
        //
        //             default:
        //                 Debug.LogError("Track type not supported");
        //                 break;
        //         }
        //     }
        //
        //     return targetTrack;
        // }
        
    }
}