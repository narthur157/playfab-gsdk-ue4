// Copyright MIT - Nicholas Arthur

#include "PlayFabGSDK.h"
#include "CoreMinimal.h"
#include "Modules/ModuleManager.h"

#if UE_SERVER
#include "gsdk.h"
#include "string.h"
#endif

#define LOCTEXT_NAMESPACE "FPlayFabGSDKModule"

DEFINE_LOG_CATEGORY(PlayFabGSDK);

class FPlayFabGSDKModule : public IPlayFabGSDKModule
{
	/** IModuleInterface implementation */
	virtual void StartupModule() override;
	virtual void ShutdownModule() override;
	// ~ End IModuleInterface

#if UE_SERVER
	void StartServer();
#endif
};

IMPLEMENT_MODULE(FPlayFabGSDKModule, PlayFabGSDK)

#if UE_SERVER

void LogInfo(FString message)
{
	UE_LOG(PlayFabGSDK, Display, TEXT("%s"), *message);
	Microsoft::Azure::Gaming::GSDK::logMessage(std::string(TCHAR_TO_UTF8(*message)));
}

void LogError(FString message)
{
	UE_LOG(PlayFabGSDK, Error, TEXT("%s"), *message);
	Microsoft::Azure::Gaming::GSDK::logMessage(std::string(TCHAR_TO_UTF8(*message)));
}

void OnShutdown()
{
	LogInfo("Shutting down");
	FGenericPlatformMisc::RequestExit(false);
}

bool HealthCheck()
{
	LogInfo("Healthy");
	return true;
}

void FPlayFabGSDKModule::StartServer()
{
	try {
		Microsoft::Azure::Gaming::GSDK::start();
		Microsoft::Azure::Gaming::GSDK::registerHealthCallback(&HealthCheck);
		Microsoft::Azure::Gaming::GSDK::registerShutdownCallback(&OnShutdown);

		if (Microsoft::Azure::Gaming::GSDK::readyForPlayers())
		{
			LogInfo("Server is ready for players");
		}
		else
		{
			LogError("Server is terminating. Not ready for players");
		}
	}
	catch (Microsoft::Azure::Gaming::GSDKInitializationException& e)
	{
		LogError("GSDK Initialization failed: " + FString(UTF8_TO_TCHAR(e.what())));
	}
}
#endif

void FPlayFabGSDKModule::StartupModule()
{
#if UE_SERVER
	if (FParse::Param(FCommandLine::Get(), TEXT("NoPlayFab")))
	{
		UE_LOG(PlayFabGSDK, Log, TEXT("Not starting playfab server, -noplayfab was passed"));
	}
	else
	{
		StartServer();
	}
#else
	UE_LOG(PlayFabGSDK, Log, TEXT("Not UE_SERVER, in StartupModule()"))
#endif
}

void FPlayFabGSDKModule::ShutdownModule()
{
}

#undef LOCTEXT_NAMESPACE

