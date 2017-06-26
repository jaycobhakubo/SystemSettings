using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.SystemSettings.Models
{
    public class RemoteDisplayConfiguration
    {
        public int MachineID { get; set; }
        public int AdaptorID { get; set; }
        public bool AdaptorEnabled { get; set; }
        public string Resolution { get; set; }
        public int DefaultScene { get; set; }
        public string EnabledAccruals { get; set; }
        public string AllowedScenes { get; set; }
    }
    public enum RemoteDisplayConfigurationType
    {
        AdapterEnabled = 1,
        Resolution = 2,
        AllowedScenes = 3,
        DefaultScene = 4,
        EnabledAccruals = 5
    }
}
