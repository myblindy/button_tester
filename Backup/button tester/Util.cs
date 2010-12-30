using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lj;

namespace button_tester
{
    [Serializable]
    public class Pair<T, U>
    {
        public Pair() { }

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };


    public static class Util
    {
        private static object lockobj=new object();

#if MOCKUP
        private static frmMockUp MockUp = new frmMockUp();
#endif

        public static void Init()
        {
#if MOCKUP
            MockUp.Show();
#endif
        }

        public static int ReadDigitalInput(int channel, bool readD)
        {
#if MOCKUP
            lock (lockobj)
            {
                return MockUp.GetDState(channel-1) ? 1 : 0;
            }
#else
            lock (lockobj)
            {
                int ljID = 0;
                int state = 0;

                int result = LabJack.EDigitalIn(ref ljID, 0, channel - 1, readD ? 1 : 0, ref state);
                if (result != 0)
                    throw new Exception("Error reading digital input");

                return state;
            }
#endif
        }

        public static void SetDigitalOutput(int channel, bool writeD, int state)
        {
#if MOCKUP
            lock (lockobj)
            {
                MockUp.SetDState(channel-1, state != 0);
            }
#else
            lock (lockobj)
            {
                int ljID = 0;

                int result = LabJack.EDigitalOut(ref ljID, 0, channel - 1, writeD ? 1 : 0, state);
                if (result != 0)
                    throw new Exception("Error setting digital output");
            }
#endif
        }

        public static long Counter(bool reset)
        {
#if MOCKUP
            return 0;
#else
            lock (lockobj)
            {
                int ljID = 0;
                int stated=0, stateio=0;
                uint cnt = 0;

                long result = LabJack.Counter(ref ljID, 0, ref stated, ref stateio,
                    reset ? 1 : 0, 0, ref cnt);
                if (result != 0)
                    throw new Exception("Error reading the counter");

                return cnt;
            }
#endif
        }

        public static float ReadAnalogInput(int channel)
        {
#if MOCKUP
            return MockUp.GetAState(0);
#else
            lock (lockobj)
            {
                int ljID = 0;
                int overVoltage = 0;
                float voltage = 0.0f;

                int result = LabJack.EAnalogIn(ref ljID, 0, channel, 0, ref overVoltage, ref voltage);
                if (result != 0)
                    throw new Exception("Error reading analog input");
                return voltage;
            }
#endif
        }

        public static int ReadDigital()
        {
#if MOCKUP
            lock (lockobj)
            {
                int result = 0;

                for (int p = 1, n = 0; n < 16; ++n, p <<= 1)
                    if (MockUp.GetDState(n))
                        result |= p;

                return result;
            }
#else
            lock (lockobj)
            {
                int ljID = 0;
                int outputd = 0;
                int trisd = 0xff00;
                int stateio = 0;
                int stated = 0;

                int res = LabJack.DigitalIO(ref ljID, 0, ref trisd, 0, ref stated, ref stateio,
                    0, ref outputd);
                if (res != 0)
                    throw new Exception("Error reading digital inputs");

                return stated;
            }
#endif
        }

        public static void ResetOutputs()
        {
            for (int i = 1; i <= 8; ++i)
                SetDigitalOutput(i, true, 0);
        }

        public static bool ValidPin(int pid)
        {
            return pid >= 1 && pid <= 8;
        }
    }
}
