## PlayFab UE4 GSDK Integration

This plugin provides a simple GSDK integration for UE4. It's based on the docs provided to PlayFab by HICON
https://docs.microsoft.com/en-us/gaming/playfab/features/multiplayer/servers/playfabgsdk_guide

The contents of the NuGet `packages` folder were copied to the `GSDK/` folder in this repo.

I've tested that this goes through the correct states on the local debugging setup.

In order to create a server build, you will need to copy the contents of `CopyToBuild` into your build folder. This contains all the game DLLs needed by UE4 for your container.