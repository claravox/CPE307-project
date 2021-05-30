# CSC307-project

- Kitty Zhuang
- Claire S
- Ethan Goldfarb
- Adam Perlin

# Set Up
## Required Software
- Unity 2019.4.17
- git
- [OpenCV For Unity](https://github.com/EnoxSoftware/OpenCVForUnity)
- code editor or IDE, preferably Visual Studio

## Steps
1. Clone this repository.
2. You will need to get a Unity account ([Student or Personal](https://store.unity.com/#plans-individual) will suffice) and download Unity Hub.
3. Install Unity 2019.4.17. The usual way to do this is through the [Unity download archive](https://unity3d.com/get-unity/download/archive), get that version of the installer.
4. In the installer, specify that you want to be able to build for your current desktop platform (Windows/Mac/Linux) and if you want to build for mobile, a compatible mobile platform, only iOS and Android are supported.
5. Open Unity Hub, click "Add", and navigate to where you cloned this repository, and select the "SecurityAR" folder. Select the Unity version to be 2019.4.17, and then open the project.
6. Download the OpenCV For Unity package. In the Unity project, go to the top toolbar and click on "Assets", then "Import Package"-> "Custom Package". Select all the files and click import.
7. Go to "Edit"->"Project Settings", search for unsafe, and check the box next to "Allow 'unsafe' Code", close this screen.
    1. If you are on Linux you will also have to launch all projects starting from Unity Hub with `LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/usr/lib64 unityhub` in order for the camera to work with OpenCV For Unity
8. At the bottom portion of the screen, go down to "Project", and double click on the folder "Assets"->"Scenes" and then double click on the "Kitty - 1.1.unity" file.

Now the project is all set up.

If you click the play button at the top middle part of the screen you can view the app in real time.

If you wish to build the app, click on "File"->"Build" and then select your target platform and click "Build" or "Build and Run".

## Code Style
We will be following the [Microsoft C# Coding Convention](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

## System Architecture
![System Architecture diagram](security-ar-diagram.png "System Architecture")
