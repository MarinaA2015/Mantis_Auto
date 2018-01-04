﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_auto
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static bool PERFORM_LONG_UI_CHECK = true;

        [SetUp]
        public void SetupApplicationManager()
        {
            
            app = ApplicationManager.GetInstance();
           

        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(32 + rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }


    }
}