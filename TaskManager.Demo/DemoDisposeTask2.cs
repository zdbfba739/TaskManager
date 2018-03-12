﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManager.Demo
{
    public class DemoDisposeTask2: BSF.BaseService.TaskManager.BaseDllTask
    {
        public DemoDisposeTask2():base()
        {
            this.SafeDisposeOperator = new BSF.BaseService.TaskManager.SystemRuntime.TaskSafeDisposeOperator(1);
        }

        public override void Run()
        {
            this.OpenOperator.Log("开始");
            while (true)
            {
                System.Threading.Thread.Sleep(5000);
                this.OpenOperator.Log("停顿5秒");
                if (this.SafeDisposeOperator.DisposedState == BSF.BaseService.TaskManager.SystemRuntime.TaskDisposedState.Disposing)
                    break;
            }
            this.SafeDisposeOperator.DisposedState = BSF.BaseService.TaskManager.SystemRuntime.TaskDisposedState.Finished;
            this.OpenOperator.Log("退出");
        }

        public override void TestRun()
        {
            base.TestRun();
        }

        public override void Dispose()
        {
            base.Dispose();

        }
    }
}
