using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
	public class TaskCls
	{
		TaskCls() 
		{
			Task.Delay(100);
			Task.Delay(TimeSpan.FromSeconds(1));
			Task.Delay(TimeSpan.FromMinutes(1));
		}	
		
	}
}
