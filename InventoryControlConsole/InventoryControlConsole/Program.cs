using InventoryControlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryControlConsole
{
    class Program
    {
        private static Equipment[] equipmentArray = new Equipment[20];
        private static MaintenanceCall[] maintenanceCallArray = new MaintenanceCall[20];

        private static void ViewEquipments()
        {
            for(int i=0; i < equipmentArray.Length; i++)
            {
               if(equipmentArray[i] != null)
                {
                    Console.WriteLine($"Equipment {i}:");
                    Console.WriteLine("   -EquipmentName = " + equipmentArray[i].EquipmentName);
                    Console.WriteLine("   -AcquisitionPrice = " + equipmentArray[i].AcquisitionPrice);
                    Console.WriteLine("   -SerialNumber = " + equipmentArray[i].SerialNumber);
                    Console.WriteLine("   -ManufacturingDate = " + equipmentArray[i].ManufacturingDate);
                    Console.WriteLine("   -ManufacturerName = " + equipmentArray[i].ManufacturerName);
                    Console.WriteLine("   -Equipment name = " + equipmentArray[i].EquipmentName);
                }
            }
        }

        private static void ViewMaintenanceCalls()
        {
            for (int i = 0; i < maintenanceCallArray.Length; i++)
            {
                if (maintenanceCallArray[i] != null)
                {
                    Console.WriteLine($"Maintenance Call {i}:");
                    Console.WriteLine("   -TitleName = " + maintenanceCallArray[i].TitleName);
                    Console.WriteLine("   -DescriptioName = " + maintenanceCallArray[i].DescriptioName);
                    Console.WriteLine("   -Equipment = " + maintenanceCallArray[i].Equipment.EquipmentName);
                    Console.WriteLine("   -OpeningDate = " + maintenanceCallArray[i].OpeningDate);
                }
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
