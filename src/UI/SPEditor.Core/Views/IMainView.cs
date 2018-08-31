using System;
using System.Collections.Generic;
using System.Text;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.Views
{
    public interface IMainView : IPresenteredView<IMainPresenter>
    {
        object DataContext { get; set; }
    }
}
