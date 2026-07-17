# VR Haptics Project 🎮🦾

A Unity-based VR simulation exploring **haptic feedback integration** using the **bHaptics Tactosy** suit. This was a summer research project investigating how tactile feedback enhances immersion in virtual reality environments.

## Overview

This project combines the **Oculus/Meta XR SDK** with **bHaptics** to create a VR experience where physical sensations are synchronized with in-game events — such as impacts, environmental effects, and interactions. Built on Unity's XR Interaction Toolkit (XRI).

## Features

- 🦾 **bHaptics Integration** — Full haptic feedback support via the bHaptics SDK for chest/arm vest (Tactosy)
- 🥽 **Oculus/Meta XR** — Built with Meta XR SDK and Unity's XR Origin rig
- 🌿 **Nature Environment** — Immersive outdoor scene using the Nature Starter Kit assets
- 🎭 **Character Animations** — Animated characters via Mixamo rigs
- 🔊 **Spatial Audio** — 3D audio assets synced with haptic events
- 🎬 **Multiple Scenes** — Scene-based structure for different simulation states

## Project Structure

```
├── Animations/         # Character animation clips
├── Audio/              # Spatial audio files
├── Bhaptics/           # bHaptics SDK integration files
├── Characters/         # Rigged character assets
├── NatureStarterKit/   # Environment assets
├── Oculus/             # Meta/Oculus XR integration
├── Resources/          # Shared project resources
├── Samples/            # Unity XR Toolkit samples
├── Scenes/             # Unity scenes
├── Scripts/            # C# gameplay scripts
├── Settings/           # Project/render settings
├── XR/                 # XR configuration
├── XRI/                # XR Interaction Toolkit assets
```

## Tech Stack

| Tool | Purpose |
|------|---------|
| Unity | Game engine & VR framework |
| C# | Scripting language |
| bHaptics SDK | Haptic feedback control |
| Meta XR SDK | Oculus headset integration |
| XR Interaction Toolkit | VR interaction system |

## Requirements

- Unity 2022.3+ (LTS)
- Meta Quest 2/3 headset or compatible OpenXR device
- bHaptics Tactosy vest + bHaptics Player app
- Meta XR SDK (via Unity Package Manager)

## Getting Started

1. Clone this repository
2. Open in Unity Hub (Unity 2022.3+)
3. Install required packages via Package Manager (Meta XR SDK, XR Interaction Toolkit, bHaptics Unity Plugin)
4. Connect your Meta Quest headset via Link or Air Link
5. Launch bHaptics Player on your PC
6. Press Play in the Unity Editor or build and deploy to your headset

## Research Context

This project was developed as part of a research internship exploring the role of **haptic feedback in VR immersion**. It investigates how physical sensations affect user presence and engagement in simulated environments.

---

*Developed by [Gaurav Naudiyal](https://github.com/gauravnaudiyal) — MSc Computer Science, Trinity College Dublin*
