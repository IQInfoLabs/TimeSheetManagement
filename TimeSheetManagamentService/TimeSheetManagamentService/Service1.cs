﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetManagamentService
{
    public partial class TimeSheetManagement : ServiceBase
    {
        public TimeSheetManagement()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            TimeManagement.Instance.EnableFileWatch();
        }

        protected override void OnStop()
        {
        }
    }
}
