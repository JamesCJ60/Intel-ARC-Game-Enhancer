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


        public static void start()
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
        }

        public static string GetCPUName()
        {

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

        public static int cpuTemp, cpuPower, cpuClock, cpuLoad;
        public static float cpuVolt;

        public static void getCPUStats()
        {
            try
            {
                foreach (var hardware in thisPC.Hardware)
                {
                    hardware.Update();
                    if (hardware.HardwareType == HardwareType.Cpu)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Core"))
                            {
                                cpuTemp = (int)sensor.Value.GetValueOrDefault();
                            }

                            if (sensor.SensorType == SensorType.Power && sensor.Name.Contains("Package"))
                            {
                                cpuPower = (int)sensor.Value.GetValueOrDefault();
                            }

                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("1"))
                            {
                                cpuClock = (int)sensor.Value.GetValueOrDefault();
                            }

                            if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Total"))
                            {
                                cpuLoad = (int)sensor.Value.GetValueOrDefault();
                            }

                            if (sensor.SensorType == SensorType.Voltage && sensor.Name.Contains("Core"))
                            {
                                cpuVolt = sensor.Value.GetValueOrDefault() * 1000;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        public static string GetdGPUName()
        {
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

        public static int dGPUClock;
        public static int dGPUMemClock;
        public static int dGPUPower;
        public static int dGPUTemp;
        public static int dGPULoad;
        public static float dGPUVolt;


        public static void GetdGPUStats()
        {
            try
            {
                foreach (var hardware in thisPC.Hardware)
                {
                    hardware.Update();
                    if (hardware.HardwareType == HardwareType.GpuAmd)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("Core"))
                            {
                                if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                                {
                                    if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                    {

                                    }
                                    else dGPUClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                } else dGPUClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("Mem"))
                            {
                                if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                                {
                                    if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                    {

                                    }
                                    else dGPUMemClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                }
                                else dGPUMemClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());

                            }

                            if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Core"))
                            {
                                if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                                {
                                    if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                    {


                                    } else dGPUTemp = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                }else dGPUTemp = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Power && sensor.Name.Contains("Core"))
                            {
                                if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                                {
                                    if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                    {

                                    } else dGPUPower = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                }
                                else dGPUPower = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("Mem"))
                            {
                                if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                                {
                                    if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                    {

                                    }
                                    else dGPUClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                }
                                else dGPUClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Core"))
                            {
                                if (!hardware.Name.Contains("56") || !hardware.Name.Contains("64"))
                                {
                                    if (hardware.Name.Contains("Vega") && hardware.Name.Contains("3") || hardware.Name.Contains("Vega") && hardware.Name.Contains("6") || hardware.Name.Contains("Vega") && hardware.Name.Contains("8") || hardware.Name.Contains("Vega") && hardware.Name.Contains("9") || hardware.Name.Contains("Vega") && hardware.Name.Contains("10") || hardware.Name.Contains("Vega") && hardware.Name.Contains("11") || hardware.Name == "AMD Radeon Graphics" || hardware.Name == "AMD Radeon(TM) Graphics" || hardware.Name == "AMD Radeon RX Vega Graphics")
                                    {

                                    }
                                    else dGPULoad = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                                }
                                else dGPULoad = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }
                        }
                    }

                    if (hardware.HardwareType == HardwareType.GpuNvidia)
                    {
                        foreach (var sensor in hardware.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("Core"))
                            {
                                dGPUClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("Mem"))
                            {
                                dGPUMemClock = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Core"))
                            {
                                dGPUTemp = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Core"))
                            {
                                dGPULoad = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Power && sensor.Name.Contains("GPU"))
                            {
                                dGPUPower = Convert.ToInt32(sensor.Value.GetValueOrDefault());
                            }

                            if (sensor.SensorType == SensorType.Voltage)
                            {
                                dGPUVolt = sensor.Value.GetValueOrDefault() * 1000;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
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
