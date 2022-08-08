using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using LibreHardwareMonitor;
using LibreHardwareMonitor.Hardware;

namespace Flow_Control.Scripts
{
    internal class GetSystemInfo
    {
        public static Computer thisPC;
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }


        public static string GetCPUName()
        {
            thisPC = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsBatteryEnabled = true,
                IsPsuEnabled = true,
                IsControllerEnabled = true,
                IsMotherboardEnabled = true
            };
            thisPC.Open();
            thisPC.Accept(new UpdateVisitor());

            try
            {
                foreach (var hardware in thisPC.Hardware)
                {
                    hardware.Update();
                    if (hardware.HardwareType == HardwareType.Cpu)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            return hardware.Name;
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return "";
        }

        public static string GetiGPUName()
        {
            thisPC = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsBatteryEnabled = true,
                IsPsuEnabled = true,
                IsControllerEnabled = true,
                IsMotherboardEnabled = true
            };
            thisPC.Open();
            thisPC.Accept(new UpdateVisitor());

            try
            {
                foreach (var hardware in thisPC.Hardware)
                {
                    hardware.Update();
                    if (hardware.HardwareType == HardwareType.GpuAmd)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {

                            if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                            {
                                if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                {
                                    return hardware.Name;
                                }
                            }

                        }
                    }

                    if(hardware.HardwareType == HardwareType.GpuIntel)
                    {
                        return hardware.Name;
                    }
                }
            }
            catch (Exception ex) { }

            return "";
        }


        public static string GetdGPUName()
        {
            thisPC = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsBatteryEnabled = true,
                IsPsuEnabled = true,
                IsControllerEnabled = true,
                IsMotherboardEnabled = true
            };
            thisPC.Open();
            thisPC.Accept(new UpdateVisitor());

            try
            {
                foreach (var hardware in thisPC.Hardware)
                {
                    hardware.Update();
                    if (hardware.HardwareType == HardwareType.GpuAmd)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {

                            if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                            {
                                if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                {

                                }
                                else
                                {
                                    return hardware.Name;
                                }
                            }
                            else
                            {
                                return hardware.Name;
                            }
                        }
                    }

                    else if (hardware.HardwareType == HardwareType.GpuNvidia)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            return hardware.Name;
                        }
                    }
                }
            }
            catch (Exception ex) { return ""; }

            return "";
        }

        public static string brightness;


        //create a management scope object
        public static ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\WMI");

        public static void getBrightness()
        {
            try
            {
                //create object query
                ObjectQuery query = new ObjectQuery("SELECT * FROM WmiMonitorBrightness");

                //create object searcher
                ManagementObjectSearcher searcher =
                                        new ManagementObjectSearcher(scope, query);

                //get a collection of WMI objects
                ManagementObjectCollection queryCollection = searcher.Get();

                //enumerate the collection.
                foreach (ManagementObject m in queryCollection)
                {
                    // access properties of the WMI object
                    brightness = m["CurrentBrightness"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}
