# VR Sandbox Dev Notes
## Drone Lab Development
`Date: June 26, 2023`
The new table created in the drone lab is running basic materials overlaid with 4k normal maps:

- Panels of the table - **Light Grey** material which has has the *aerial_asphalt_01_4k.blend* normal map.
	- Causes high frame rate drop when rendered in-game.
	- After testing, it was determined this was not the cause of the frame rate drops; the rover object was.

### Attempted Bug Fixes
Currently, it is unclear whether the drone and robotics props are causing the frame rate drop.

- Turn on the drone, rover, and the headphones objects: frame rate increases to playable level.
- Turn on the drone: frame rate is at a playable level.
- Turn on the headphones: frame rate is at a playable level.
- Turn on the rover: frame rate drops to an unplayable level.

### General Sci-fi Tables
- Center side frame: 12mm from centre and 18 away from centre.
- Frame aspect ratio: 0.73