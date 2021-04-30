# playfab-gsdk-ue4
A plugin for PlayFab's GSDK integration in UE4

Tested on 4.26.1, should work on other versions as well (tm)

This plugin is designed to enable a simple integration of GSDK in UE4. Just add the plugin to your project and enable it.

The module lifecycle registration events follow what was provided by Hicon: https://docs.microsoft.com/en-us/gaming/playfab/features/multiplayer/servers/playfabgsdk_guide

Pull requests + issues are encouraged and welcome

The linux static libs were generated using a libc++ version of the GSDK, see info here if interested in compiling yourself: https://github.com/PlayFab/gsdk/issues/71
Currently only the release binary is included
Windows packages were downloaded via NuGet
