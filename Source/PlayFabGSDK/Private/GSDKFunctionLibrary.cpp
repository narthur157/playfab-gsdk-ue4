// Copyright MIT - Nicholas Arthur


#include "PlayFabGSDK/Public/GSDKFunctionLibrary.h"


#if UE_SERVER
#include "gsdk.h"
#include "string.h"
#endif

FString UGSDKFunctionLibrary::GetMatchId()
{
#if UE_SERVER
	return GetGSDKConfigValue("sessionId");
#endif

	UE_LOG(LogTemp, Warning, TEXT("Clients should not try to retrieve the match ID through the GSDK"));
	return "";
}

FString UGSDKFunctionLibrary::GetGSDKConfigValue(FString Key)
{
#if UE_SERVER
	// Convert FString to std::string
	std::string ConvertedKey(TCHAR_TO_UTF8(*Key));

	std::unordered_map<std::string, std::string> ConfigMap = Microsoft::Azure::Gaming::GSDK::getConfigSettings();

	// Convert std::string to FString
	return UTF8_TO_TCHAR(ConfigMap[ConvertedKey].c_str());
#endif

	return "";
}
