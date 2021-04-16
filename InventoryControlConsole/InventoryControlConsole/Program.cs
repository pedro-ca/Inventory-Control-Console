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
                    Equipment equip = equipmentArray[i];
                    Console.WriteLine($"*Equipment {i}:");
                    Console.WriteLine("  -EquipmentName = " + equip.EquipmentName);
                    Console.WriteLine("  -AcquisitionPrice = " + equip.AcquisitionPrice);
                    Console.WriteLine("  -SerialNumber = " + equip.SerialNumber);
                    Console.WriteLine("  -ManufacturingDate = " + equip.ManufacturingDate);
                    Console.WriteLine("  -ManufacturerName = " + equip.ManufacturerName);
                    Console.WriteLine("  -Equipment name = " + equip.EquipmentName);
                }
            }
        }

        private static void ViewMaintenanceCalls()
        {
            for (int i = 0; i < maintenanceCallArray.Length; i++)
            {
                if (maintenanceCallArray[i] != null)
                {
                    MaintenanceCall maint = maintenanceCallArray[i];
                    Console.WriteLine($"*Maintenance Call {i}:");
                    Console.WriteLine("  -TitleName = " + maint.TitleName);
                    Console.WriteLine("  -DescriptioName = " + maint.DescriptioName);
                    Console.WriteLine("  -Equipment = " + maint.Equipment.EquipmentName);
                    Console.WriteLine("  -OpeningDate = " + maint.OpeningDate);
                    Console.WriteLine("  -DaysOpen = " + (DateTime.Now - maint.OpeningDate).Days.ToString());
                }
            }
        }

        private static void RegisterEquipment(Equipment newEquipment)
        {
            for (int i = 0; i < equipmentArray.Length; i++)
            {
                if(equipmentArray[i] == null)
                {
                    equipmentArray[i] = newEquipment;
                    break;
                }
            }
        }

        private static void RegisterMaintenanceCall(MaintenanceCall newMaintenanceCall)
        {
            for (int i = 0; i < maintenanceCallArray.Length; i++)
            {
                if (maintenanceCallArray[i] == null)
                {
                    maintenanceCallArray[i] = newMaintenanceCall;
                    break;
                }
            }
        }

        private static void DeleteEquipment(int arrayIndex)
        {
            if(equipmentArray[arrayIndex] != null)
            {
                equipmentArray[arrayIndex] = null;
            }
        }

        private static void DeleteMaintenanceCall(int arrayIndex)
        {
            if (maintenanceCallArray[arrayIndex] != null)
            {
                maintenanceCallArray[arrayIndex] = null;
            }
        }

        static void Main(string[] args)
        {
            //Equipment equipment1 = new Equipment("nnnome1", 420, "serial", DateTime.Now, "manufacter");
            //Equipment equipment2 = new Equipment("nnnome2", 58, "serial2", DateTime.Now.AddYears(-1), "manufacter4");
            //Equipment equipment3 = new Equipment("nnnome3", 1337, "serial3", DateTime.Now.AddDays(-180), "manufacter4");

            //ViewEquipments();
            //RegisterEquipment(equipment1);
            //RegisterEquipment(equipment2);
            //RegisterEquipment(equipment3);
            //ViewEquipments();
            //DeleteEquipment(1);
            //Console.WriteLine("-------------------");
            //ViewEquipments();
            //RegisterEquipment(new Equipment("niggaaaaa", 58, "serialx", DateTime.Now.AddYears(-21), "manufacterX"));
            //Console.WriteLine("-------------------");
            //ViewEquipments();

            //ViewMaintenanceCalls();
            //RegisterMaintenanceCall(new MaintenanceCall("title1", "description1", equipment1, DateTime.Now.AddDays(-500)));
            //RegisterMaintenanceCall(new MaintenanceCall("title2", "description3", equipment2, DateTime.Now.AddYears(-2)));
            //RegisterMaintenanceCall(new MaintenanceCall("title3", "description3", equipment3, DateTime.Now));
            //ViewMaintenanceCalls();
            //DeleteMaintenanceCall(1);
            //Console.WriteLine("-------------------");
            //ViewMaintenanceCalls();
            //RegisterMaintenanceCall(new MaintenanceCall("titleX", "description, NIGGA!", equipment3, DateTime.Now));
            //Console.WriteLine("-------------------");
            //ViewMaintenanceCalls();

            Console.ReadLine();

        }
    }
}
