using Module2HW5.Models;

namespace Module2HW5.Services.Abstractions
{
    public interface IConfigService
    {
        Config Config { get; set; }
        void SaveConfig();
        void LoadConfig();
    }
}
