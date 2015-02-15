using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmLight1.Model;
using System.Windows;



namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;


        public RelayCommand<string> SayHelloCommand { get; private set; }

        #region Counter
        /// <summary>
        /// The <see cref="Counter" /> property's name.
        /// </summary>
        public const string CounterPropertyName = "Counter";

        private int _counter = 0;

        /// <summary>
        /// Sets and gets the Counter property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Counter
        {
            get
            {
                return _counter;
            }

            set
            {
                if (_counter == value)
                {
                    return;
                }

                _counter = value;
                RaisePropertyChanged(CounterPropertyName);
                SayHelloCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        public string Message { get {return "Hello Nuget"; }  }

        



        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService; 
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });



            //RW
            SayHelloCommand = new RelayCommand<string>(
                Showmessage, (s) => _counter % 2 == 0);


        }

        public void Showmessage(string obj)
        {
            MessageBox.Show("Hello ," + obj);
                        
        }


        




        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}


    }
}