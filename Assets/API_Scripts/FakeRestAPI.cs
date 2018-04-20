using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FakeRestAPI
{

    private static string apiHostname = "localhost";

    public static AppModes GetAppModes() {
        LocalizedString EN_SurveillanceModeName = new LocalizedString
        {
            languageCode = "EN",
            str = "Surveillance"
        };

        LocalizedString EN_MaintenanceModeName = new LocalizedString
        {
            languageCode = "EN",
            str = "Maintenance"
        };

        LocalizedString EN_BillingModeName = new LocalizedString
        {
            languageCode = "EN",
            str = "Billing"
        };

        LocalizedString SE_SurveillanceModeName = new LocalizedString
        {
            languageCode = "SE",
            str = "Övervakning"
        };

        LocalizedString SE_MaintenanceModeName = new LocalizedString
        {
            languageCode = "EN",
            str = "Underhåll"
        };

        LocalizedString SE_BillingModeName = new LocalizedString
        {
            languageCode = "EN",
            str = "Fakturering"
        };

        AppMode surveillanceMode = new AppMode
        {
            modeName = new LocalizedString[] {
                EN_SurveillanceModeName,
                SE_SurveillanceModeName
            },
            url = apiHostname + "/appmodes/surveillance"
        };

        AppMode maintenanceMode = new AppMode
        {
            modeName = new LocalizedString[] {
                EN_MaintenanceModeName,
                SE_MaintenanceModeName
            },
            url = apiHostname + "/appmodes/maintenance"
        };

        AppMode billingMode = new AppMode
        {
            modeName = new LocalizedString[] {
                EN_BillingModeName,
                SE_BillingModeName
            },
            url = apiHostname + "/appmodes/billing"
        };

        return new AppModes { 
            appModes = new AppMode[] {
                surveillanceMode,
                maintenanceMode,
                billingMode
            } 
        };
    }
}
