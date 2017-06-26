using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTI.Modules.SystemSettings.Models
{
    public class MachineCapabilites
    {
        public int AdapterNumber { get; set; }
        public string AdapterDescription { get; set; }
        public List<string> AdapterResoultions { get; set; }
        public override string ToString()
        {
            return string.Format("{0} - {1}", AdapterNumber, AdapterDescription);
        }
    }

    public enum MachineCapabilityTypes
    {
        AvailableAdapterNumber = 1,
        AdapterDescription = 2,
        AvailableAdapterResolutions = 3,
        AvailableAudioAdapterNumber = 4,
        AudioAdapterDescription = 5
    }
}
