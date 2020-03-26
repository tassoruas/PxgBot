using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PxgBot.Classes
{
    static class Cavebot
    {
        public async static void Start()
        {
            Func<bool> condition = () => Pokemon.HP > 200;
            CavebotAction cavebotAction = new CavebotAction(StepTypes.Action, null, ActionTypes.Fishing, new string[] { "1004", "549" }, condition);
            await ExecuteNextStep(cavebotAction);
        }
        private async static Task<bool> ExecuteNextStep(CavebotAction cbAction)
        {
            if (cbAction.Step == StepTypes.Action)
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
            }
            else if (cbAction.Step == StepTypes.Walk)
            {
                ExecuteWalk(cbAction);
            }
            else if (cbAction.Step == StepTypes.Wait)
            {
                ExecuteWait(cbAction);
            }

            return true;
        }

        private async static Task<bool> ExecuteAction(CavebotAction cbAction)
        {
            if (cbAction.Action == ActionTypes.Fishing)
            {
                return await Actions.Fishing.StartFishing(int.Parse(cbAction.Arguments[0]), int.Parse(cbAction.Arguments[1]));
            }

            return false;
        }

        private static void ExecuteWalk(CavebotAction cbAction)
        {
            Actions.Walk.WalkTo(cbAction.Position);
        }

        private async static void ExecuteWait(CavebotAction cbAction)
        {
            await Task.Delay(Convert.ToInt32(cbAction.Arguments[0]));
        }
    }


    /// <summary>
    /// StypTypes is what kind of action will be executed
    /// </summary>
    enum StepTypes
    {
        Walk,
        Wait,
        Action,
    }

    enum ActionTypes
    {
        Fishing,
    }

    class CavebotAction
    {
        public StepTypes Step { get; set; }
        public PXG.Position Position { get; set; }
        public ActionTypes Action { get; set; }

        public string[] Arguments { get; set; }

        public Func<bool> Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="position"></param>
        public CavebotAction(StepTypes step, PXG.Position position)
        {
            Step = step;
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
        public CavebotAction(StepTypes step, PXG.Position position, ActionTypes action, string[] args, Func<bool> condition = null)
        {
            Step = step;
            Position = position;
            Action = action;
            Arguments = args;
            Condition = condition;
        }
    }
}
