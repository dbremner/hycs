using System;
using System.Collections;
using System.Management;

class MainClass
{
    public static string GetCPUId()
    {
        string cpuInfo =  String.Empty;
        string temp=String.Empty;
        ManagementClass mc = new ManagementClass("Win32_Processor");
        ManagementObjectCollection moc = mc.GetInstances();
        foreach(ManagementObject mo in moc)
        {
            if(cpuInfo==String.Empty)
            {// only return cpuInfo from first CPU
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
        }
        return cpuInfo;
    }

    public static ArrayList GetMACAddress()
    {
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        ArrayList MACAddress = new ArrayList();

        foreach (ManagementObject mo in moc)
        {
            if (mo["MacAddress"] != null)
            MACAddress.Add(mo["MacAddress"].ToString().Replace(":", ""));

            mo.Dispose();
        }
        return MACAddress;
    }

    public string GetDefaultIPGateway()
    {
        //create out management class object using the
        //Win32_NetworkAdapterConfiguration class to get the attributes
        //of the network adapter
        ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //create our ManagementObjectCollection to get the attributes with
        ManagementObjectCollection objCol = mgmt.GetInstances();
        string gateway = String.Empty;
        //loop through all the objects we find
        foreach (ManagementObject obj in objCol)
        {
            if (gateway == String.Empty)  // only return MAC Address from first card
            {
                //grab the value from the first network adapter we find
                //you can change the string to an array and get all
                //network adapters found as well
                //check to see if the adapter's IPEnabled
                //equals true
                if ((bool)obj["IPEnabled"] == true)
                {
                    gateway = obj["DefaultIPGateway"].ToString();
                }
            }
            //dispose of our object
            obj.Dispose();
        }
        //replace the ":" with an empty space, this could also
        //be removed if you wish
        gateway = gateway.Replace(":", "");
        //return the mac address
        return gateway;
    }

    public static string GetVolumeSerial(string strDriveLetter)
    {
        if( strDriveLetter=="" || strDriveLetter==null)
        {
            strDriveLetter="C";
        }

        ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter +":\"");
        disk.Get();
        return disk["VolumeSerialNumber"].ToString();
    }

