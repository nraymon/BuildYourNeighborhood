# Build Your Neighborhood

For our 2020-2021 capstone project, we have developed an educational game for mobile platforms, intended to help young children learn about a neighborhood's components and their interactions. The user has access to four tiles: house, road, bioswale, and wetlands. They can arrange them on a 5 by 5 grid of a neighborhood to raise and lower scores in three benchmarks: flood management, pedestrian safety, and housing / quality of life.

Our team members include Nathan Raymon, Jacob Lagmay, Lindy Voss, Garrett Whitehurst, and April James, and our project partner is Fatima Taha, a Geography PhD candidate at Oregon State University. Her studies focus on bioswales, which are channels between the road and sidewalk which redirect rainwater runoff and harbor vegetation and trees. Taha's goal for this project is to allow users to learn about the components of the neighborhood and their interactions by playing the game, then assess their knowledge of bioswales through a survey after completing the game.

The game is developed using Unity as the game engine. This provides a way to export the game for many platforms without needing to rewrite the codebase. The game scripts are written in C#, and are used to control the mechanics of the game, such as dragging tiles, rotating the screen, and calculating score. The UI is created through Unity's UI features, the skybox is designed in Adobe Illustrator, and the tile assets are sculpted in Blender.

## Technology Requirements

### Software Required and Build directions

In order to run this source code, you will need the Unity Engine. The [Unity Hub](https://unity3d.com/get-unity/download) will allow you download different versions of unity and access different Unity projects. This is the [Version](https://unity3d.com/unity/whats-new/2020.1.12) we have been using to make our game. This will ensure the version you run closely matches what we've experienced and know works. 

If you want to be able to build this game for anything other than a Windows PC, make sure you choose the modules for the operating system you would like to build for. To get to modules, open Unity Hub. On the left hand side of the app there should be a list of directories, click on installs. Click the three dot menu on version 2020.1.12f1 -> add modules. This should bring up a list of build support options and just choose whichever platforms you would like to build for. Once you have downloaded the Hub and the Unity version, you'll be able to run our code. First, you will need to download this repo. You can do that through your chosen git interface or directly from this page from the green "code" button in the top right.

After everything is downloaded, open Unity Hub and in the top right hand corner there should be a white "add" button. You should be prompted with the file explorer screen. Navigate to the path where you cloned our repo and add the Temp3D_BYN_Project folder to Unity Hub. You should now be able to open the project through the Hub and get access to our game. It may take awhile for unity to initialize and load everything, but it will eventually open up. 

To build our project, go to File -> Build Settings and choose the platform you want to build for. If you switch from you default platform, it will take some time to reinitialize things, but once it is done, there will be a bottom toward the bottom right that says, "build." Click on that and you will be prompted with another file expolorer screen to choose the path where to want to store the build of the game. Once you have chosen your desired path, it will start compiling and making a build of the game. When it is done, you can navigate to the path you chose and either transfer it to your desired platform via a service of you choosing, or double click the executable and it should run.

### Hardware Required

This has only been tested on Windows 10 and Mac machines, but you will need at least:
##### PC/MAC/Linux:
* Windows 7 and onward / High Sierra 10.13+ / Ubuntu 16.04 and Ubuntu 18.04
* x86, x64 architecture with SSE2 instruction set support
* A Graphics device capable of DX 10, 11, and/or 12 / OpenGL 3.2+, Vulkan capable.
* 2 GB of RAM

iPhone app would need to be put on the app store which we have not done yet.

#### Android:

* Version 4.4 (API 19)+
* ARMv7 with Neon Support (32-bit) or ARM64
* OpenGL ES 2.0+, OpenGL ES 3.0+, Vulkan
* 1+ GB of RAM
