using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using PxgBot.Classes;

namespace PxgBot.Helpers
{
    static class MemoryManager
    {
        static int BaseAddress { get; set; }
        static string ProcessName { get; set; }
        static ProcessMemoryReader memoryReader;

        public static void StartMemoryManager(string BaseProcessName)
        {
            try
            {
                ProcessName = BaseProcessName;

                memoryReader = new ProcessMemoryReader();
                Process process = Process.GetProcessesByName(ProcessName).ToList().FirstOrDefault();
                if (process != null)
                {
                    BaseAddress = process.MainModule.BaseAddress.ToInt32();
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

        public static int ReadInt(int pointer, int offset, uint bytesToRead, bool isPointer = true)
        {
            try
            {
                int bytesReadOut = 0;
                uint address = 0;
                if (isPointer)
                {
                    byte[] memoryRead = memoryReader.ReadMemory((IntPtr)(BaseAddress + pointer), bytesToRead, out bytesReadOut);
                    address = BitConverter.ToUInt32(memoryRead, 0);
                }
                else
                    address = (uint)(BaseAddress + pointer);

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

        public static double ReadDouble(int pointer, int offset, uint bytesToRead, bool isPointer = true)
        {
            try
            {
                int bytesReadOut = 0;
                uint address = 0;
                if (isPointer)
                {
                    byte[] memoryRead = memoryReader.ReadMemory((IntPtr)(BaseAddress + pointer), bytesToRead, out bytesReadOut);
                    address = BitConverter.ToUInt32(memoryRead, 0);
                }
                else
                    address = (uint)(BaseAddress + pointer);

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

        public static void WriteOnMemory(int pointer, int offset, uint bytesToWrite, bool isPointer = true)
        {
            try
            {

                int bytesReadOut = 0;
                uint address = 0;
                if (isPointer)
                {
                    byte[] memoryRead = memoryReader.ReadMemory((IntPtr)(BaseAddress + pointer), bytesToWrite, out bytesReadOut);
                    address = BitConverter.ToUInt32(memoryRead, 0);
                }
                else
                    address = (uint)(BaseAddress + pointer);

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
