﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoIt;
using System.Windows.Forms;
using System.Data;

namespace PxgBot.Classes
{
    static class Cavebot
    {
        public static bool Enabled { get; set; }
        public static List<CavebotAction> Script = new List<CavebotAction>();
        public static int Index = 0;
        private static int lastIndex = 0;
        private static int counterIndex = 0;
        public async static void Start()
        {
            try
            {
                while (true)
                {
                    if (Enabled && Character.X != 0 && Character.HP > 0)
                    {
                        for (; Index < Script.Count; Index++)
                        {
                            if (Enabled == false) break;
                            await ExecuteStep(Script[Index]);
                            AutoItX.Sleep(30);
                        }
                        Index = 0;
                    }
                    else
                    {
                        AutoItX.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cavebot error: " + ex.Message);
            }
        }

        private async static Task<bool> ExecuteStep(CavebotAction cbAction)
        {
            if (Index == lastIndex)
            {
                counterIndex++;
            }
            else
            {
                lastIndex = Index;
            }

            if (counterIndex > 5) Index++;

            if (cbAction.Condition != null)
            {
                while (cbAction.Condition())
                {
                    if (!Pokemon.Reviving)
                    {
                        await ExecuteAction(cbAction);
                    }
                }
            }
            else
            {
                if (!Pokemon.Reviving)
                {
                    await ExecuteAction(cbAction);
                }
            }
            return true;
        }

        private async static Task<bool> ExecuteAction(CavebotAction cbAction)
        {
            while (await Character.isAttacking)
            {
                AutoItX.Sleep(500);
            }

            if (cbAction.Action == ActionTypes.Wait)
            {
                await Task.Delay(Convert.ToInt32(cbAction.Arguments[0]));
            }
            else if (cbAction.Action == ActionTypes.Walk)
            {
                bool result = false;
                int counter = 0;
                do
                {
                    result = await Actions.Walk.WalkTo(cbAction.Position);
                    counter++;
                } while (result == false || counter < 5);
                counter = 0;
                return result;
            }
            else if (cbAction.Action == ActionTypes.Talk)
            {
                return Actions.Talk.TalkToNurse();
            }
            else if (cbAction.Action == ActionTypes.Use)
            {
                bool result = false;
                int counter = 0;
                do
                {
                    result = await Actions.Walk.WalkTo(cbAction.Position, true);
                    counter++;
                } while (result == false || counter < 5);
                counter = 0;
                return result;

            }

            return false;
        }

        public static void TestInit()
        {
            //CavebotAction cavebotAction1 = new CavebotAction(null, ActionTypes.Fishing, new string[] { "894", "741" }, () => Pokemon.HP > 1000);
            CavebotAction cavebotAction1 = new CavebotAction(0, new PXG.Position(4068, 3456, 5), ActionTypes.Walk);
            CavebotAction cavebotAction2 = new CavebotAction(1, new PXG.Position(4074, 3455, 5), ActionTypes.Walk);
            CavebotAction cavebotAction3 = new CavebotAction(2, new PXG.Position(4079, 3453, 5), ActionTypes.Walk);
            CavebotAction cavebotAction4 = new CavebotAction(3, new PXG.Position(4085, 3448, 5), ActionTypes.Walk);
            CavebotAction cavebotAction5 = new CavebotAction(4, new PXG.Position(4087, 3443, 5), ActionTypes.Walk);
            CavebotAction cavebotAction6 = new CavebotAction(5, new PXG.Position(4085, 3448, 5), ActionTypes.Walk);
            CavebotAction cavebotAction7 = new CavebotAction(6, new PXG.Position(4079, 3453, 5), ActionTypes.Walk);
            CavebotAction cavebotAction8 = new CavebotAction(7, new PXG.Position(4074, 3455, 5), ActionTypes.Walk);

            Script.Add(cavebotAction1);
            Script.Add(cavebotAction2);
            Script.Add(cavebotAction3);
            Script.Add(cavebotAction4);
            Script.Add(cavebotAction5);
            Script.Add(cavebotAction6);
            Script.Add(cavebotAction7);
            Script.Add(cavebotAction8);
        }
    }

    public enum ActionTypes
    {
        Wait,
        Walk,
        Talk,
        Use
    }

    class CavebotAction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PXG.Position Position { get; set; }
        public ActionTypes Action { get; set; }
        public string[] Arguments { get; set; }
        public Func<bool> Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="position"></param>
        public CavebotAction(int id, PXG.Position position, ActionTypes action)
        {
            ID = id;
            Name = "";
            Action = action;
            Position = position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="position"></param>
        /// <param name="action"></param>
        /// <param name="args"></param>
        /// <param name="condition"></param>
        public CavebotAction(int id, PXG.Position position, ActionTypes action, string name = "", string[] args = null, Func<bool> condition = null)
        {
            ID = id;
            Name = name;
            Position = position;
            Action = action;
            Arguments = args;
            Condition = condition;
        }
    }
}
