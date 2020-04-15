// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class PlayFabGSDK : ModuleRules
{
	public PlayFabGSDK(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
        });

        if (Target.bBuildEditor == true)
        {
            PublicDefinitions.Add("ENABLE_PLAYFABSERVER_API=1");
        }

        bUseRTTI = false;

        if (Target.Type == TargetType.Server)
        {
            bEnableExceptions = true;

            string GSDKFolder = "Plugins/PlayFabGSDK/GSDK";
            string PackageFolder = "com.playfab.cppgsdk.v140.0.7.200221";
            string WindowsDllPath = "build/native/lib/Windows/x64/Release/dynamic";

            // Add dynamic dlls required by all dedicated servers
            RuntimeDependencies.Add("$(TargetOutputDir)/xinput1_3.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/DirectX/xinput1_3.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/concrt140.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/Microsoft.VC.CRT/concrt140.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/msvcp140.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/Microsoft.VC.CRT/msvcp140.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/msvcp140_1.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/Microsoft.VC.CRT/msvcp140_1.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/msvcp140_2.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/Microsoft.VC.CRT/msvcp140_2.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/vccorlib140.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/Microsoft.VC.CRT/vccorlib140.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/vcruntime140.dll", "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64/Microsoft.VC.CRT/vcruntime140.dll", StagedFileType.SystemNonUFS);
            
            // Add dynamic dlls required by GSDK
            RuntimeDependencies.Add("$(TargetOutputDir)/GSDK_CPP_Windows.lib", "$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/GSDK_CPP_Windows.lib", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/libcurl.lib", "$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/libcurl.lib", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/libcurl.dll", "$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/libcurl.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/libssl-1_1-x64.dll", "$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/libssl-1_1-x64.dll", StagedFileType.SystemNonUFS);
            RuntimeDependencies.Add("$(TargetOutputDir)/libcrypto-1_1-x64.dll", "$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/libcrypto-1_1-x64.dll", StagedFileType.SystemNonUFS);
           
            // Add libraries required by GSDK
            PublicAdditionalLibraries.Add("$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/GSDK_CPP_Windows.lib");
            PublicAdditionalLibraries.Add("$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/" + WindowsDllPath + "/libcurl.lib");
            PublicIncludePaths.Add("$(ProjectDir)/" + GSDKFolder + "/" + PackageFolder + "/build/native/include");
        }
    }
}
