using System.Windows.Input;
using Common.Models;
using Engine.Parsers;
using GmView.Command;
using Models;

namespace GmView.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public Controller Controller { get { return Controller.Instance; } }


        private string _cmdText;
        public string CmdText
        {
            get { return _cmdText; }
            set
            {
                Set(ref _cmdText, value);
            }
        }

        private GrammarParseResult _result;
        public GrammarParseResult Result
        {
            get { return _result; }
            set
            {
                Set(ref _result, value);
            }
        }

        
        public ICommand Cmd_ExecuteCommandText { get; }


        public MainViewModel()
        {
            Cmd_ExecuteCommandText = new RelayCommand(ExecuteCommandText);
        }


        private void ExecuteCommandText()
        {
            Result = ParserHelper.Evaluate(CmdText, Controller.CurrentRuleSet);
        }
    }
}