using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PxgBot.Helpers;
using AutoIt;
using System.Windows.Forms;

namespace PxgBot.Classes
{
    static class Cavebot
    {
        public static bool Enabled { get; set; }
        public static List<CavebotAction> CavebotScript = new List<CavebotAction>();
        public async static void Start()
        {
            try
            {
                Enabled = true;
                while (Enabled)
                {
                    foreach (CavebotAction action in CavebotScript)
                    {
                        await ExecuteStep(action);
                        if (Enabled == false) break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cavebot error: " + ex.Message);
            }
        }

        public static void Stop()
        {
            Enabled = false;
        }

        private async static Task<bool> ExecuteStep(CavebotAction cbAction)
        {

            if (cbAction.Condition != null)
            {
                while (cbAction.Condition())
                {
                    await ExecuteAction(cbAction);
                }
            }
            else
            {
                await ExecuteAction(cbAction);
            }

            return true;
        }

        private async static Task<bool> ExecuteAction(CavebotAction cbAction)
        {
            while (await Character.isAttacking)
            {
                AutoItX.Sleep(500);
            }

            if (cbAction.Action == ActionTypes.Fishing)
            {
                return await Actions.Fishing.StartFishing(int.Parse(cbAction.Arguments[0]), int.Parse(cbAction.Arguments[1]));
            }
            else if (cbAction.Action == ActionTypes.Wait)
            {
                await Task.Delay(Convert.ToInt32(cbAction.Arguments[0]));
            }
            else if (cbAction.Action == ActionTypes.Walk)
            {
                return await Actions.Walk.WalkTo(cbAction.Position);
            }
            else if (cbAction.Action == ActionTypes.Talk)
            {
                return Actions.Talk.TalkToNurse();
            }

            return false;
        }
    }

    enum ActionTypes
    {
        Fishing,
        Wait,
        Walk,
        Talk
    }

    class CavebotAction
    {
        public PXG.Position Position { get; set; }
        public ActionTypes Action { get; set; }

        public string[] Arguments { get; set; }

        public Func<bool> Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="position"></param>
        public CavebotAction(PXG.Position position, ActionTypes action)
        {
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
        public CavebotAction(PXG.Position position, ActionTypes action, string[] args = null, Func<bool> condition = null)
        {
            Position = position;
            Action = action;
            Arguments = args;
            Condition = condition;
        }
    }
}
