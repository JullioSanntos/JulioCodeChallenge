namespace JulioCode12.Common.WPF
{
    public abstract class ViewModelBase<T>: SetPropertyBase
    {
        #region ModelContext
        private T _modelContext;

        public T ModelContext
        {
            get => _modelContext;
            set => SetProperty(ref _modelContext, value);
        }
        #endregion ModelContext

        #region ModelContextObject
        public object? ModelContextObject
        {
            get => ModelContext as object;
            set {
                ModelContext = (T)value;
                RaisePropertyChanged(nameof(ModelContextObject));
            }
        }
        #endregion ModelContextObject
    }
}
