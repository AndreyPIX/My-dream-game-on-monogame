using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyRTS.Experemental.Controle
{
    public class KeyBoardRotationController : KeyBoardController
    {
        /*
        public override Vector2 ProcessKeyAction(EnumKeyAction keyAction, Vector2 delta)
        {
            float alpha = MathHelper.ToRadians(0.25f);
            switch (keyAction)
            {
                case 
        EnumKeyAction.None:
                    break;
                case EnumKeyAction.TurnLeft:
                    puppet.Rotation(-alpha);
                    break;
                case EnumKeyAction.TurnRight:
                    puppet.Rotation(alpha);
                    break;
                case EnumKeyAction.MoveForward:
                    delta.X = 1 * (float)Math.Cos(puppet.Angle);   // X = R * cos(angle)
                    delta.Y = 1 * (float)Math.Sin(puppet.Angle);   // Y = R * sin(angle)
                    break;
                case EnumKeyAction.MoveBackward:
                    delta.X = -1 * (float)Math.Cos(puppet.Angle);
                    delta.Y = -1 * (float)Math.Sin(puppet.Angle);
                    break;
                case EnumKeyAction.Attack:
                    break;
                default:
                    break;
            }
            return delta;
        }
        */
    }
}
