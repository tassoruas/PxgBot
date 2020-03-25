using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PxgBot.Classes
{
    static class Cavebot
    {
        public static void ExecuteNextStep(CavebotAction cbAction)
        {
            if (cbAction.Step == StepTypes.Action)
            {
                ExecuteAction(cbAction);
            }
            else if (cbAction.Step == StepTypes.Walk)
            {
                ExecuteWalk(cbAction);
            }
            else if (cbAction.Step == StepTypes.Wait)
            {
                ExecuteWait(cbAction);
            }
        }

        public static void ExecuteAction(CavebotAction cbAction)
        {
            if (cbAction.Action == ActionTypes.StartFishing)
            {
                Actions.Fishing.StartFishing();
            }
            else if (cbAction.Action == ActionTypes.WaitFish)
            {
                Actions.Fishing.WaitFish();
            }
        }

        public static void ExecuteWalk(CavebotAction cbAction)
        {
            Actions.Walk.WalkTo(cbAction.Position);
        }

        public async static void ExecuteWait(CavebotAction cbAction)
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
        StartFishing,
        WaitFish,
    }

    class CavebotAction
    {
        public StepTypes Step { get; set; }
        public PXG.Position Position { get; set; }
        public ActionTypes Action { get; set; }

        public string[] Arguments { get; set; }

        CavebotAction(StepTypes step, PXG.Position position)
        {
            Step = step;
            Position = position;
        }
        CavebotAction(StepTypes step, PXG.Position position, ActionTypes action, string[] args)
        {
            Step = step;
            Position = position;
            Action = action;
            Arguments = args;
        }
    }
}
