using System.Windows.Controls;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.Views;

namespace SuperPowerEditor.UI.SPEditor.UserControls
{
    /// <summary>
    /// Interaction logic for Designs.xaml
    /// </summary>
    public partial class Designs : UserControl, IDesignView
    {
        public Designs()
        {
            InitializeComponent();

            //// TODO : temporary added for testing purpose
            //var connectionString = new FbConnectionStringBuilder
            //{
            //    Database = @"D:\SteamLibrary\SteamApps\common\SuperPower 2\MODS\SP2\data\DATABASE2.GDB",
            //    ServerType = FbServerType.Embedded,
            //    UserID = "SYSDBA",
            //    Password = "masterkey",
            //    ClientLibrary = "fbembed.dll"
            //}.ToString();


            //// TODO : remove all temporary references
            //SuperPowerEditorDbContext context = new SuperPowerEditorDbContext(connectionString);

            //List<Design> designs = context.Designs.ToList();

            //_dataGrid.ItemsSource = designs;
        }

        public IDesignPresenter Presenter { get; set; }
    }
}
