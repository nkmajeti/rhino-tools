﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Binsor.Presentation.Framework.Interfaces
{
	public interface ILayoutRegistry
	{
		void AddView(IView view);
		void RegisterLayout(ILayout layout);
	}
}
