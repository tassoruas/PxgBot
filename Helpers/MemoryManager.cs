using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace PxgBot.Helpers
{
    class MemoryManager
    {
        uint Pointer { get; set; }
        string ProcessName { get; set; }
        ProcessMemoryReader mReader;

        public MemoryManager(uint BasePointer, string BaseProcessName)
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
                    throw new Exception("Couldnt find process");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: Constructor: error " + ex.Message);
            }
        }

        public int ReadInt(int pointerOffset, uint bytesToRead)
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

                int intValue = BitConverter.ToInt16(buffer, 0);

                return intValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MemoryManager: ReadMemory: error " + ex.Message);
                return 0;
            }
        }

        public double ReadDouble(int pointerOffset, uint bytesToRead)
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
    }
}
