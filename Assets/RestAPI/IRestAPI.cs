using AppSystem.Models;

namespace AppSystem.RestAPI
{
    public interface IRestAPI
    {

        AppModes GetAppModes();
        Models.MainMenu GetMainMenu();

    }
}


