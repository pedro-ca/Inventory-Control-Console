using InventoryControlModel;
using System;


namespace InventoryControlConsole
{
    class Program
    {
        private static Equipment[] equipmentArray = new Equipment[20];
        private static MaintenanceCall[] maintenanceCallArray = new MaintenanceCall[20];

        private static void ShowErrorText(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.ReadLine();
        }

        private static void ViewEquipments()
        {
            Console.WriteLine("-+-+-+-+- REGISTERED EQUIPMENTS -+-+-+-+-");
            for (int i=0; i < equipmentArray.Length; i++)
            {
                if (equipmentArray[i] != null)
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
            Console.WriteLine("-+-+-+-+- REGISTERED MAINTENANCES -+-+-+-+-");
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
        
        private static void RegisterEquipment()
        {
            try
            {
                Console.WriteLine("-Enter the name of the new equipment. Must be a string bigger than 6.");
                string name = Console.ReadLine();
                Console.WriteLine("-Enter the aquisition price of the new equipment. Must be a valid.");
                string price = Console.ReadLine();
                Console.WriteLine("-Enter the serial number.");
                string serial = Console.ReadLine();
                Console.WriteLine("-Enter the manufacturer name.");
                string manufacturer = Console.ReadLine();

                Equipment newEquipment = new Equipment(name, float.Parse(price), serial, DateTime.Now, manufacturer);

                for (int i = 0; i < equipmentArray.Length; i++)
                {
                    if (equipmentArray[i] == null)
                    {
                        equipmentArray[i] = newEquipment;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorText(e.Message);
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
        private static void EditEquiment(int arrayIndex)
        {
            if (!DeleteEquipment(arrayIndex))
            {
                ShowErrorText("Operation error: Index not found or out of bounds.");
            }
            else
            {
                RegisterEquipment();
            }
        }

        private static void EditMaintenanceCall(int arrayIndex, MaintenanceCall newMaintenanceCall)
        {
            if (!DeleteMaintenanceCall(arrayIndex))
            {
                ShowErrorText("Operation error: Index not found or out of bounds.");
            }
            else
            {
                RegisterMaintenanceCall(newMaintenanceCall);
            }
        }

        private static bool DeleteEquipment(int arrayIndex)
        {
            try
            {
                if (equipmentArray[arrayIndex] != null)
                {
                    equipmentArray[arrayIndex] = null;
                    return true;
                }
            }
            catch (IndexOutOfRangeException){}
            return false;
        }

        private static bool DeleteMaintenanceCall(int arrayIndex)
        {
            try
            {
                if (maintenanceCallArray[arrayIndex] != null)
                {
                    maintenanceCallArray[arrayIndex] = null;
                    return true; ;
                }

            }
            catch (IndexOutOfRangeException){}
            return false;
        }

        private static void EquipmentControl()
        {
            Console.WriteLine("-+-+-+-+- EQUIPMENTS -+-+-+-+-");
            Console.WriteLine("-Enter the desired operation. Commands:");
            Console.WriteLine(" * show = Show all registered equipments and atributes.");
            Console.WriteLine(" * regist = Register a new equipment.");
            Console.WriteLine(" * edit = Edit an existing equipment.");
            Console.WriteLine(" * delet = Delete an existing equipment.");
            Console.WriteLine("Equipment");
            string operationOption = Console.ReadLine();

            string indexString;
            int index;

            switch (operationOption.ToLowerInvariant())
            {
                case "show":
                    ViewEquipments();
                    break;

                case "regis":
                    Console.WriteLine("Reg");
                    break;

                case "edit":
                    ViewEquipments();
                    Console.WriteLine("-Enter the index of the Equipment to edit. Must be an integer.");
                    indexString = Console.ReadLine();
                    if (int.TryParse(indexString, out index))
                    {
                        EditEquiment(index)
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }

                    break;

                case "delet":
                    ViewEquipments();
                    Console.WriteLine("-Enter the index of the Equipment to delete. Must be an integer.");
                    indexString = Console.ReadLine();
                    if(int.TryParse(indexString, out  index))
                    {
                        if (!DeleteMaintenanceCall(index))
                        {
                            ShowErrorText("Operation error: Index not found or out of bounds.");
                        }
                    }
                    else
                    {
                        ShowErrorText("Operation error: Index must be a valid integer number.");
                    }
                    break;

                default:
                    ShowErrorText("Operation error: Use only one of the available commands.");
                    break;
            }
        }

        private static void MaintenanceCallControl()
        {

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-+-+-+-+- INVENTORY CONTROL CONSOLE -+-+-+-+-");
                Console.WriteLine("-Do you want to administrate Equipments or Maintenance Calls? Commands:");
                Console.WriteLine(" * equip = Show, Register, Edit and Delete Equipments.");
                Console.WriteLine(" * maint = Show, Register, Edit and Delete Maintenance Calls.");
                Console.WriteLine(" * Any other commmand = Exits from the console.");
                string operationOption = Console.ReadLine();

                if (operationOption.ToLowerInvariant() == "equip")
                {
                    EquipmentControl();

                }
                else if (operationOption.ToLowerInvariant() == "maint")
                {
                    MaintenanceCallControl();
                }
                else
                {
                    break;
                }
                Console.ReadLine();
            }

            //try
            //{
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine("Operation error: " + e.Message);
            //}

            //ViewEquipments();
            //RegisterEquipment(equipment1);
            //RegisterEquipment(equipment2);
            //RegisterEquipment(equipment3);
            //ViewEquipments();
            //if (DeleteEquipment(5))
            //{
            //    Console.WriteLine("Equipment deleted sucessfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Operation error: Index not found or out of bounds.");
            //}
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
            //EditMaintenanceCall(1, new MaintenanceCall("titleX", "description, NIGGA!", equipment3, DateTime.Now));
            //Console.WriteLine("-------------------");
            //ViewMaintenanceCalls();
        }
    }
}
