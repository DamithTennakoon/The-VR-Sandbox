
# The VR Sandbox

The VR Sandbox is an virtual reality application that is designed to simulate real-world laboratories in STEM courses at the University level. The app enables students to be fully immersed into a virtual environment to perform various exercices and experiments. The VR Sandbox offers virtual tours of key landmarks, activities for building electrical circuits, exercises to learn about mechatronics. 

# Version 4: Drone Laboratory 
## Purpose
The purpose of the Drone Laboratory scene was to create a mechatronics laboratory for users to learn about drone components, flight mechanics, assembly processes, how to fly a drone using an RC controller, and about their applications in real-world scenarious such as usages in construction sites or safety inspections for structures such as bridges. 

## Development Process
Their were some key strategies that were sought out to construct the mechatronics lab. They were planning the VR lab, desigining the lab in CAD, and programming interactive tools and real-world drone mechanics/physics. To elobaroate:

    1. Generate images of general design of the virtual environment.
    2. Specify key objects that needs to be modelled.
    3. CAD model the virtual environment.
    4. Debug models when exporting between various 3D environments.
    5. Texture the virtual environment.
    6. Program interactive tools and drone physics.

### Planning the Virtual Laboratory 
The planning process began by first thinking about what equipment and objects are usually found in mechatronics laboratory. Some objects are listed below:

- Work stations/tables.
- Testing zone/arena.
- Equipment and tools: 3D printers, robotic arms, etc.
- Open space to move and work.

It was also important to design a space where users would feel immersed and enaged to work in. For this reason, a traditional laboratory setting was not justified. Taking the infomation into account, online *AI art generators* were used to construct clippings of what a Sci-Fi space themed mechatronics/robotics laboratory. After sorting through many clippings, an ideal image was selected in preperation for CAD modelling.

`AI Art Generator Tool:` https://playgroundai.com/

### CAD Modelling the Virtual Environment - Autodesk Fusion 360
Once the general idea of what the laboratory was intended to look like and include was selected, the CAD modelling process began. 

The CAD modelling software chosen for the object modelling was **Autodesk Fusion 360**. This modelling software was used as it is a very capable software, with many useful features and tool, provides educational licenses, and is compatible on both MacOS and Windows (enables cross-platform development). 

`Autodesk Fusion 360:` https://www.autodesk.ca/en/products/fusion-360/overview?term=1-YEAR&tab=subscription

As an example, one of the main requirements for the virtual environment was having workstations. CAD models of general workstations were performed. The process include first cerating an engineering sketch of the workstation, then performing extrusions, followed by exporting objects as filmbox (FBX) files. An example of the development a workstation's engieering sketch is shown below.

![Workstation CAD Sketch](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/CAD_Workstation.png)

This process was continued for nearly all of the objects in the virtual environment. It is important to note that some objects were brought in from third party websites that offer free 3D models. These will be mentioned later on in the documentation.

It is important to note that Unity (development environment for VR application) takes 3D models in the form of object (.obj) and FBX files. FBX was chosen as an itermediate step is required to correct the designed objects using the Blender 3D modelling software. Though Blender takes various 3D model files, it was found that FBX files were easiest to manage in the development pipeline.

### UV Mapping - Blender
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

### Virtual Environment Assembly - Unity 
Once all of the 3D models have been modelled and exported as FBX files, they are imported and organized appropriately in the Unity Development environment.

Unity is game engine created by Unity Technologies. The engine is designed to created desktoip, mobile, console, and virtual reality applications. Although a "game" engine, it is widely used for **educational tools** as it has built-in robust physics engine and intuitive user experience. 

`Unity:` https://unity.com/

The objects, referred by Unity as "prefabs", are integrated into the 3D scene and assembled. This process consists of rescaling objects, positioning them accordingly, and adding colliders to them to ensure the objects are interactable. 

**Disclaimer:** *It is important to note that VR development cannot be done natively in Unity. Packages from the Unity Package Manager must be installed for VR development. Multiple depenendencies must be properly imported and setup in the environment to begin developing with XR interaction toolkit.*

`XR Interaction Toolkit:` https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.4/manual/index.html

An example of the assembly process of prefabs in the 3D scene to construct the virtual environment is shown below:

![Unity Scene: 3D View](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/Unity_Scene.png)

Another important step for providing a realistic VR experience is creating an environment that resembles real world objects. The custom 3D models do not have any textures applied onto them but a base colour. For this reason, the objects should be textured to make them look more like their real-world counter part. For this project, 2K textures are used for objects as rendering multiple 4K textures in close proximity will cause performce drops. Soime textures are 4K in this project but most are 2K. The resources listed below were used to download textures:

`Poly Haven:` https://polyhaven.com/

`Free PBR:` https://freepbr.com/

