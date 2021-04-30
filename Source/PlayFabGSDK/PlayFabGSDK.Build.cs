// Copyright MIT - Nicholas Arthur

using UnrealBuildTool;

/**
 * This module serves primarily as a way of including the PlayFabGSDK, however i
 * It also registers the minimum required set of basic lifecycle events with PlayFab
 */
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

        if (Target.bBuildEditor)
        {
            PublicDefinitions.Add("ENABLE_PLAYFABSERVER_API=1");
        }

        if (Target.Type == TargetType.Server)
        {
	        
	        // The GSDK uses exceptions
	        bEnableExceptions = true;

	        string GSDKFolder = "$(ProjectDir)/Plugins/PlayFabGSDK/ThirdParty";
	        PublicIncludePaths.Add(GSDKFolder + "/include");

	        if (Target.Platform == UnrealTargetPlatform.Linux)
	        {
		        PublicAdditionalLibraries.Add(GSDKFolder + "/linux/libGSDK_CPP_Linux.a");
	        }
	        else if (Target.Platform == UnrealTargetPlatform.Win64) // Win32 is not supported
	        {
	            string EditorDllsPath = "$(EngineDir)/Binaries/ThirdParty/AppLocalDependencies/Win64";
	            
	            // Add dynamic dlls required by all dedicated servers, to support containerization
	            // These are not specifically required by the GSDK, they are only required for containers, and GSDK requires us to use containers
	            // Consider using BinaryOutputDir for these paths instead, see https://docs.unrealengine.com/en-US/ProductionPipelines/BuildTools/UnrealBuildTool/ThirdPartyLibraries/index.html
	            RuntimeDependencies.Add("$(TargetOutputDir)/xinput1_3.dll", EditorDllsPath + "/DirectX/xinput1_3.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/concrt140.dll", EditorDllsPath + "/Microsoft.VC.CRT/concrt140.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/msvcp140.dll", EditorDllsPath + "/Microsoft.VC.CRT/msvcp140.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/msvcp140_1.dll", EditorDllsPath + "/Microsoft.VC.CRT/msvcp140_1.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/msvcp140_2.dll", EditorDllsPath + "/Microsoft.VC.CRT/msvcp140_2.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/vccorlib140.dll", EditorDllsPath + "/Microsoft.VC.CRT/vccorlib140.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/vcruntime140.dll", EditorDllsPath + "/Microsoft.VC.CRT/vcruntime140.dll", StagedFileType.SystemNonUFS);

	            string PlatformLibsPath = GSDKFolder + "/windows";
	            // Add dynamic dlls required by GSDK
	            RuntimeDependencies.Add("$(TargetOutputDir)/GSDK_CPP_Windows.lib", PlatformLibsPath + "/GSDK_CPP_Windows.lib", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/libcurl.lib", PlatformLibsPath + "/libcurl.lib", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/libcurl.dll", PlatformLibsPath + "/libcurl.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/libssl-1_1-x64.dll", PlatformLibsPath + "/libssl-1_1-x64.dll", StagedFileType.SystemNonUFS);
	            RuntimeDependencies.Add("$(TargetOutputDir)/libcrypto-1_1-x64.dll", PlatformLibsPath + "/libcrypto-1_1-x64.dll", StagedFileType.SystemNonUFS);
	           
	            // Add libraries required by GSDK
	            PublicAdditionalLibraries.Add(PlatformLibsPath + "/GSDK_CPP_Windows.lib");
	            PublicAdditionalLibraries.Add(PlatformLibsPath + "/libcurl.lib");
	        }
        }
    }
}
