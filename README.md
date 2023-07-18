
# The VR Sandbox

The VR Sandbox is an virtual reality application that is desined to simulate real-world laboratories in STEM courses at the University level. The app enables students to be fully immersed into a virtual environment to perform various exercices and experiments. The VR Sandbox offers virtual tours of key landmarks, activities for building electrical circuits, exercises to learn about mechatronics. 

## Version 4: Drone Laboratory 
### Purpose
The purpose of the Drone Laboratory scene was to create a mechatronics laboratory for users to learn about drone components, flight mechanics, assembly processes, how to fly a drone using an RC controller, and about their applications in real-world scenarious such as usages in construction sites or safety inspections for structures such as bridges. 

### Development Process
Their were some key strategies that were sought out to construct the mechatronics lab. They were planning the VR lab, desigining the lab in CAD, and programming interactive tools and real-world drone mechanics/physics. To elobaroate:

    1. Generate images of general design of the virtual environment.
    2. Specify key objects that needs to be modelled.
    3. CAD model the virtual environment.
    4. Debug models when exporting between various 3D environments.
    5. Texture the virtual environment.
    6. Program interactive tools and drone physics.

#### Planning the Virtual Laboratory 
The planning process began by first thinking about what equipment and objects are usually found in mechatronics laboratory. Some objects are listed below:

- Work stations/tables.
- Testing zone/arena.
- Equipment and tools: 3D printers, robotic arms, etc.
- Open space to move and work.

It was also important to design a space where users would feel immersed and enaged to work in. For this reason, a traditional laboratory setting was not justified. Taking the infomation into account, online *AI art generators* were used to construct clippings of what a Sci-Fi space themed mechatronics/robotics laboratory. After sorting through many clippings, an ideal image was selected in preperation for CAD modelling.

`AI Art Generator Tool:` https://playgroundai.com/

#### CAD Modelling the Virtual Environment
Once the general idea of what the laboratory was intended to look like and include was selected, the CAD modelling process began. 

The CAD modelling software chosen for the object modelling was **Autodesk Fusion 360**. This modelling software was used as it is a very capable software, with many useful features and tool, provides educational licenses, and is compatible on both MacOS and Windows (enables cross-platform development). 

As an example, one of the main requirements for the virtual environment was having workstations. CAD models of general workstations were performed. The process include first cerating an engineering sketch of the workstation, then performing extrusions, followed by exporting objects as filmbox (FBX) files. An example of the development a workstation's engieering sketch is shown below.

![Workstation CAD Sketch](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/CAD_Workstation.png)

It is important to note that Unity (development environment for VR application) takes 3D models in the form of object (.obj) and FBX files. FBX was chosen as an itermediate step is required to correct the designed objects using the Blender 3D modelling software. Though Blender takes various 3D model files, it was found that FBX files were easiest to manage in the development pipeline.


