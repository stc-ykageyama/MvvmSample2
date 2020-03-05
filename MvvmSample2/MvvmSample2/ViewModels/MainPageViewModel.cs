using Prism.Commands;
using Prism.Navigation;
using MvvmSample2.Models;

namespace MvvmSample2.ViewModels
{
    /// <summary>
    /// MainPageのViewModel
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        // プロパティ
        private int number;
        public int Number
        {
            get { return number; }
            set { SetProperty(ref number, value); }
        }

        // デクリメントコマンド
        public DelegateCommand DecrementCommand { get; }

        // インクリメントコマンド
        public DelegateCommand IncrementCommand { get; }

        // モデル
        private Counter model = new Counter();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="navigationService"></param>
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            // モデルのイベントハンドラ登録
            // ★このサンプルではプロパティが1個だからいいけど、プロパティがたくさんあると記述が大変！
            model.PropertyChanged += (sender, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(Counter.Number):
                        Number = ((Counter)sender).Number;
                        break;
                }
            };
            // デクリメントコマンド実行時の処理
            DecrementCommand = new DelegateCommand(() => model.Decrement());
            // インクリメントコマンド実行時の処理
            IncrementCommand = new DelegateCommand(() => model.Increment());
        }
    }
}
