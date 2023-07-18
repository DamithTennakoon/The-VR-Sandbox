# The VR Sandbox

The VR Sandbox is an virtual reality application that is designed to simulate real-world laboratories in STEM courses at the University level. The app enables students to be fully immersed into a virtual environment to perform various exercices and experiments. The VR Sandbox offers virtual tours of key landmarks, activities for building electrical circuits, exercises to learn about mechatronics. 

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

#### CAD Modelling the Virtual Environment - Autodesk Fusion 360
Once the general idea of what the laboratory was intended to look like and include was selected, the CAD modelling process began. 

The CAD modelling software chosen for the object modelling was **Autodesk Fusion 360**. This modelling software was used as it is a very capable software, with many useful features and tool, provides educational licenses, and is compatible on both MacOS and Windows (enables cross-platform development). 

`Autodesk Fusion 360:` https://www.autodesk.ca/en/products/fusion-360/overview?term=1-YEAR&tab=subscription

As an example, one of the main requirements for the virtual environment was having workstations. CAD models of general workstations were performed. The process include first cerating an engineering sketch of the workstation, then performing extrusions, followed by exporting objects as filmbox (FBX) files. An example of the development a workstation's engieering sketch is shown below.

![Workstation CAD Sketch](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/CAD_Workstation.png)

This process was continued for nearly all of the objects in the virtual environment. It is important to note that some objects were brought in from third party websites that offer free 3D models. These will be mentioned later on in the documentation.

It is important to note that Unity (development environment for VR application) takes 3D models in the form of object (.obj) and FBX files. FBX was chosen as an itermediate step is required to correct the designed objects using the Blender 3D modelling software. Though Blender takes various 3D model files, it was found that FBX files were easiest to manage in the development pipeline.

#### UV Mapping - Blender
As a general definition, a UV map is a 2D image of a 3D models surface. One of the problems that is commonly encountered when exporting and importing between various 3D modelling softwares is that the objects' UV maps become distorted. This becomes a big issue when texturing objects as the textures will not be correctly applied to the 3D object. For this reason, the UVs of each exported model needs to be corrected.

The software used for the UV mapping corrections is **Blender**. Blender is an open-source 3D modelling and animations software. This software is also available for MacOS and Windows. 

`Blender:` https://www.blender.org/about/

To be specific, one of the commonly seen buggs is that exported Fusion 360 FBX model will have UVs that are extremly large or are offset from the UV map's frame. To correct this problem, the following process is used: 

    1. Import Fusion 360 FBX model.
    2. Select each component/body/extrude of the 3D model.
    3. Enter UV editing mode.
    4. Open edit mode for selected object.
    5. Perform Smart UV Project with the following options:
        - Angle limit: 66 degrees.
        - Island margin: 0.05
        - Area weight: 0
        - Enable "Contact Aspect"
        - Disable "Scale to Bounds"

An example of an incorrect UV map is shown below:

![Incorrect UV Map Image](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/Incorrect_UV_Map.png)

The above UV map is incorrect as the UVs of the object should first coherently in the grid frame on the left panel. The UVs of this object are natively larger than the frame of the map and so when textures are applied to this material, they will not be rendered correctly.

Once the Smart UV Project is completed on all componenents of the object, the object can then be exported as FBX file in preperation for integration into Unity's development environment.

#### Virtual Environment Assembly - Unity Environment
Once all of the 3D models have been modelled and exported as FBX files, they are imported and organized appropriately in the Unity Development environment.

Unity is game engine created by Unity Technologies. The engine is designed to created desktoip, mobile, console, and virtual reality applications. Although a "game" engine, it is widely used for **educational tools** as it has built-in robust physics engine and intuitive user experience. 

`Unity:` https://unity.com/

The objects, referred by Unity as "prefabs", are integrated into the 3D scene and assembled. This process consists of rescaling objects, positioning them accordingly, and adding colliders to them to ensure the objects are interactable. 

**Disclaimer:** *It is important to note that VR development cannot be done natively in Unity. Packages from the Unity Package Manager must be installed for VR development. Many depenendencies must be properly imported and setup in the environment to begin developing with XR interaction toolkit.*

`XR Interaction Toolkit:` https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.4/manual/index.html

An example of the assembly process of prefabs in the 3D scene to construct the virtual environment is shown below:

![Unity Scene: 3D View](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/Unity_Scene.png)

Once the desired 3D scene has been created and tested, interactive tools and scripting physics/behvaiour needs to created.
