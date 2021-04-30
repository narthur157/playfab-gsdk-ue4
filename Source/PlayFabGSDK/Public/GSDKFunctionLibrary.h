// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "UObject/Object.h"
#include "GSDKFunctionLibrary.generated.h"

/**
 * Wrappers for getting info out of the GSDK
 */
UCLASS()
class PLAYFABGSDK_API UGSDKFunctionLibrary : public UObject
{
	GENERATED_BODY()

	/**
	 * Will only work once ReadyForPlayers has been called, ie the server has been allocated
	 */
	UFUNCTION(BlueprintPure)
	static FString GetMatchId();

private:
	static FString GetGSDKConfigValue(FString Key);
};
