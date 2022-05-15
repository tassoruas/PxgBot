using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using PxgBot.Classes;

namespace PxgBot.Helpers
{
    static class MemoryManager
    {
        static int Pointer { get; set; }
        static int BaseAddress { get; set; }
        static string ProcessName { get; set; }
        static ProcessMemoryReader memoryReader;

        public static void StartMemoryManager(uint BasePointer, string BaseProcessName)
        {
            try
            {
                Pointer = (int)BasePointer;
                ProcessName = BaseProcessName;

                memoryReader = new ProcessMemoryReader();
                Process process = Process.GetProcessesByName(ProcessName).ToList().FirstOrDefault();
                if (process != null)
                {
                    BaseAddress = process.MainModule.BaseAddress.ToInt32() + Pointer;
                    memoryReader.OpenProcess(process);
                }
                else
                {
                    throw new Exception("Couldn't find process");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: Constructor: error " + ex.Message);
            }
        }

        public static int ReadInt(int offset, uint bytesToRead)
        {
            try
            {
                int bytesReadOut = 0;
                byte[] memoryRead = memoryReader.ReadMemory((IntPtr)(BaseAddress), bytesToRead, out bytesReadOut);
                var address = BitConverter.ToUInt32(memoryRead, 0);

                if (offset < 0)
                    address -= (uint)(Math.Abs(offset));
                else
                    address += (uint)offset;

                byte[] buffer = memoryReader.ReadMemory((IntPtr)address, bytesToRead, out bytesReadOut);

                int intValue = BitConverter.ToInt16(buffer, 0);

                return intValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: ReadMemory: error " + ex.Message);
                return 0;
            }
        }

        public static double ReadDouble(int offset, uint bytesToRead)
        {
            try
            {
                int bytesReadOut = 0;

                byte[] memoryRead = memoryReader.ReadMemory((IntPtr)(BaseAddress), bytesToRead, out bytesReadOut);
                var address = BitConverter.ToUInt32(memoryRead, 0);

                if (offset < 0)
                    address -= (uint)(Math.Abs(offset));
                else
                    address += (uint)offset;

                byte[] buffer = memoryReader.ReadMemory((IntPtr)address, bytesToRead, out bytesReadOut);

                double doubleValue = BitConverter.ToDouble(buffer, 0);

                return doubleValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: ReadMemory(double): error " + ex.Message);
                return 0;
            }
        }

        public static void WriteOnMemory(int offset, uint bytesToWrite)
        {
            try
            {

                int bytesReadOut = 0;

                byte[] memoryRead = memoryReader.ReadMemory((IntPtr)(BaseAddress), bytesToWrite, out bytesReadOut);
                var address = BitConverter.ToUInt32(memoryRead, 0);

                if (offset < 0)
                    address -= (uint)(Math.Abs(offset));
                else
                    address += (uint)offset;

                memoryReader.WriteMemory((IntPtr)address, BitConverter.GetBytes(bytesToWrite), out bytesReadOut);
                if (Settings.Debug) { Settings.DebugText += "\n WriteOnMemory: " + bytesReadOut + ", " + address; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: WriteOnMemory: error " + ex.Message);
            }
        }
    }
}
