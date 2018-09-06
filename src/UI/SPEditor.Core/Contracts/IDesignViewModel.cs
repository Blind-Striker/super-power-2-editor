using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SuperPowerEditor.Base.DataAccess.Entities;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IDesignViewModel : IViewModel
    {
        string TabHeaderTitle { get; set; }
        string IconSource { get; set; }
        ICommand CloseCommand { get; set; }
        ObservableCollection<Design> Designs { get; set; }
        Base.DataAccess.Entities.Design SelectedDesign { get; set; }
        bool ContentIsSelected { get; set; }
    }
}