Once the desired 3D scene has been created and tested, interactive tools and scripting physics/behvaiour needs to created.

### Programming Physics/Mechanics and Interaction Tools: C# 
#### VR Hardware Programming
One of the key parts of developing a VR application is coding intereactions tools in order to make use of the VR head mounted display (HMD), VR controllers, as well as make use of the objects within the virtual environment. When beginning a VR applicaiton, scripts must be written to listen for, inititiaze, and store object data of the HMD and the VR controllers. The VR rig controlls of VR Sandbox can be found in `Assets/C# Scripts/VR Rig Controls/ContinousMovement.cs` and `Assets/C# Scripts/VR Rig Controls/HandPresence.cs`. A snippet for code that enables the use of the VR controllers is shown below:

**Code Snipet**

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    // Create an object to listen for controller characteristics
    public InputDeviceCharacteristics ControllerCharacteristics;

    // Create a list of objects for the controll models
    public List<GameObject> ControllerPrefabs;

    // Create an input device object
    private InputDevice TargetDevice;

    // Create a game object to refer to controller
    private GameObject SpawnedController;

    // Start is called before the first frame update
    void Start()
    {
        // Create a list contaianing all detected devices
        List<InputDevice> Devices = new List<InputDevice>();

        // Get the right controller from the devices list and save that as the new list of devices
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, Devices);

        // If the device count of the searched controller is present, select that controller 
        if (Devices.Count > 0)
        {
            // Instatiate the input device object 
            TargetDevice = Devices[0];

            // Get the correct controller prefab (the one that matches the name of device)
            // NOTE: Name of device detected has to match prefab name, else you will get an error
            GameObject Prefab = ControllerPrefabs.Find(controller => controller.name == TargetDevice.name);

            // Spawn the found object as a hand prefab
            if (Prefab)
            {
                SpawnedController = Instantiate(Prefab, transform);
            }
```

#### Developing VR Controller Tools and Interactions
Unity's XR Interaction Toolkit provides useful VR interactions scripts that enable objects to be grabbable with the VR controllers. More recent updates to Unity's XR Interaction Toolkit include new tools such as visualization tools, teleportation tools, and more.

Although Unity provides an array of tools for XR development, many tools have to be custom built depending on the interactions required for the applications. One of the key tools that was necessary for an immersive education experience is a way to manipulate and visualize 3D objects by using hand motions and gestures. This tool was developed from scratch in the VR Sandbox application as the XR Interaction Toolkit was outdated and did not contain the visual tool necessary for the mechatronics lab. Updating the toolkit may cause issues with current scripts applied for the older toolkit that are applied on objects within the application. Additionally, since only a single tool was required, it made more sense to develop the tool in-house.

**Development of Exploratory Visualization VR Gesture Tool**

The goal of the Exploratory Visualization tool was to create a tool that enabled the user to inspect 3D objects in a way that provides a complete viewing experience of their model, observe the model in perspectives that cannot be done in any other form of visualization, and to be able to do it with ease. 

This allows the user to rotate and scale and object in the VR environment to their liking by simply rotating and changing the distance between their handheld controllers. This tool is extremely intuitive and is a gesture that people beginner to using VR can comprehend.  An example of this tool applied to a 3D mondel of S9 drone is show below: 

![Visual Tool GIF](https://media.githubusercontent.com/media/DamithTennakoon/The-VR-Sandbox/TestDroneLab/Assets/Info%20Images/VisualTool.gif)

The first step in developing this tool was to listen for the serial data that is input from the controllers. Specifically, listening for when the right hand controller was initialized at the begining of the application. To do this, a list of type `Devices` object was created in order to save the located devices. 

The second step listening for the left and right controller prefabs by tag name. The prefabs for the Oculus Touch Controllers (controller used for this applicaiton) was given the tag "VR Controller". The reason for this is that the transform for the 3D models of the controllers were needed to be accessed so by listening for instances of their objects, it can be saved as `GameObject` objects in this script. 

The next step was checking checking the length of the Controllers object list per frame (void update() method) in order to ensure that the controller was connected during runtime. From here a method was written to grab the distance between the two transforms in 3D space per frame. The was saved a `float` object was reffered to as the `scale value`. This object, along with the `Vector3` objects that stored the 3D vector transforms of the controller prefabs were made public so that they can be accessed from a seperate C# script later on. There was also a `bool` type variable that stored the state of the primary button of the right hand controller, based on the serial data input from the VR system.

Lastly, a scaling script was written to take the data computed above and apply it to the `localScale` parameter of a desired GameObject when the primary button was pressed (allows for the tool to be used only when wanted). Refer to the full scripts at `Assets/C# Scripts/VR Rig Controls/ControllerData.cs` and `Assets/C# Scripts/Effects/Scaling.cs`.

#### Developing PID Controller for Drone