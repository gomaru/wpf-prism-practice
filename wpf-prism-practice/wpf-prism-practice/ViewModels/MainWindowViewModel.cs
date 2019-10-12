using System;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;


namespace wpf_prism_practice.ViewModels
{
    public class MainWindowViewModel : BindableBase, System.IDisposable
    {
        void System.IDisposable.Dispose() { this.disposables.Dispose(); }
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _selectedItemText;
        public string SelectedItemText
        {
            get { return _selectedItemText; }
            private set { SetProperty(ref _selectedItemText, value); }
        }

        public ReactiveCommand SelectedItemChanged { get; }

        public IList<string> Items { get; private set; }

        public DelegateCommand<object[]> SelectedCommand { get; private set; }

        private System.Reactive.Disposables.CompositeDisposable disposables
            = new System.Reactive.Disposables.CompositeDisposable();

        public MainWindowViewModel()
        {
            Items = new List<string>();

            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
            Items.Add("Item5");

            // This command will be executed when the selection of the ListBox in the view changes.
            SelectedCommand = new DelegateCommand<object[]>(OnItemSelected);

            this.SelectedItemChanged = new ReactiveCommand()
                            .AddTo(this.disposables);
            this.SelectedItemChanged.Subscribe(e => this.nodeChanged());
        }

        private void nodeChanged()
        {
            int p = 1;
        }

        private void OnItemSelected(object[] selectedItems)
        {
            if (selectedItems != null && selectedItems.Count() > 0)
            {
                SelectedItemText = selectedItems.FirstOrDefault().ToString();
            }
        }
    }
}