    /// <summary>
    /// method for retrieving the CPU Manufacturer
    /// using the WMI class
    /// </summary>
    /// <returns>CPU Manufacturer</returns>
    public static string GetCPUManufacturer()
    {
        string cpuMan = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuMan == String.Empty)
            {
                // only return manufacturer from first CPU
                cpuMan = obj.Properties["Manufacturer"].Value.ToString();
            }
        }
        return cpuMan;
    }

    public string GetCPUStatus()
    {
        string cpuStatus = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuStatus == String.Empty)
            {
                // only return cpuStatus from first CPU
                cpuStatus = obj.Properties["Status"].Value.ToString();
            }
        }
        //return the status
        return cpuStatus;
    }

    public int GetCPUCurrentClockSpeed()
    {
        int cpuClockSpeed = 0;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuClockSpeed == 0)
            {
                // only return cpuStatus from first CPU
                cpuClockSpeed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
            }
        }
        //return the status
        return cpuClockSpeed;
    }

    static void GetWMIStats()
    {
        long mb = 1048576; //megabyte in # of bytes 1024x1024

        //Connection credentials to the remote computer - not needed if the logged in account has access
        ConnectionOptions oConn = new ConnectionOptions();
        //oConn.Username = "username";
        //oConn.Password = "password";
        System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\\\localhost", oConn);

        //get Fixed disk stats
        System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
        ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs,oQuery);
        ManagementObjectCollection oReturnCollection = oSearcher.Get();

        //variables for numerical conversions
        double fs = 0;
        double us = 0;
        double tot = 0;
        double up = 0;
        double fp = 0;

        //for string formating args
        object[] oArgs = new object[2];
        Console.WriteLine("*******************************************");
        Console.WriteLine("Hard Disks");
        Console.WriteLine("*******************************************");

        //loop through found drives and write out info
        foreach( ManagementObject oReturn in oReturnCollection )
        {
            // Disk name
            Console.WriteLine("Name : " + oReturn["Name"].ToString());

            //Free space in MB
            fs = Convert.ToInt64(oReturn["FreeSpace"])/mb;

            //Used space in MB
            us = (Convert.ToInt64(oReturn["Size"]) - Convert.ToInt64(oReturn["FreeSpace"]))/mb;

            //Total space in MB
            tot = Convert.ToInt64(oReturn["Size"])/mb;

            //used percentage
            up = us/tot * 100;

            //free percentage
            fp = fs/tot * 100;

            //used space args
            oArgs[0] = (object)us;
            oArgs[1] = (object)up;

            //write out used space stats
            Console.WriteLine("Used: {0:#,###.##} MB ({1:###.##})%", oArgs);

            //free space args
            oArgs[0] = fs;
            oArgs[1] = fp;

            //write out free space stats
            Console.WriteLine("Free: {0:#,###.##} MB ({1:###.##})%", oArgs);
            Console.WriteLine("Size :  {0:#,###.##} MB", tot);
            Console.WriteLine("*******************************************");
        }

        // Get process info including a method to return the user who is running it
        oQuery = new System.Management.ObjectQuery("select * from Win32_Process");
        oSearcher = new ManagementObjectSearcher(oMs,oQuery);
        oReturnCollection = oSearcher.Get();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("*******************************************");
        Console.WriteLine("Processes");

        Console.WriteLine("*******************************************");
        Console.WriteLine("");

        //loop through each process - I limited it to first 6 so the DOS buffer would not overflow and cut off the disk stats
        int i=0;
        foreach( ManagementObject oReturn in oReturnCollection )
        {
            if(i==6)
            break;
            i++;
            Console.WriteLine("*******************************************");
            Console.WriteLine(oReturn["Name"].ToString().ToLower());
            Console.WriteLine("*******************************************");
            //arg to send with method invoke to return user and domain - below is link to SDK doc on it
            //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wmisdk/wmi/getowner_method_in_class_win32_process.asp?frame=true
            string[] o = new String[2];
            oReturn.InvokeMethod("GetOwner",(object[])o);
            //write out user info that was returned
            Console.WriteLine("User: " + o[1]+ "\\" + o[0]);
            Console.WriteLine("PID: " + oReturn["ProcessId"].ToString());

            //get priority
            if(oReturn["Priority"] != null)
            Console.WriteLine("Priority: " + oReturn["Priority"].ToString());

            //get creation date - need managed code function to convert date -
            if(oReturn["CreationDate"] != null)
            {
                try
                {
                    //get datetime string and convert
                    string s = oReturn["CreationDate"].ToString();
                    DateTime dc = ToDateTime(s);
                    //write out creation date
                    Console.WriteLine("CreationDate: " + dc.AddTicks(-TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Ticks).ToLocalTime().ToString());
                }
                //just in case - I was getting a weird error on some entries
                catch(Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            //this is the amount of memory used
            if(oReturn["WorkingSetSize"] != null)
            {
                long mem =  Convert.ToInt64(oReturn["WorkingSetSize"].ToString()) / 1024;
                Console.WriteLine("Mem Usage: {0:#,###.##}Kb",mem);
            }
            Console.WriteLine("");
        }
    }

    //There is a utility called mgmtclassgen that ships with the .NET SDK that
    //will generate managed code for existing WMI classes. It also generates
    // datetime conversion routines like this one.
    //Thanks to Chetan Parmar and dotnet247.com for the help.
    static System.DateTime ToDateTime(string dmtfDate)
    {
        int year = System.DateTime.Now.Year;
        int month = 1;
        int day = 1;
        int hour = 0;
        int minute = 0;
        int second = 0;
        int millisec = 0;
        string dmtf = dmtfDate;
        string tempString = System.String.Empty;

        if (((System.String.Empty == dmtf) || (dmtf == null)))
        {
            return System.DateTime.MinValue;
        }

        if ((dmtf.Length != 25))
        {
            return System.DateTime.MinValue;
        }

        tempString = dmtf.Substring(0, 4);
        if (("****" != tempString))
        {
            year = System.Int32.Parse(tempString);
        }

        tempString = dmtf.Substring(4, 2);

        if (("**" != tempString))
        {
            month = System.Int32.Parse(tempString);
        }

        tempString = dmtf.Substring(6, 2);

        if (("**" != tempString))
        {
            day = System.Int32.Parse(tempString);
        }

        tempString = dmtf.Substring(8, 2);

        if (("**" != tempString))
        {
            hour = System.Int32.Parse(tempString);
        }

        tempString = dmtf.Substring(10, 2);

        if (("**" != tempString))
        {
            minute = System.Int32.Parse(tempString);
        }

        tempString = dmtf.Substring(12, 2);

        if (("**" != tempString))
        {
            second = System.Int32.Parse(tempString);
        }

        tempString = dmtf.Substring(15, 3);

        if (("***" != tempString))
        {
            millisec = System.Int32.Parse(tempString);
        }

        System.DateTime dateRet = new System.DateTime(year, month, day, hour, minute, second, millisec);

        return dateRet;
    }

    public static void Main()
    {

        Console.WriteLine("CPUID : " + GetCPUId());
        Console.WriteLine("Manufacturer: " + GetCPUManufacturer());

        Console.WriteLine("Volume C: serial : " + GetVolumeSerial(null));

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
