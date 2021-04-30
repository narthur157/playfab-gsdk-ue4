# UE4 GSDK Plugin
A plugin for PlayFab's GSDK integration in UE4

Tested on 4.26.1, should work on other versions as well (tm)

This plugin is designed to enable a simple integration of GSDK in UE4. Just add the plugin to your project and enable it.

The module lifecycle registration events follow what was provided by Hicon: https://docs.microsoft.com/en-us/gaming/playfab/features/multiplayer/servers/playfabgsdk_guide

Pull requests + issues are encouraged and welcome

The linux static libs were generated using a libc++ version of the GSDK, see info here if interested in compiling yourself: https://github.com/PlayFab/gsdk/issues/71
Currently only the release binary is included
Windows packages were downloaded via NuGet

For linux servers, you can use a dockerfile like this:

```
FROM ubuntu:18.04

# Unreal refuses to run as root user, so we must create a user to run as
# Docker uses root by default
RUN useradd --system ue
USER ue

EXPOSE 7777/udp

WORKDIR /server

COPY --chown=ue:ue . /server
CMD ./YourGameNameServer.sh
```
With Windows + WSL 2 set to linux containers, I could build this and upload it to the Azure Container Registry provided by PlayFab
