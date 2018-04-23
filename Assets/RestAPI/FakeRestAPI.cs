using AppSystem.Models;

namespace AppSystem.RestAPI
{

    public class FakeRestAPI : IRestAPI
    {
        private string protocol = "http://";
        private string apiHostname = "localhost";

        public AppModes GetAppModes()
        {
            LocalizedString EN_SurveillanceModeName = new LocalizedString {
                languageCode = "EN",
                str = "Surveillance"
            };

            LocalizedString EN_MaintenanceModeName = new LocalizedString {
                languageCode = "EN",
                str = "Maintenance"
            };

            LocalizedString EN_BillingModeName = new LocalizedString {
                languageCode = "EN",
                str = "Billing"
            };

            LocalizedString SE_SurveillanceModeName = new LocalizedString {
                languageCode = "SE",
                str = "Övervakning"
            };

            LocalizedString SE_MaintenanceModeName = new LocalizedString {
                languageCode = "EN",
                str = "Underhåll"
            };

            LocalizedString SE_BillingModeName = new LocalizedString {
                languageCode = "EN",
                str = "Fakturering"
            };

            AppMode surveillanceMode = new AppMode {
                modeName = new LocalizedString[] {
                EN_SurveillanceModeName,
                SE_SurveillanceModeName
            },
                mode = "surveillance",
                buttonPrefab = "UI/TopMenu/AppModeButtonSurveillance"
            };

            AppMode maintenanceMode = new AppMode {
                modeName = new LocalizedString[] {
                EN_MaintenanceModeName,
                SE_MaintenanceModeName
            },
                mode = "maintenance",
                buttonPrefab = "UI/TopMenu/AppModeButtonMaintenance"
            };

            AppMode billingMode = new AppMode {
                modeName = new LocalizedString[] {
                EN_BillingModeName,
                SE_BillingModeName
            },
                mode = "billing",
                buttonPrefab = "UI/TopMenu/AppModeButtonBilling"
            };

            return new AppModes {
                appModes = new AppMode[] {
                    surveillanceMode,
                    maintenanceMode,
                    billingMode
                }
            };
        }

        public Models.MainMenu GetMainMenu()
        {
            Models.MainMenu mainMenu = new Models.MainMenu();
            if(SystemApp.SelectedAppMode == null)
                return null;
            
            if(SystemApp.SelectedAppMode.mode.Equals("surveillance")) {
                mainMenu.mainMenuItems = new Models.MainMenuItem[] { };
            } else if(SystemApp.SelectedAppMode.mode.Equals("maintenance")) {
                mainMenu.mainMenuItems = new Models.MainMenuItem[] {
                     new Models.MainMenuItem {
                        itemName = new LocalizedString[] {
                            new LocalizedString { languageCode = "EN", str = "Add Customer" },
                            new LocalizedString { languageCode = "SE", str = "Skapa kund" }
                        },
                        url = protocol + apiHostname + "/customers"
                    },
                     new Models.MainMenuItem {
                        itemName = new LocalizedString[] {
                            new LocalizedString { languageCode = "EN", str = "Add Collector" },
                            new LocalizedString { languageCode = "SE", str = "Skapa collector" }
                        },
                        url = protocol + apiHostname + "/collectors"
                     }
                };
            } else if(SystemApp.SelectedAppMode.mode.Equals("billing")) {
                mainMenu.mainMenuItems = new Models.MainMenuItem[] { };
            }
            return mainMenu;
        }
    }
}