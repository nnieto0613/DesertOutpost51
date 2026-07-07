# Desert Outpost 51

## Team Members

- Trevour Guild
- Joshua Page
- Nathan Nieto

---

# Design Overview

## Game Name

Desert Outpost 51

## Backstory

The player crash lands near a remote military research facility known as Desert Outpost 51. The outpost has been abandoned after hostile security drones took control of the facility. Before the entire base self-destructs, the player must explore the compound, locate the security keycard, restore power to the facility, unlock the security gate, and escape before time runs out while avoiding enemy drones.

---

# Topics Implemented

The following Unity/game development topics from the course were implemented:

### Player Controller
- Third-person movement
- Character animation
- Camera follow system using Cinemachine

### AI
- Enemy drone patrol AI
- Multiple waypoint patrol routes
- Independent patrol paths for each drone

### User Interface (UI)
- Countdown timer
- Mission objective prompts
- Mission Complete screen
- Game Over screen
- Restart button
- Objective notifications

### Collision & Triggers
- Keycard pickup
- Power terminal interaction
- Gate unlocking
- Escape zone detection

### Animation
- Animated player character
- Animator Controller
- Idle and walking animation transitions

### Cameras & Cinematics
- Intro cutscene
- Skip intro functionality
- Cinemachine virtual cameras
- Dolly Track cinematic movement

### Particle Systems
- Fire effects
- Drone particle effects
- Environmental ambience

### Audio
- Wind ambience
- Environmental sounds

### Terrain & Environment
- Painted desert terrain
- Building placement
- Terrain sculpting
- Environmental props

### Game Flow
- Intro sequence
- Objective progression
- Win condition
- Lose condition
- Scene restart

---

# Control Mapping

| Key | Action |
|------|--------|
| W | Move Forward |
| A | Move Left |
| S | Move Backward |
| D | Move Right |
| E | Pick Up / Interact |
| ESC | Skip Intro Cutscene |

---

# Gameplay Objectives

1. Watch or skip the intro cutscene.
2. Explore the desert outpost.
3. Find the security keycard.
4. Restore power at the power terminal.
5. Unlock the security gate.
6. Reach the escape zone before the timer expires.

### Win Condition

- Reach the escape zone after restoring power.

### Lose Conditions

- Timer reaches zero.
- Player is destroyed by enemy drones.

---

# Team Contributions

## Trevour Guild

### Programming

- Implemented player movement
- Implemented drone AI patrol system
- Created multiple waypoint patrol routes
- Added additional enemy drones
- Implemented keycard pickup system
- Implemented security gate system
- Implemented power restoration objective
- Implemented escape zone
- Created Mission Complete sequence
- Added animated player character
- Added player animation controller
- Added intro cutscene
- Added skip cutscene functionality
- Organized project hierarchy
- Adjusted Cinemachine camera system
- Merged terrain with gameplay systems
- Integrated drone models
- Added gameplay polish

### Level Design

- Designed overall game layout
- Terrain sculpting
- Building placement
- Environmental setup

---

## Joshua Page (Mudkip993)

- Updated FireBlock prefab
- Added particle effects
- Improved environmental visual effects
- Continued particle system improvements

---

## Nathan Nieto (nnieto0613)

- Implemented countdown timer
- Created Game Over screen
- Added restart functionality
- Added wind ambience
- Painted terrain
- Added desert sand textures

---

# External Assets (Works Cited)

## Survivalist Character
Publisher: Slayver

https://assetstore.unity.com/packages/3d/characters/survivalist-character-305921

Used for:
- Player model

---

## Human Basic Motions FREE
Publisher: Kevin Iglesias

https://assetstore.unity.com/packages/3d/animations/human-basic-motions-free-154271

Used for:
- Walking animation
- Idle animation

---

## Low Poly Combat Drone
Publisher: VoodooPlay

https://assetstore.unity.com/packages/3d/characters/robots/low-poly-combat-drone-317979

Used for:
- Enemy drone models

---

## Abandoned Buildings
Publisher: Aleksey Kozhemyakin

https://assetstore.unity.com/packages/3d/environments/abandoned-buildings-184407

Used for:
- Desert buildings

---

## 2D Animated Character - RUST
Publisher: BrainDamageAssets

https://assetstore.unity.com/packages/2d/characters/2d-animated-character-rust-191022

Downloaded but **not used** in the final project.

---

# Additional Unity Packages

- Cinemachine
- TextMeshPro

---

# Current Features

- Intro cinematic
- Skip cutscene
- Third-person controller
- Animated player
- Patrol drones
- Multiple drone patrol routes
- Keycard system
- Power restoration system
- Security gate
- Escape zone
- Countdown timer
- Mission Complete screen
- Game Over screen
- Restart functionality
- Desert environment
- Ambient audio
- Particle effects

---

# Future Improvements

If additional development time were available, the following improvements would be added:

- Drone combat and projectile attacks
- Sentry drones
- Improved gate and wall models
- Improved power generator model
- Improved keycard model
- Additional particle effects
- More environmental detail
- More enemy types
- Expanded map
- Ending cutscene
