using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MoneyCeeper.Model;
using MoneyCeeper.User_Controls;
using MoneyCeeper.Windows;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace MoneyCeeper.ViewModels
{
    public class RightPanelVM : ViewModelBase, IMainWindowsCodeBehind
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        private IMainWindowsCodeBehind CurrentUC;
        private IMainWindowsCodeBehind CostVM;
        private IMainWindowsCodeBehind MainWnd;
        #endregion

        #region Constructors
        public RightPanelVM(IMainWindowsCodeBehind codeBehind, IMainWindowsCodeBehind UC, 
            IMainWindowsCodeBehind costVM, IMainWindowsCodeBehind mainWnd)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            _MainCodeBehind = codeBehind;
            CurrentUC = UC;
            CostVM = costVM;
            MainWnd = mainWnd;
        }
        #endregion

        #region Commands
        private RelayCommand _CloseMainWindowCommand;
        public RelayCommand CloseMainWindowCommand
        {
            get
            {
                return _CloseMainWindowCommand = _CloseMainWindowCommand ??
                    new RelayCommand(() => (MainWnd as MainWindow).Close(), () => true);
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

        private RelayCommand _GiveAdviceCommand;
        public RelayCommand GiveAdviceCommand
        {
            get
            {
                return _GiveAdviceCommand = _GiveAdviceCommand ??
                    new RelayCommand(OnAdviceCommand, () => true);
            }
        }
        #endregion

        #region Command Parameters
        private void OnOpenGraphsCommand()
        {
            GraphsWindow graphsW = new GraphsWindow();
            GraphsVM graphsVM = new GraphsVM(graphsW, (CostVM as CostListVM).CostCollection);
            graphsW.DataContext = graphsVM;
            graphsW.Show();
        }

        private void OnOpenDiagrammCommand()
        {
            DiagrammWindow diagW = new DiagrammWindow();
            DiagrammVM diagVM = new DiagrammVM(diagW, (CostVM as CostListVM).CostCollection);
            diagW.DataContext = diagVM;
            diagW.Show();
        }

        private void OnOpenAdvicesCommand()
        {
            AdvicesWindow advW = new AdvicesWindow();
            AdvicesVM advVM = new AdvicesVM(advW, (CostVM as CostListVM).CostCollection);
            advW.DataContext = advVM;
            advW.Show();
        }

        private void OnAdviceCommand()
        {
            List<Cost> tempCollection = new List<Cost>();
            DateTime currentDate = DateTime.Now;
            for(int i = 0; i < Advices.AdvicesList.Length; i++)
            {
                AdviceAnalyzer(tempCollection, currentDate, i);
            }
            
        }
        public void LoadView(ViewType typeView)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Local Func
        public void AdviceAnalyzer(List<Cost> tempCollection, DateTime currentDate, int keyIndex)
        {
            tempCollection = (CostVM as CostListVM).CostCollection.Where(elem =>
            elem.Date_Time.DayOfWeek <= currentDate.DayOfWeek
            && elem.Date_Time.Year == currentDate.Year
            && elem.Date_Time.Month == currentDate.Month).ToList();

            Regex keyWord = new Regex(Advices.KeyWords[keyIndex], RegexOptions.IgnoreCase);
            tempCollection = tempCollection.FindAll(elem =>
            {
                if (elem.Comment.Length != 0)
                {
                    return keyWord.IsMatch(elem.Comment);
                }
                return keyWord.IsMatch(elem.Comment);
            });
            if (tempCollection.Count < 5)
            {
                (CurrentUC as RightPanelUC).TextTemplate.Text = string.Empty;
                (CurrentUC as RightPanelUC).EnterAdvice.Text = "Пока что всё хорошо";
            }
            else
            {
                (CurrentUC as RightPanelUC).TextTemplate.Text = string.Empty;
                (CurrentUC as RightPanelUC).EnterAdvice.Text = Advices.AdvicesList[keyIndex];
            }
        }
        #endregion
    }
}
