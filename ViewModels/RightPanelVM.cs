using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;

namespace MoneyCeeper.ViewModels
{
    class RightPanelVM : ViewModelBase
    {
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;

        //ctor
        public RightPanelVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public RightPanelVM(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
        }

        #region Commands
        private RelayCommand _CloseMainWindowCommand;
        public RelayCommand CloseMainWindowCommand
        {
            get
            {
                return _CloseMainWindowCommand = _CloseMainWindowCommand ??
                    new RelayCommand(() => (_MainCodeBehind as MainWindow).Close(), () => true);
            }
        }

        private RelayCommand _OpenGraphsWCommand;
        public RelayCommand OpenGraphsWCommand
        {
            get
            {
                return _OpenGraphsWCommand = _OpenGraphsWCommand ??
                    new RelayCommand(OnOpenGraphsCommand, () => true);
            }
        }

        private RelayCommand _OpenDiagrammWCommand;
        public RelayCommand OpenDiagrammWCommand
        {
            get
            {
                return _OpenDiagrammWCommand = _OpenDiagrammWCommand ??
                    new RelayCommand(OnOpenDiagrammCommand, () => true);
            }
        }

        private RelayCommand _OpenAdvicesWCommand;
        public RelayCommand OpenAdvicesWCommand
        {
            get
            {
                return _OpenAdvicesWCommand = _OpenAdvicesWCommand ??
                    new RelayCommand(OnOpenAdvicesCommand, () => true);
            }
        }

        #endregion

        #region Command Parameters
        private void OnOpenGraphsCommand()
        {
            GraphsWindow graphsW = new GraphsWindow();
            GraphsVM graphsVM = new GraphsVM(graphsW, CurrentUser.Login);
            graphsW.DataContext = graphsVM;
            graphsW.Show();
        }

        private void OnOpenDiagrammCommand()
        {
            DiagrammWindow diagW = new DiagrammWindow();
            DiagrammVM diagVM = new DiagrammVM(diagW, CurrentUser.Login);
            diagW.DataContext = diagVM;
            diagW.Show();
        }

        private void OnOpenAdvicesCommand()
        {
            AdvicesWindow advW = new AdvicesWindow();
            AdvicesVM advVM = new AdvicesVM(advW, CurrentUser.Login);
            advW.DataContext = advVM;
            advW.Show();
        }
        #endregion

    }
}
