using System;
using System.Collections.Generic;
using System.Management;

namespace SmartHDD
{
    static class Program
    {
        static void Main()
        {
            int iDriveIndex = 0;
            try
            {
                var dictHdd = new Dictionary<string, HardDisk>();
                var searcher = new ManagementObjectSearcher();
                
                //searcher.Query = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
                //var diskDriveList = searcher.Get();
                //foreach (var diskDrive in diskDriveList)
                //{
                //    foreach (var item in diskDrive.Properties)
                //    {
                //        Console.WriteLine($"{item.Name}: {item.Value}");
                //    }
                //}

                searcher.Scope = new ManagementScope(@"\root\wmi");
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictStatus");
                var failurePredictStatus = searcher.Get();

                foreach (var status in failurePredictStatus)
                {
                    //foreach (var item in status.Properties)
                    //{
                    //    Console.WriteLine($"{item.Name}: {item.Value}");
                    //}
                    //Console.WriteLine();

                    var hdd = new HardDisk();
                    hdd.InstanceName   = status["InstanceName"].ToString();
                    hdd.PredictFailure = status["PredictFailure"].ToString();
                    dictHdd.Add(hdd.InstanceName, hdd);
                }

                //foreach (var drive in failurePredictStatus)
                //{
                //    dicDrivers[iDriveIndex].IsOK = (bool)drive.Properties["PredictFailure"].Value == false;
                //    iDriveIndex++;
                //}

                // retrive attribute flags, value worste and vendor data information
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictData");
                var failurePredictData = searcher.Get();

                foreach (var data in failurePredictData)
                {
                    //foreach (var item in data.Properties)
                    //{
                    //    Console.WriteLine($"{item.Name}: {item.Value}");
                    //}
                    //Console.WriteLine();

                    
                    var instanceName = data["InstanceName"].ToString();
                    var vendorSpecific = (byte[])data.Properties["VendorSpecific"].Value;

                    for (var i = 0; i < 30; ++i)
                    {
                        try
                        {
                            int id = vendorSpecific[i * 12 + 2];

                            int flags = vendorSpecific[i * 12 + 4]; // least significant status byte, +3 most significant byte, but not used so ignored.
                            //bool advisory = (flags & 0x1) == 0x0;
                            bool failureImminent = (flags & 0x1) == 0x1;
                            //bool onlineDataCollection = (flags & 0x2) == 0x2;

                            int value = vendorSpecific[i * 12 + 5];
                            int worst = vendorSpecific[i * 12 + 6];
                            int vendordata = BitConverter.ToInt32(vendorSpecific, i * 12 + 7);
                            if (id == 0) continue;

                            var attr = dictHdd[instanceName].Attributes[id];
                            attr.Current = value;
                            attr.Worst = worst;
                            attr.Data = vendordata;
                            attr.FailureImminent = failureImminent;
                        }
                        catch
                        {
                            // given key does not exist in attribute collection (attribute not in the dictionary of attributes)
                        }
                    }
                }




                // retreive threshold values foreach attribute
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictThresholds");
                var failurePredictThresholds = searcher.Get();

                foreach (var thresholds in failurePredictThresholds)
                {
                    var instanceName = thresholds["InstanceName"].ToString();
                    var vendorSpecific = (byte[])thresholds.Properties["VendorSpecific"].Value;

                    for (var i = 0; i < 30; ++i)
                    {
                        try
                        {

                            int id = vendorSpecific[i * 12 + 2];
                            int thresh = vendorSpecific[i * 12 + 3];
                            if (id == 0) continue;

                            var attr = dictHdd[instanceName].Attributes[id];
                            attr.Threshold = thresh;
                        }
                        catch
                        {
                            // given key does not exist in attribute collection (attribute not in the dictionary of attributes)
                        }
                    }

                    iDriveIndex++;
                }


                // print
                foreach (var drive in dictHdd)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine($" DRIVE ({drive.Value.InstanceName}): PredictFailure {drive.Value.PredictFailure}");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("");

                    Console.WriteLine("ID                   Current  Worst  Threshold  Data  Status");
                    foreach (var attr in drive.Value.Attributes)
                    {
                        if (attr.Value.HasData)
                            Console.WriteLine("{0}\t {1}\t {2}\t {3}\t " + attr.Value.Data + " " + ((attr.Value.FailureImminent) ? "OK" : ""), attr.Value.Attribute, attr.Value.Current, attr.Value.Worst, attr.Value.Threshold);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }
    }
}
