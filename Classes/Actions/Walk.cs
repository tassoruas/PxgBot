using PxgBot.Helpers;
using System.Threading.Tasks;

namespace PxgBot.Classes.Actions
{
    public static class Walk
    {
        public async static Task<bool> WalkTo(PXG.Position position)
        {
            // TODO
            System.Console.WriteLine("Tried to walk");
            if (position.X > Character.PosX)
            {

            }
            else
            {

            }

            Character.SetDestinPosition(position.X, position.Y);

            while (Character.PosX != position.X && Character.PosY != position.Y)
            {
                await Task.Delay(1000);
                if (Character.DestinX == -1) return false;
                if (Character.DestinY == -1) return false;
            }
            return true;
        }
    }
}
