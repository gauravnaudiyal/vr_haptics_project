# VR Haptics Project

This was my summer research project looking at how haptic feedback changes the experience of being in a VR simulation. I wanted to go beyond just visuals and audio and actually make the body feel something, so I integrated the bHaptics Tactosy suit into a Unity VR environment built on the Meta XR SDK.

The core idea was simple: when something happens in the virtual world, you feel it. Getting that to actually work and feel natural was the interesting part.

## What it does

The project is a VR simulation running on Meta Quest where haptic feedback is triggered by in-world events. A nature environment sets the scene, animated characters populate it, and spatial audio plus haptic patterns fire together to create something that feels more immersive than a typical VR demo.

## Project structure

```
Animations/         character animation clips
Audio/              spatial audio files
Bhaptics/           bHaptics SDK integration
Characters/         rigged character assets
NatureStarterKit/   environment assets
Oculus/             Meta XR integration
Resources/          shared project resources
Scenes/             Unity scenes
Scripts/            C# gameplay and haptics scripts
Settings/           project and render pipeline settings
XR/                 XR configuration
XRI/                XR Interaction Toolkit assets
```

## Built with

- Unity (2022.3 LTS)
- C#
- bHaptics Unity Plugin
- Meta XR SDK
- Unity XR Interaction Toolkit

## Setup

1. Clone the repo
2. Open in Unity Hub with Unity 2022.3+
3. Install Meta XR SDK, XR Interaction Toolkit, and the bHaptics Unity Plugin via Package Manager
4. Connect a Meta Quest headset via Link or Air Link
5. Open the bHaptics Player app on your PC
6. Hit Play in the Editor or build to the headset

## Notes

You need a bHaptics Tactosy vest for the haptic feedback to actually work. The simulation still runs without it but you lose the whole point of the project.

Developed by Gaurav Naudiyal as part of an MSc research internship at Trinity College Dublin.
