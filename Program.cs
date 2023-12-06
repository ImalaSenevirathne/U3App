using System;
using System.Drawing;

namespace U3App
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 0;
            int height = 0;
            int initPosX = 0;
            int initPosY = 0;
            string faceDirection = null;

            string[] arrInputs = new string[3];
            string[] arrField = new string[2];
            char[] arrCommands = null;

            for (int i = 0; i < 3; i++)
            {
                arrInputs[i] = Console.ReadLine();

                if (i == 0)
                {
                    arrField = arrInputs[i].Split(" ");
                    width = Convert.ToInt32(arrField[0]);
                    height = Convert.ToInt32(arrField[1]);
                }

                if (i == 1)
                {
                    arrField = arrInputs[i].Split(" ");
                    initPosX = Convert.ToInt32(arrField[0]);
                    initPosY = Convert.ToInt32(arrField[1]);
                    faceDirection = arrField[2].ToUpper();
                }

                if (i == 2)
                {
                    arrCommands = arrInputs[i].ToUpper().ToCharArray();
                }
            } 

            carMovement(width, height, initPosX, initPosY, faceDirection, arrCommands);
        }

        private static void carMovement(int width, int  height, int x, int y, string face, char[] commandList)
        {
            for (int i = 0; i < commandList.Length; i++)
            {
                if (commandList[i] == 'R')
                {
                    switch (face)
                    {
                        case "N":
                            face = "E";
                            break;
                        case "E":
                            face = "S";
                            break;
                        case "S":
                            face = "W";
                            break;
                        case "W":
                            face = "N";
                            break;
                    }
                }

                if (commandList[i] == 'L')
                {
                    switch (face)
                    {
                        case "N":
                            face = "W";
                            break;
                        case "E":
                            face = "N";
                            break;
                        case "S":
                            face = "E";
                            break;
                        case "W":
                            face = "S";
                            break;
                    }
                }

                if (commandList[i] == 'F' && face == "N")
                {
                    y = (y + 1) > height ? height : (y + 1); 
                }
                else if(commandList[i] == 'F' && face == "S")
                {
                    y = (y - 1) < 0 ? 0 : (y - 1);
                }
                else if(commandList[i] == 'F' && face == "E")
                {
                    x = (x + 1) > width ? width : (x + 1);
                }
                else if(commandList[i] == 'F' && face == "W")
                {
                    x = (x - 1) < 0 ? 0 : (x - 1);
                }
            }

            Console.WriteLine("{0} {1} {2}",x,y,face);
        }
    }
}
