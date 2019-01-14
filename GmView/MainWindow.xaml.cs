using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Input.Raw;
using Avalonia.Markup.Xaml;
using GmView.ViewModel;
using System;
using System.Reactive.Linq;

namespace GmView
{
    public class MainWindow : Window
    {
        private MainViewModel _vm;
        private IDisposable _keySubscription;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            _vm = new MainViewModel();
            DataContext = _vm;

            _keySubscription = InputManager.Instance.Process.OfType<RawKeyEventArgs>().Subscribe(tb_Cmd_OnKeyPressed);
        }

        private void tb_Cmd_OnKeyPressed(RawKeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                _vm.Cmd_ExecuteCommandText.Execute(null);
            }
        }
    }
}