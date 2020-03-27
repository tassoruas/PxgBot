using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace PxgBot.Helpers
{
    static class MemoryManager
    {
        static uint Pointer { get; set; }
        static string ProcessName { get; set; }
        static ProcessMemoryReader mReader;

        public static void StartMemoryManager(uint BasePointer, string BaseProcessName)
        {
            try
            {
                Pointer = BasePointer;
                ProcessName = BaseProcessName;

                mReader = new ProcessMemoryReader();
                Process process = Process.GetProcessesByName(ProcessName).ToList().FirstOrDefault();
                if (process != null)
                {
                    mReader.ReadProcess = process;
                    mReader.OpenProcess();
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

        public static int ReadInt(int pointerOffset, uint bytesToRead)
        {
            try
            {
                int bytesReadOut = 0;
                byte[] memoryRead = mReader.ReadMemory((IntPtr)(Pointer), bytesToRead, out bytesReadOut);
                var address = BitConverter.ToUInt32(memoryRead, 0);

                if (pointerOffset < 0)
                    address -= (uint)(Math.Abs(pointerOffset));
                else
                    address += (uint)pointerOffset;

                byte[] buffer = mReader.ReadMemory((IntPtr)address, bytesToRead, out bytesReadOut);

                int intValue = BitConverter.ToInt16(buffer, 0);

                return intValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: ReadMemory: error " + ex.Message);
                return 0;
            }
        }

        public static double ReadDouble(int pointerOffset, uint bytesToRead)
        {
            try
            {
                int bytesReadOut = 0;

                byte[] memoryRead = mReader.ReadMemory((IntPtr)(Pointer), bytesToRead, out bytesReadOut);
                var offset = BitConverter.ToUInt32(memoryRead, 0);

                if (pointerOffset < 0)
                    offset -= (uint)(Math.Abs(pointerOffset));
                else
                    offset += (uint)pointerOffset;

                byte[] buffer = mReader.ReadMemory((IntPtr)offset, bytesToRead, out bytesReadOut);

                double doubleValue = BitConverter.ToDouble(buffer, 0);

                return doubleValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: ReadMemory(double): error " + ex.Message);
                return 0;
            }
        }

        public static void WriteOnMemory(int pointerOffset, uint bytesToWrite)
        {
            int bytesReadOut = 0;

            byte[] memoryRead = mReader.ReadMemory((IntPtr)(Pointer), bytesToWrite, out bytesReadOut);
            var offset = BitConverter.ToUInt32(memoryRead, 0);

            if (pointerOffset < 0)
                offset -= (uint)(Math.Abs(pointerOffset));
            else
                offset += (uint)pointerOffset;

            mReader.WriteMemory((IntPtr)offset, BitConverter.GetBytes(bytesToWrite), out bytesReadOut);
            Console.WriteLine("WriteOnMemory: " + bytesReadOut + ", " + offset);
        }
    }
}
