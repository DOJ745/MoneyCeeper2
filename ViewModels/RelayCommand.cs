﻿using System;
using System.Windows.Input;

namespace MoneyCeeper.ViewModels
{
    public class RelayCommand : ICommand
    {
        /*private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _onExecute;
        private readonly EventHandler _requerySuggested;

        /// <summary>Событие извещающее об измении состояния команды</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>Конструктор команды</summary>
        /// <param name="execute">Выполняемый метод команды</param>
        /// <param name="canExecute">Метод разрешающий выполнение команды</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _onExecute = execute;
            _canExecute = canExecute;

            _requerySuggested = (o, e) => Invalidate();
            CommandManager.RequerySuggested += _requerySuggested;
        }

        public void Invalidate() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>Вызов разрешающего метода команды</summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>True - если выполнение команды разрешено</returns>
        public bool CanExecute(object parameter) => _canExecute == null ? true : 
           _canExecute.Invoke(parameter);

        /// <summary>Вызов выполняющего метода команды</summary>
        /// <param name="parameter">Параметр команды</param>
        public void Execute(object parameter) => _onExecute?.Invoke(parameter);*/

        Action _TargetExecuteMethod;
        Action<object> _TargetExecuteMethodObj;
        Action<ExecutedRoutedEventArgs> _TatgetExecuteMethodArg;
        Func<bool> _TargetCanExecuteMethod;

        public RelayCommand(Action executeMethod, object p)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public RelayCommand(Action<object> executeMethodObj, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethodObj = executeMethodObj;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public RelayCommand(Action<ExecutedRoutedEventArgs> executeMethodExe, Func<bool> canExecuteMethod)
        {
            _TatgetExecuteMethodArg = executeMethodExe;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            if(_TargetExecuteMethodObj != null)
            {
                return true;
            }
            if(_TatgetExecuteMethodArg != null)
            {
                return true;
            }
            return false;
        }

        // Beware - should use weak references if command instance lifetime is longer than 
        // lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
        #endregion

    }
}
