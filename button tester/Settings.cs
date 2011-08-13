using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace button_tester
{
    public class Settings
    {
        [Serializable]
        [XmlInclude(typeof(ActionButtonPress)), XmlInclude(typeof(ActionDelay))]
        [XmlInclude(typeof(ActionEnd))]
        public class PayloadClass
        {
            [Serializable]
            [XmlInclude(typeof(ActionButtonPress)), XmlInclude(typeof(ActionDelay))]
            [XmlInclude(typeof(ActionEnd))]
            public abstract class Action
            {
                public abstract string GetTypeName();
                public abstract string GetDetails();
            }

            /// <summary>
            /// Presses one of the buttons
            /// </summary>
            [Serializable]
            public class ActionButtonPress : Action
            {
                /// <summary>
                /// The buttons I can choose to press at one time.
                /// Just use one item if it's deterministic
                /// </summary>
                public List<ButtonType> Buttons { get; set; }

                public Pair<double, double> PressedTime { get; set; }

                public bool UseAll { get; set; }

                public ActionButtonPress()
                {
                    Buttons = new List<ButtonType>();
                    PressedTime = new Pair<double, double>();
                }

                public override string GetTypeName()
                {
                    return "Button Press";
                }

                public override string GetDetails()
                {
                    bool first = true;
                    string ret = "";

                    foreach (var btn in Buttons)
                    {
                        if (!first)
                            ret += UseAll?"+":",";

                        ret += btn.Name+"("+btn.PinID+")";

                        first = false;
                    }

                    return ret + " (" + PressedTime.First.ToString() +
                        "s - " + PressedTime.Second.ToString() + "s)";
                }
            }

            /// <summary>
            /// Inserts a random delay in a given range
            /// </summary>
            [Serializable]
            public class ActionDelay : Action
            {
                /// <summary>
                /// The delay range
                /// </summary>
                public Pair<double, double> Range { get; set; }

                public ActionDelay()
                {
                    Range = new Pair<double, double>();
                }

                public override string GetTypeName()
                {
                    return "Delay";
                }

                public override string GetDetails()
                {
                    if (Range.Second - Range.First < 0.0001)
                        return Range.First + "s";
                    else
                        return Range.First + "s - " + Range.Second + "s";
                }
            }

            /// <summary>
            /// Signifies the end of the program
            /// </summary>
            [Serializable]
            public class ActionEnd : Action
            {
                public override string GetTypeName()
                {
                    return "End Marker";
                }

                public override string GetDetails()
                {
                    return "";
                }
            }

            public class ButtonType
            {
                public string Name;
                public int PinID;
            }

            public List<ButtonType> Buttons = new List<ButtonType>();

            public int Version { get; set; }

            public List<Action> Actions { get; set; }
            public bool StopOnErrors = true;

            public bool UseCycles = false;
            public TestExpression CycleCondition = new TestExpression();
            public int? StopAtCycles = null;

            public Pair<int, int> OfflineRange { get; set; }
            public Pair<int, int> OfflineRange2 { get; set; }
            public Pair<int, int> OfflineLineProcRange { get; set; }

            public double ZeroToleranceHigh { get; set; }
            public double ZeroToleranceLow { get; set; }

            public int? TestPilotLightPin { get; set; }

            public double LastCounterChangeMovementCap
            {
                get;
                set;
            }

            public int PowerOffPin { get; set; }

            public class Priority
            {
                public enum PriorityState
                {
                    Used,
                    NotUsed,
                    NotUsedAndReset
                }

                public TestExpression Condition { get; set; }
                public TestExpression ExitCondition { get; set; }
                public List<Pair<int, PriorityState>> PriorityOrder { get; set; }

                public Priority() 
                { 
                    Condition = new TestExpression();
                    ExitCondition = new TestExpression();
                    PriorityOrder = new List<Pair<int, PriorityState>>();
                }
                public override string ToString()
                {
                    return PriorityOrder.Aggregate("Order: ", (a, n) =>
                    {
                        string b = "", e = "";
                        if(n.Second== PriorityState.NotUsed)   
                        {
                            b = "("; e = ")";
                        }
                        else if(n.Second== PriorityState.NotUsedAndReset)
                        {
                            b="[";e="]";
                        }

                        return a + b + (n.First + 1) + e + " ";
                    });
                }
            }

            public List<Priority> Priorities { get; set; }

            public class TestSet
            {
                public enum ResultType
                {
                    Up,
                    Down,
                    StayStill
                }

                public TestExpression Condition { get; set; }
                public int Delay { get; set; }
                public ResultType Result { get; set; }

                public override string ToString()
                {
                    return Condition.Expression + ": " + Result;
                }

                public TestSet()
                {
                    Condition = new TestExpression();
                }
            }

            public List<TestSet> TestSets { get; set; }

            public SerializableDictionary<int, string> DigitalNameOverrides = new SerializableDictionary<int, string>();
            public int? ClockOutputChannel { get; set; }

            public int? WaitBeforeAnalogChanges { get; set; }

            public SerializableDictionary<int, int> Links { get; set; }

            public bool ReverseDirection { get; set; }

            public enum HysteresisKind
            {
                Humidity,
                Temperature,
            }

            public class HysteresisPayload
            {
                public double From, To;
                public int PinID;
            }

            public SerializableDictionary<HysteresisKind, HysteresisPayload> Hysteresis { get; set; }
            public SerializableDictionary<int, HysteresisPayload> HysteresisAI { get; set; }

            public PayloadClass()
            {
                OfflineLineProcRange = new Pair<int, int>();
                OfflineRange = new Pair<int, int>();
                OfflineRange2 = new Pair<int, int>();

                Actions = new List<Action>();

                Priorities = new List<Priority>();
                TestSets = new List<TestSet>();

                Links = new SerializableDictionary<int, int>();

                Hysteresis = new SerializableDictionary<HysteresisKind, HysteresisPayload>();
                HysteresisAI = new SerializableDictionary<int, HysteresisPayload>();

                PowerOffPin = 1;
            }
        }

        public string FileName { get; set; }
        public PayloadClass Payload { get; set; }
        public bool Dirty { get; set; }
        public int IP { get; set; }
        public Random Random = new Random();
        const int ver = 3;

        public Settings()
        {
            New();
        }

        public Settings(string file)
        {
            Load(file);
        }

        public bool Load(string file)
        {
            XmlSerializer DeSerializer = new XmlSerializer(typeof(PayloadClass));

            PayloadClass pc;
            using (FileStream stream = File.OpenRead(FileName = file))
                pc = (PayloadClass)DeSerializer.Deserialize(stream);

            if (pc.Buttons.Count == 0 && pc.Priorities.Count != 0)
            {
                if (MessageBox.Show("The file you are trying to load doesn't contain any buttons, " +
                    "but there are priority sets referencing them. Would you want me to try to " +
                    "fill in buttons from the registry (from the old version of the button lists)?\n\n"+
                    "This may not work and it might render the entire file unusable. Please "+
                    "test it thoroughly before saving!",
                    "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string log = "";

                        RegistryKey root = Registry.LocalMachine.OpenSubKey("software")
                            .OpenSubKey("ss").OpenSubKey("button tester");
                        int n = (int)root.GetValue(null);

                        for (int i = 0; i < n; ++i)
                        {
                            PayloadClass.ButtonType bt = new PayloadClass.ButtonType();
                            bt.Name = (string)root.GetValue("name_" + i);
                            bt.PinID = (int)root.GetValue("pinid_" + i);

                            pc.Buttons.Add(bt);

                            log += bt.Name + " (" + bt.PinID + ")\n";
                        }

                        MessageBox.Show("Buttons found and loaded: " + log, "Import log", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        Payload = pc;
                    }
                    catch
                    {
                        MessageBox.Show("Could not load the buttons from the registry.", "Import log", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (pc.Version < ver && MessageBox.Show("The file you are trying to load is an from an older version " +
                    "of this program. It will most likely not work or work wrong. Are you sure you want to load it?",
                    "Old save file detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Payload = pc;
                else if (pc.Version > ver && MessageBox.Show("The file you are trying to load is an from a newer (!) version " +
                    "of this program. It will most likely not work or work wrong. Are you sure you want to load it?",
                    "Newer save file detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Payload = pc;
                else if (pc.Version == ver)
                    Payload = pc;
                else
                    return false;
            }

            Payload.Version = ver;

            Dirty = false;

            return true;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PayloadClass));

            Payload.Version = ver;
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
                serializer.Serialize(fs, Payload);

            Dirty = false;
        }

        public void New()
        {
            Payload = new PayloadClass();
            FileName = null;
            Dirty = false;
        }
    }
}
