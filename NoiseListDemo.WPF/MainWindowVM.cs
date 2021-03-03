using NoiseLists;
using System.Collections.Generic;

namespace NoiseListDemo.WPF
{
    public class MainWindowVM : ViewModelBase
    {
        private List<Stuff> _stuffList = new List<Stuff>();
        public List<Stuff> StuffList
        {
            get { return _stuffList; }
            set { SetProperty(ref _stuffList, value); }
        }

        public MainWindowVM()
        {
            StuffList = NoiseList<Stuff>.Build(1);
        }
    }
}