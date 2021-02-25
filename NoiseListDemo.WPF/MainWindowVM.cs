using NoiseList;
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
            StuffList = NoiseList<Stuff>.Build(10);

            //StuffList = new List<Stuff>
            //{
            //    new Stuff(1,"lol", 3.0f, true),
            //    new Stuff(2, "no", 3.1f, false)
            //};
        }
    }
}