﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using System;

namespace SiliconStudio.ExecServer
{
    public class Program
    {
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        public static int Main(string[] args)
        {
            var serverApp = new ExecServerApp();
            var result = serverApp.Run(args);
            //Environment.Exit(result);
            return result;
        }
    }
}