﻿using System;
namespace StrategyRTS.ProceduralGeneration
{
    public class GeneratorWorld
    {

        private static int[,] FillArray(int[,] array, int fillingNumber)
        {
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                    array[y, x] = fillingNumber;
            }
            return array;
        }
        private static int[,] BasicRuleGeneration(int[,] array, Random fillingNumber)
        {
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    const int minLayer = 0;
                    const int maxLayer = 3;
                    int minRange = minLayer;
                    int maxRange = maxLayer;
                    int totalLayer = 0;
                    int countLayer = 0;
                    int layer;
                    if (array[y, x] == -1)
                    {
                        if (x > 0 && array[y, x - 1] > -1)
                        {
                            totalLayer += array[y, x - 1];
                            countLayer++;
                        }
                        if (x < array.GetLength(0) - 1 && array[y, x + 1] > -1)
                        {
                            totalLayer += array[y, x + 1];
                            countLayer++;
                        }
                        if (y > 0 && array[y - 1, x] > -1)
                        {
                            totalLayer += array[y - 1, x];
                            countLayer++;
                        }
                        if (y < array.GetLength(1) - 1 && array[y + 1, x] > -1)
                        {
                            totalLayer += array[y + 1, x];
                            countLayer++;
                        }
                        layer = (int)Math.Round((float)totalLayer / countLayer);
                        if (layer == minLayer)
                        {
                            if (fillingNumber.NextSingle() > 0)
                                maxRange = 2;
                            else
                                maxRange = 1;
                        }
                        else if (layer + 1 == maxLayer)
                        {
                            if (fillingNumber.NextSingle() > 0)
                                minRange = 1;
                            else
                                minRange = 2;
                        }
                        else
                        {
                            if (fillingNumber.NextSingle() > 0)
                            {
                                minRange = 0;
                                maxRange = 3;
                            }
                            else
                            {
                                minRange = 1;
                                maxRange = 2;
                            }
                        }
                        array[y, x] = fillingNumber.Next(minRange, maxRange);
                    }
                }
            }
            return array;
        }
        public static int[,] DepthSmoothing(int[,] array)
        {
            int[,] tempArray = new int[array.GetLength(0), array.GetLength(1)];
            for (int gaps = 0; gaps < 2 /*maxLayer - 1*/; gaps++)
            {
                for (int y = 0; y < array.GetLength(0); y++)
                {
                    for (int x = 0; x < array.GetLength(1); x++)
                    {
                        int countUpLayer = 0;
                        int countDownLayer = 0;
                        if (array[y, x] == gaps || array[y, x] == gaps + 1)
                        {
                            for (int y0 = -1; y0 < 2; y0++)
                            {
                                for (int x0 = -1; x0 < 2; x0++)
                                {
                                    if (y + y0 < 0)
                                        y0++;
                                    else if (y + y0 > array.GetLength(0) - 1)
                                        break;
                                    if (x + x0 < 0)
                                        continue;
                                    else if (x + x0 > array.GetLength(1) - 1)
                                        continue;
                                    if (array[y0 + y, x0 + x] == gaps)
                                        countDownLayer++;
                                    else if (array[y0 + y, x0 + x] == gaps + 1)
                                        countUpLayer++;
                                    else if (array[y0 + y, x0 + x] < gaps)
                                        countDownLayer++;
                                    else if (array[y0 + y, x0 + x] > gaps + 1)
                                        countUpLayer++;
                                }
                            }
                        }
                        if (countDownLayer > countUpLayer)
                            tempArray[y, x] = gaps;
                        else if (countDownLayer < countUpLayer)
                            tempArray[y, x] = gaps;
                    }
                }
            }
            return tempArray;
        }
        public static int[,] CreateWorld(int countCellGameObject, int height, int width)
        {
            Random random = new Random();
            // 1) Создаём пустой мир
            int[,] world = new int[height, width];
            // 2) Удаляем нулевую глубену
            world = FillArray(world, -1);
            // 3) Устанавливаем точку в углу со случайной глубиной
            world[0, 0] = random.Next(0, 3);
            // 4) Начинаем генерировать мир
            world = BasicRuleGeneration(world, random);
            // 5) Сглаживаем рельеф
            //world = DepthSmoothing(world);
            return world;
        }
        public static int[,] CreateWorld0(int countCellGameObject, int height, int width)
        {
            Random random = new Random();
            // 1) Создаём пустой мир
            int[,] world = new int[height, width];
            // 2) Удаляем нулевую глубену
            world = FillArray(world, -1);
            // 3) Устанавливаем точку в углу со случайной глубиной
            world[0, 0] = random.Next(0, 3);
            // 4) Начинаем генерировать мир
            world = BasicRuleGeneration(world, random);
            // 5) Сглаживаем рельеф
            //world = DepthSmoothing(world);
            return world;
        }
    }
}
