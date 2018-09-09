using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.Base.DataAccess.Entities;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IDesignViewModel : IViewModel
    {
        string TabHeaderTitle { get; set; }
        string IconSource { get; set; }
        ICommand CloseCommand { get; set; }
        ObservableCollection<DesignModel> Designs { get; set; }
        DesignModel SelectedDesign { get; set; }
        bool ContentIsSelected { get; set; }
    }
}