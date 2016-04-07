using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MoneyFox.Droid.Activities;
using MoneyFox.Shared.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using OxyPlot.Xamarin.Android;

namespace MoneyFox.Droid.Fragments
{
    [MvxFragment(typeof (MainViewModel), Resource.Id.content_frame)]
    [Register("moneyfox.droid.fragments.StatisticCashFlowFragment")]
    public class StatisticCashFlowFragment : MvxFragment<StatisticCashFlowViewModel>
    {
        private PlotView plotModel;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.fragment_graphical_statistic, null);

            ((MainActivity) Activity).SetSupportActionBar(view.FindViewById<Toolbar>(Resource.Id.toolbar));
            ((MainActivity) Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            plotModel = view.FindViewById<PlotView>(Resource.Id.plotViewModel);

            return view;
        }

        public override void OnStart()
        {
            OnResume();

            ViewModel.LoadCommand.Execute();
            plotModel.Model = ViewModel.CashFlowModel;
        }
    }
}